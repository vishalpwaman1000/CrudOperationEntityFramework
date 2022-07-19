using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class UpdateUserDetailRequest
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int Age { get; set; }
    }


    public class UpdateUserDetailsResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
