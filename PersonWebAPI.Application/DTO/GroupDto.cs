using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.DTO
{
    public class GroupDto
    {
        [Required]
        [MaxLength(50)]
        public required string GroupName { get; set; }

        [MaxLength(50)]
        public string? Description { get; set; }

       
    }
}
