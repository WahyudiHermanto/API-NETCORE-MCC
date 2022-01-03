using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("Tb_tr_profilling")]
    public class Profilling
    {
        [Key]
        public string NIK { get; set; }
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Education Education { get; set; }
        public int EducationId { get; set; }

    }
}
