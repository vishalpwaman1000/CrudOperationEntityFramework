using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class GetBookRequest
    {
        [Required]
        public int PageNumber { get; set; }

        [Required]
        public int NumberOfRecordPerPage { get; set; }
    }

    public class GetBookResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<UserDetail> data { get; set; }
    }

    
}
