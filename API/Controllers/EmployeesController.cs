using API.Base;
using API.Context;
using API.Model;
using API.Repository;
using API.Repository.Data;
//using API.ViewModel;
using API.ViewModels;
//using DurableTask.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        //private readonly MyContext myContext;
        private readonly EmployeeRepository employeeRepository;
        public IConfiguration _configuration;

        public object NIK { get; private set; }

        public EmployeesController(EmployeeRepository employeeRepository/*, MyContext myContext*/, IConfiguration configuration) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            //this.myContext = myContext;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("/Insert")]
        public ActionResult Inserted(Employee employee)
        {
            var insert = employeeRepository.Inserted(employee);
            return insert switch
            {
                0 => Ok(new { status = HttpStatusCode.OK, message = "Insert Data Successfull" }),
                1 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Insert Failed, Email already exists!" }),
                2 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Insert Failed, Phone already exists!" }),
                _ => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Insert Failed, NIK already exists!" }),
            };
        }

        [HttpPut("{NIK}")]
        public ActionResult Update(string NIK, Employee employee)
        {
            var data = employeeRepository.Get().Count();
            var nik = employeeRepository.Update(NIK, employee);
            if (data != 0)
            {
                return nik switch
                {
                    0 => Ok(new { status = HttpStatusCode.OK, message = "Update Success" }),
                    1 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Update Failed, Email already exists!" }),
                    2 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Update Failed, Phone already exists!" }),
                    3 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "NIK not found " }),
                    _ => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Update data not successfull, email and phone number already " }),
                };
                /*if (nik == 0)
{
  return Ok(new { status = HttpStatusCode.OK, message = "Update Success" });
}
else if (nik == 1)
{
  return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Update Failed, Email already exists!" });
}
else if (nik == 2)
{
  return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Update Failed, Phone already exists!" });
}
else if(nik==3)
{
  return BadRequest(new { status = HttpStatusCode.BadRequest, message = "NIK not found " });
}
else
{
  return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Update data not successfull, email and phone number already " });
}*/
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data is empty, can't update data!!" });
            }

        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var register = employeeRepository.Register(registerVM);
            return register switch
            {
                1 => Ok(new { status = HttpStatusCode.OK, register, message = "Register Success" }),
                2 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "NIK already exists" }),
                3 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Email already exists" }),
                4 => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Phone already exists" }),
                _ => BadRequest(new { status = HttpStatusCode.BadRequest, message = "Register Failed" }),
            };
        }

        [Authorize(Roles = "Director")]
        [HttpPost]
        [Route("/AssignManager")]
        public ActionResult AssignManager(AssignManagerVM assignManagerVM)
        {
            var register = employeeRepository.AssignManager(assignManagerVM);
            return register switch
            {
                1 => Ok(new { status = HttpStatusCode.OK, register, message = "Assign Manager Success" }),
                2 => BadRequest(new { status = HttpStatusCode.BadRequest, register, message = "Already assign manager" }),
                _ => BadRequest(new { status = HttpStatusCode.BadRequest, register, message = "Assign Manager Failed" }),
            };
        }

        [Authorize]
        [HttpGet("/TestJWT")]
        public ActionResult TestJWT()
        {
            return Ok("Test JWT berhasil");
        }

        [AllowAnonymous]
        //[/*Authorize*/(Roles = "Director,Manager")]
        [HttpGet("GetRegisteredData")]
        public ActionResult GetRegisteredData()
        {
            var getData = employeeRepository.GetRegisteredData();
            if (getData != null)
            {
                return Ok(getData);
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = getData, message = "Data empty" });
            }


        }

        //[HttpGet]
        //[Route("GetRegisteredData")]
        //public ActionResult RegisteredData()
        //{
        //    //var result = employeeRepository.GetRegisterDataEigerly();
           
        //        var GetRegisteredData = employeeRepository.GetRegisteredData();
        //        if (GetRegisteredData != null)
        //        {
        //            return Ok(result);
        //        }
        //        else
        //        {
        //        return Ok(new { status = HttpStatusCode.BadRequest, message = "Data not found" });
        //        }
               
                
        //}

        [HttpGet("TestCors")]
        public ActionResult TesCORS()
        {
            return Ok("Test CORS berhasil");
        }

        
        
    }
}

        
        
    
    
    
    

