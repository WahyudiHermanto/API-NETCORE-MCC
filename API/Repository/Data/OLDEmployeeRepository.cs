using API.Context;
using API.Model;
using API.Repository.Interface;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class OLDEmployeeRepository : IEmployeeRepository
    {
       private readonly MyContext myContext;
        
       public OLDEmployeeRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Register(RegisterVM registerVM)
        {
            var employee = new Employee
            {
                Firstname = registerVM.Firstname,
                Lastname = registerVM.Lastname
            };

            myContext.Employees.Add(employee);
            var ac = new Account
            {
                Password = registerVM.Password
            };

            myContext.Account.Add(ac);
            return myContext.SaveChanges();
        }



        public int Delete(string NIK)
        {
            var entity = myContext.Employees.Find(NIK);
            myContext.Remove(entity);
            var result = myContext.SaveChanges();
            return result;
            //throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            return myContext.Employees.ToList(); //get all data
        }


        public Employee Get(string NIK)
        {
            //return MyContext.Employees.Find(NIK); //atribut harus primary key
            //return MyContext.Employees.Where(e => e.NIK == NIK).SingleOrDefault();
            return myContext.Employees.Where(e => e.NIK == NIK).FirstOrDefault();
           
            //throw new NotImplementedException();
        }

      

        public int Insert(Employee employee)
        {
            var data = myContext.Employees.Find(employee.NIK);
            var findEmail = myContext.Employees.Where(e => e.Email == employee.Email).SingleOrDefault();
            var findPhone = myContext.Employees.Where(e => e.Phone == employee.Phone).SingleOrDefault();

            if(data != null)
            {
                return 1;
            }
            else if(findEmail != null)
            {
                return 2;
            }
            else if(findPhone != null)
            {
                return 3;
            }
            else
            {
                myContext.Employees.Add(employee);
                myContext.SaveChanges();
                return 0;
            }
            // myContext.Employee.Add(employee);
            //var insert =  myContext.SaveChanges(); //savechange berguna untuk menyimpan data
            // return insert;


        }

        public int Update(string NIK,Employee employee)
        {
            var checkData = myContext.Employees.AsNoTracking().Where(e => e.NIK == NIK).FirstOrDefault();

            if (checkData != null)
            {
                myContext.Entry(checkData).State = EntityState.Detached;
                employee.NIK = NIK;
                var checkDataString = checkData.Firstname + checkData.Lastname + checkData.Phone + checkData.BirthDate + checkData.Salary + checkData.Email + checkData.Gender;
                var employeeString = employee.Firstname + employee.Lastname + employee.Phone + employee.BirthDate + employee.Salary + employee.Email + employee.Gender;
                bool isTrue = checkDataString != employeeString;
                if (isTrue == true)
                {
                    if (checkData.Phone != employee.Phone)
                    {
                        if (myContext.Employees.Where(e => e.Phone == employee.Phone).FirstOrDefault() != null)
                        {
                            return 3;
                        }
                        else
                        {
                            myContext.Entry(employee).State = EntityState.Modified;
                            myContext.SaveChanges();
                            return 1;
                        }
                    }
                    else if (checkData.Email != employee.Email)
                    {
                        if (myContext.Employees.Where(e => e.Email == employee.Email).FirstOrDefault() != null)
                        {
                            return 4;
                        }
                        else
                        {
                            myContext.Entry(employee).State = EntityState.Modified;
                            myContext.SaveChanges();
                            return 1;
                        }
                    }
                    else
                    {
                        myContext.Entry(employee).State = EntityState.Modified;
                        myContext.SaveChanges();
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }

            }
            else
            {
                return 2;
            }
            //throw new NotImplementedException();
        }

        public string Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> IEmployeeRepository.Get()
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.Get(string NIK)
        {
            throw new NotImplementedException();
        }
        
    }
}
