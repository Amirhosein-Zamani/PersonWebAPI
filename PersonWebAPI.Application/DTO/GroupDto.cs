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
        
        public required string GroupName { get; set; }

        public string? Description { get; set; }

       
    }
}
