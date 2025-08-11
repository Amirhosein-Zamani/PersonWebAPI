using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.DTO.Person
{
    public class PersonCreateDto
    {
        public required string Name { get; set; }

        public required string Mobile { get; set; }

        public List<int>? GroupIds { get; set; }
    }
}

