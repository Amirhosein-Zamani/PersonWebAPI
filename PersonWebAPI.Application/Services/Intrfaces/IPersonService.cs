using PersonWebAPI.Application.DTO.Person;
using PersonWebAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.Services.Intrfaces
{
    public interface IPersonService
    {
        Task<Result<List<PersonReadDto>>> GetAllPersonAsync();

        Task<Result<PersonReadDto>> GetPersonByIdAsync(int id);

        Task<Result<Person>> AddPersonAsync(PersonCreateDto personCreateDto);

        Task<Result<Person>> EditPersonAsync(int id, PersonEditDto personEditDto);

        Task<Result<Person>> DeletePersonAsync(int id);

    }
}
