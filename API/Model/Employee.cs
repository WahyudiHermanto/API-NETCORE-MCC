using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("Tb_m_employee")]
    public class Employee
    {
        [Key]
        public string NIK { get; set; }
        [MinLength(5, ErrorMessage = "Firstname minimal 5 karakter")]
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 15, MinimumLength = 2, ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        //[RegularExpression(@"^\\(?(\[0-9\]{3})\\)?\[-.●\]?(\[0-9\]{3})\[-.●\]?(\[0-9\]{4})$", ErrorMessage = "The PhoneNumber field is not a valid phone number")\]
        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        [Range(100000, 100000000, ErrorMessage = "Your salary out of range")]
        [Required(ErrorMessage = "{0} is a mandatory field")]
        public int Salary { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
       
        [JsonConverter(typeof(JsonStringEnumConverter))] 
        public Gender Gender { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    
}
