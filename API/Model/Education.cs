using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("Tb_m_education")]
    public class Education
    {
        public int EducationId { get; set; }
        public  string Degree { get; set; }
        public float GPA { get; set; }
        [JsonIgnore]
        public virtual University University { get; set; }
        public int UniversityId { get; set; }
        [JsonIgnore]
        public virtual ICollection<Profilling> Profilling { get; set; }
    }
}
