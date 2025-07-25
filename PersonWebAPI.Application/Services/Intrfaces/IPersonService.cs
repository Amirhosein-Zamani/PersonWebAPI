using PersonWebAPI.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.Services.Intrfaces
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllPersonAsync();

        Task<Person> GetPersonByIdAsync(int id);

        Task AddPersonAsync(CreatePersonDto personDto);

        Task<bool> EditPersonAsync(int id, EditPersonDto editpersonDto);

        Task<bool> DeletePersonAsync(int id);


    }
}
