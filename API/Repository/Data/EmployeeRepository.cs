using API.Context;
using API.Model;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace API.Repository.Data
{
    
       
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>
        {
        public IConfiguration _configuration;
        private readonly MyContext context;
            // bool Authenticate(AuthenticateRequest registerVM);

        public EmployeeRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
                this.context = myContext;
                this._configuration = configuration;

        }

        public int Inserted(Employee employee)
        {
            int increment = context.Employees.ToList().Count;
            var nikIncrement = DateTime.Now.ToString("yyyy") + "0" + increment.ToString();
            var checkNIK = context.Employees.Any(x => x.NIK == nikIncrement);
            var checkEmail = context.Employees.Any(x => x.Email == employee.Email);
            var checkPhone = context.Employees.Any(x => x.Phone == employee.Phone);
            if (checkNIK)
            {
                return 3;
            }
            else
            {
                if (checkEmail)
                {
                    return 1;
                }
                else
                {
                    if (checkPhone)
                    {
                        return 2;
                    }
                    else
                    {
                        employee.NIK = nikIncrement;
                        context.Employees.Add(employee);
                        context.SaveChanges();
                        return 0;
                    }

                }
            }
        }

        public class Hashing
        {
            private static string GetRandomSalt()
            {
                return BCrypt.Net.BCrypt.GenerateSalt(12);
            }
            public static string HashPassword(string Password)
            {
                return BCrypt.Net.BCrypt.HashPassword( Password, GetRandomSalt());
            }
            public static bool ValidatePassword(string Password, string correctHash)
            {
                return BCrypt.Net.BCrypt.Verify(Password, correctHash);
            }
        }

        public int Register(RegisterVM registerVM)
        {
            int hasil = 1;
            int increment = context.Employees.ToList().Count;
            var nikIncrement = DateTime.Now.ToString("yyyy") + "0" + increment.ToString();
            var checkNIK = context.Employees.Any(e => e.NIK == nikIncrement);
            var checkEmail = context.Employees.Any(e => e.Email == registerVM.Email);
            var checkPhone = context.Employees.Any(e => e.Phone == registerVM.Phone);

            if (checkNIK)
            {
                hasil = 2;
            }
            else
            {
                if (checkEmail)
                {
                    hasil = 3;
                }
                else
                {
                    if (checkPhone)
                    {
                        hasil = 4;
                    }
                    else
                    {
                        var employee = new Employee
                        {
                            NIK = nikIncrement,
                            Firstname = registerVM.Firstname,
                            Lastname = registerVM.Lastname,
                            Email = registerVM.Email,
                            Salary = registerVM.Salary,
                            Phone = registerVM.Phone,
                            Gender = (Model.Gender)registerVM.Gender,
                            BirthDate = registerVM.Birthdate
                        };
                        var account = new Account
                        {
                            NIK = employee.NIK,
                            Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password)
                        };
                        var accountrole = new AccountRole
                        {
                            AccountId = employee.NIK,
                            RoleId = 3
                        };
                        var education = new Education
                        {
                            Degree = registerVM.Degree,
                            GPA = registerVM.GPA,
                            UniversityId = registerVM.UniversityId
                        };
                        context.Employees.Add(employee);
                        //myContext.SaveChanges();
                        context.Account.Add(account);
                        context.AccountRole.Add(accountrole);
                        //myContext.SaveChanges();
                        context.Education.Add(education);
                        context.SaveChanges();
                        var profiling = new Profilling
                        {
                            NIK = employee.NIK,
                            EducationId = education.EducationId
                        };
                        context.Profilling.Add(profiling);
                        context.SaveChanges();
                        hasil = 1;
                    }
                }
            }
            return hasil;

        }

        public int AssignManager(AssignManagerVM assignManagerVM)
        {
            int hasil = 1;
            var checkNIK = context.Employees.SingleOrDefault(e => e.NIK == assignManagerVM.NIK);
            var checkAccount = context.Account.SingleOrDefault(a => a.NIK == checkNIK.NIK);
            int temp = 0;

            if (checkNIK != null)
            {
                var checkAccountRole = context.AccountRole.FirstOrDefault(ar => ar.AccountId == checkNIK.NIK);
                var checkroleId = context.Roles.Where(r => r.AccountRole.Any(ar => ar.Account.NIK == assignManagerVM.NIK)).ToList();
                foreach (var item in checkroleId)
                {
                    var id = item.RoleId;
                    if (item.RoleId == 1)
                    {
                        temp += 1;
                    }
                }
                if (temp == 1)
                {
                    hasil = 2;
                }
                else
                {
                    var accountrole = new AccountRole
                    {
                        AccountId = checkNIK.NIK,
                        RoleId = 1
                    };
                    context.AccountRole.Add(accountrole);
                    //myContext.SaveChanges();
                    context.SaveChanges();
                    hasil = 1;
                }
            }
            else
            {
                hasil = 0;
            }
            return hasil;
        }
        public IEnumerable GetRegisteredData()
        {
            var query = (from employee in context.Set<Employee>()
                         join account in context.Set<Account>()
                            on employee.NIK equals account.NIK
                         join profiling in context.Set<Profilling>()
                            on account.NIK equals profiling.NIK
                         join education in context.Set<Education>()
                            on profiling.EducationId equals education.EducationId
                         join university in context.Set<University>()
                            on education.UniversityId equals university.UniversityId
                         orderby employee.Firstname
                         select new
                         {
                             employee.NIK,
                             FullName = employee.Firstname + " " + employee.Lastname,
                             employee.Email,
                             employee.Salary,
                             employee.Phone,
                             employee.BirthDate,
                             Gender = employee.Gender.ToString(),
                             education.Degree,
                             education.GPA,
                             university.Name
                         });
            return query.ToList();
        }

        //eigerloading
        public IEnumerable<object> GetRegisterDataEigerly()
        {
            var eagerloading = context.Employees
                .Include(ac => ac.Account)
                .ThenInclude(p => p.Profilling)
                .ThenInclude(e => e.Education)
                .ThenInclude(u => u.University);
            return eagerloading;
        }

        public int Update(string NIK, Employee employee)
        {

            var checkData = context.Employees.Find(NIK);
            if (checkData != null)
            {
                context.Entry(checkData).State = EntityState.Detached;
            }
            else
            {
                return 3;
            }
            if (checkData.Email == employee.Email)
            {
                if (checkData.Phone == employee.Phone)
                {
                    employee.NIK = NIK;
                    context.Entry(employee).State = EntityState.Modified;
                    context.SaveChanges();
                    return 0;
                }
                else
                {
                    var checkPhone = context.Employees.Any(x => x.Phone == employee.Phone);
                    if (checkPhone)
                    {
                        return 2;
                    }
                    else
                    {
                        employee.NIK = NIK;
                        context.Entry(employee).State = EntityState.Modified;
                        context.SaveChanges();
                        return 0;
                    }
                }
            }
            else
            {
                if (checkData.Phone == employee.Phone)
                {
                    var checkEmail = context.Employees.Any(x => x.Email == employee.Email);
                    if (checkEmail)
                    {
                        return 1;
                    }
                    else
                    {
                        employee.NIK = NIK;
                        context.Entry(employee).State = EntityState.Modified;
                        context.SaveChanges();
                        return 0;
                    }
                }
                else
                {
                    var checkEmailPhone = context.Employees.Any(x => x.Email == employee.Email && x.Phone == employee.Phone);
                    if (checkEmailPhone)
                    {
                        return 4;
                    }
                    else
                    {
                        employee.NIK = NIK;
                        context.Entry(employee).State = EntityState.Modified;
                        context.SaveChanges();
                        return 0;
                    }
                }

            }
        }

    }
}

