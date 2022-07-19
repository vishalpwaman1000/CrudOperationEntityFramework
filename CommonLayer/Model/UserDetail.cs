using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [JsonIgnore]
        public DateTime dateTime { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName ="varchar(100)")]
        [Display(Name ="User Name")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }
    }

    public class InsertUserDetailRequest
    {
        public string UserName { get; set; }
        public int Age { get; set; }
    }
    public class InsertUserDetailResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
