using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.DTO.Person
{
    public class PersonEditDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Mobile { get; set; }

        public int? Age { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Email { get; set; }

        public List<int>? GroupIds { get; set; }
    }
}

