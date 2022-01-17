using API.Model;
using Client.Base;
using Client.Repositories.Data;
using Client.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    [Authorize]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository repository;
        public EmployeesController(EmployeeRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetRegisteredData()
        {
            var result = await repository.GetRegisteredData();
            return Json(result);
        }

        //[HttpGet]
        //public async Task<JsonResult> GetRegisteredData(string NIK)
        //{
        //    var result = await repository.GetRegisteredData(NIK);
        //    return Json(result);
        //}

        [HttpPost]
        public JsonResult Register(RegistrationVM registrationVM)
        {
            var result = repository.Register(registrationVM);
            return Json(result);
        }

        [HttpPut]
        public JsonResult UpdateNIK(string nik, Employee employee)
        {
            var result = repository.UpdateNIK(nik, employee);
            return Json(result);
        }
    }
}
