using API.Model;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> Get(); //Untuk get all semua data
        Employee Get(String NIK);
        int Insert(Employee employee);
        string Update(Employee employee);
        int Delete(string NIK);
        int Register(RegisterVM registerVM);
    }
}
