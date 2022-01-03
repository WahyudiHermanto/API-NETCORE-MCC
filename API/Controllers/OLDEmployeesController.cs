using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers   
{
    [Route("api/[controller]")]
    [ApiController]
    public class OLDEmployeesController : ControllerBase
    {
        private readonly OLDEmployeeRepository employeeRepository;
        
        public OLDEmployeesController(OLDEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost]
        public ActionResult POST(Employee employee)
        {
            //return Ok(employeeRepository.POST(employee));
            try
            {
                var insert = employeeRepository.Insert(employee);
                if(insert == 1)
                {
                    return Ok(new { status = HttpStatusCode.OK, insert = insert, message = "NIK already used" });
                }
                else if (insert == 2)
                {
                    return Ok(new { status = HttpStatusCode.OK, insert = insert, message =" Email already used" });
                }
                else if (insert == 3 )
                {
                    return Ok(new { status = HttpStatusCode.OK, insert = insert, message = " Phone number already used" });
                }

                else
                {
                    return Ok(new { status = HttpStatusCode.OK, insert = insert, message = "Input Success" });
                }
            }

            catch (Exception)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Input Success" });
            } 

            
        }

        [HttpGet]
        public ActionResult Get()
        {
            /*var result = employeeRepository.Get().Count();
            var show = employeeRepository.Get();
            if (result != 0)
            {
                return Ok(new { status = HttpStatusCode.OK, show, message = "Sukses menampilkan data" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result, message = "Data kosong" });
            }*/
            return Ok(employeeRepository.Get());
            
        }

        [HttpGet("{NIK}")]
        //[route] cari tau penggunaan nya
        public ActionResult Get(string NIK)
        {
            try
            {
                var code = 0;
                var message = "";
                var result = employeeRepository.Get(NIK);

                if (result != null)
                {
                    Console.WriteLine("");
                    code = StatusCodes.Status200OK;
                    Console.WriteLine("");
                    message = " NIK Found";
                }
                else
                {
                    code = StatusCodes.Status404NotFound;
                }
                string jsonString = JsonConvert.SerializeObject(new { code, result, message });
                return Ok(jsonString);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        //[route] cari tau penggunaan nya
        public ActionResult Update(string NIK, Employee employee)
        {
            try 
            {
                var update = employeeRepository.Update(NIK, employee);
                if(update == 1)
                {
                    return Ok(new { status = HttpStatusCode.OK, update = update, message = $"Sukses upload data dengan NIK {NIK}" });
                }
                else if (update == 2)
                {
                    return Ok(new { status = HttpStatusCode.NotFound, message = "NIK tidak ditemukan" });
                    
                }
                else if (update == 3)
                {
                    return Ok(new { status = HttpStatusCode.Conflict, message = "Nomor Hp sudah ada" });
                }
                else if (update == 4)
                {
                    return Ok(new { status = HttpStatusCode.Conflict, message = "Email sudah ada" });
                }
                else
                {
                    return Ok(new { status = HttpStatusCode.NotModified, message = "Tidak ada data yang dirubah" });
                }
            }
            catch (Exception)
            {
                return Ok(new { status = HttpStatusCode.BadRequest, message = "Tidak ada data yang dirubah" });
            }
        }

        [HttpDelete("{NIK}")]
        //[route] cari tau penggunaan nya
        public ActionResult Delete(string NIK)
        {
            try
            {
                var result = employeeRepository.Get().Count();
                if(result != 0)
                {
                    employeeRepository.Delete(NIK);
                    return Ok(new { status = HttpStatusCode.OK, result, message = "Sukses hapus data" });
                }
                else
                {
                    return BadRequest(new { status = HttpStatusCode.OK, result, message = "NIK tidak ditemukan" });
                }
            }
            catch
            {
                throw;
            }
        }


    }
}
