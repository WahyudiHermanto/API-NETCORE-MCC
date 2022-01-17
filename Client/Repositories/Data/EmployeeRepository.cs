using API.Model;
using Client.Base;
//using Client.Repository;
using Client.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace Client.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public EmployeeRepository(Address address, string request = "Employees/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
            //JWT
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
        }
        public async Task<List<RegisterVM>> GetRegisteredData()
        {
            List<RegisterVM> entities = new List<RegisterVM>();

            using (var response = await httpClient.GetAsync(request + "GetRegisteredData/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RegisterVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<RegisterVM>> GetRegisterData(string NIK)
        {
            List<RegisterVM> entities = new List<RegisterVM>();

            using (var response = await httpClient.GetAsync(request + "GetRegisterData/" + NIK))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RegisterVM>>(apiResponse);
            }
            return entities;
        }

        public Object Register(RegistrationVM registrationVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(registrationVM), Encoding.UTF8, "application/json");
            Object entities = new Object();
            using (var response = httpClient.PostAsync(request + "Register", content).Result)
            {
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                entities = JsonConvert.DeserializeObject<Object>(apiResponse);
            }

            return entities;
        }

        //public HttpStatusCode UpdateNIK(string nik, Employee employee)
        //{
        //    StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
        //    var result = httpClient.PutAsync(request + "UpdateNIK/" + nik, content).Result;
        //    return result.StatusCode;
        //}
        public Object UpdateNIK(string nik, Employee employee)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            Object entities = new Object();
            using (var response = httpClient.PutAsync(request + "UpdateNIK/" + nik, content).Result)
            {
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                entities = JsonConvert.DeserializeObject<Object>(apiResponse);
            }

            return entities;
        }

    }
}
