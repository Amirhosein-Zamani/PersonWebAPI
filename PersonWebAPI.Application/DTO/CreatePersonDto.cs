using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.DTO
{
    public class CreatePersonDto
    {
        public string? Name { get; set; }

        [Required(ErrorMessage = "شماره موبایل الزامی است.")]
        [MaxLength(11, ErrorMessage = "شماره موبایل نباید بیشتر از 11 رقم باشد.")]
        [MinLength(11, ErrorMessage = "شماره موبایل باید دقیقاً 11 رقم باشد.")]
        public required string Mobile { get; set; }
        public int? Age { get; set; }

        [Required(ErrorMessage = "آدرس الزامی است.")]
        public required string Address { get; set; } 
        public string? City { get; set; }
        public string? Email { get; set; }
    }
}
