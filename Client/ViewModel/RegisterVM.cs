using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class RegisterVM
    {
        public string NIK { get; set; }
        public string FullName { get; set; }
        //public string Lastname { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Name { get; set; }
        // public int EducationId { get; set; }
        public string Degree { get; set; }
        public float GPA { get; set; }
   
    }
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
}
