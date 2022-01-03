﻿using API.Context;
using API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using API.ViewModels;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        public IConfiguration _configuration;
        private readonly MyContext myContext;
        public AccountRepository(IConfiguration configuration, MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            this._configuration = configuration;
        }

        public string Login(LoginVM loginVM)
        {
            var hasil = "0";
            if (loginVM.Email != "" && loginVM.Password !="")
            {
                var checkEmail = myContext.Employees.SingleOrDefault(e => e.Email == loginVM.Email);
                if (checkEmail != null)
                {
                    var checkAccountPass = myContext.Account.SingleOrDefault(e => e.NIK == checkEmail.NIK);
                    bool checkPassword = BCrypt.Net.BCrypt.Verify(loginVM.Password, checkAccountPass.Password);
                    if (checkPassword)
                    {
                        var data = (
                from account in myContext.Account
                join employee in myContext.Employees
                on account.NIK equals employee.NIK
                join accountRole in myContext.AccountRole
                on account.NIK equals accountRole.AccountId
                join role in myContext.Roles
                on accountRole.RoleId equals role.RoleId
                where employee.Email == loginVM.Email
                select new
                {
                    email = employee.Email,
                    roles = role.Rolename
                });

                        var claims = new List<Claim>();
                        claims.Add(new Claim("Email", loginVM.Email));
                        foreach (var item in data)
                        {
                            //claims.Add(new Claim("email", item.email));
                            claims.Add(new Claim("roles", item.roles));
                        }
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                                    _configuration["Jwt:Issuer"],
                                    _configuration["Jwt:Audience"],
                                    claims,
                                    expires: DateTime.UtcNow.AddDays(1),
                                    signingCredentials: signIn
                                    );
                        var idtoken = new JwtSecurityTokenHandler().WriteToken(token);
                        claims.Add(new Claim("TokenSecurity", idtoken.ToString()));
                        return idtoken;
                    }
                    else
                    {
                        hasil = "2";
                        return hasil;
                    }  
                }
                else
                {
                    hasil = "3";
                    return hasil;
                }
            }
            else if(loginVM.Email == "" && loginVM.Password!="")
            {
                hasil = "4";
                return hasil;
            }
            else if (loginVM.Email != "" && loginVM.Password!="")
            {
                hasil = "5";
                return hasil;
            }
            else
            {
                hasil = "0";
                return hasil;
            }
        }
        public int ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            int hasil = 0;
            if (forgotPasswordVM.Email != "")
            {
                var cekEmail = myContext.Employees.SingleOrDefault(e => e.Email == forgotPasswordVM.Email);
                var cekAccount = myContext.Account.SingleOrDefault(e => e.NIK == cekEmail.NIK);
                Random random = new Random();
                cekAccount.OTP = random.Next(100000, 999999);
                cekAccount.Expired = DateTime.Now.AddMinutes(3);
                cekAccount.IsUsed = false;

                var fromAddress = new MailAddress("tomh7832@gmail.com");
                var passwordFrom = "tomholland123";
                var toAddress = new MailAddress(forgotPasswordVM.Email);

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, passwordFrom)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = "Forgot Password",
                    Body = "Hai, " + cekEmail.Firstname + " berikut OTP kamu yang sekarang : " + cekAccount.OTP + ". Segera lakukan Change Password.",
                }) smtp.Send(message);

                myContext.Entry(cekAccount).State = EntityState.Modified;
                myContext.SaveChanges();
                hasil = 1;
            }
            else
            {
                hasil = 2;
            }
            return hasil;
        }
        public int ChangePassword(ChangePasswordVM changePasswordVM)
        {
            int hasil = 0;
            var cekEmail = myContext.Employees.SingleOrDefault(e => e.Email == changePasswordVM.Email);
            if (changePasswordVM.Email != "")
            {
                var cekAccount = myContext.Account.SingleOrDefault(a => a.NIK == cekEmail.NIK);
                if (cekAccount.OTP == changePasswordVM.OTP)
                {
                    if (cekAccount.IsUsed == false)
                    {
                        if (cekAccount.Expired > DateTime.Now)
                        {
                            cekAccount.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordVM.NewPassword);
                            cekAccount.IsUsed = true;
                            myContext.Entry(cekAccount).State = EntityState.Modified;
                            myContext.SaveChanges();
                            hasil = 1;
                        }
                        else
                        {
                            hasil = 2;
                        }
                    }
                    else
                    {
                        hasil = 3;
                    }
                }
                else
                {
                    hasil = 4;
                }
            }
            else
            {
                hasil = 0;
            }
            return hasil;
        }
    }
}
