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
        Task<Result<List<GetPersonDto>>> GetAllPersonAsync();

        Task<Result<GetPersonDto>> GetPersonByIdAsync(int id);

        Task<Result<Person>> AddPersonAsync(CreatePersonDto createPersonDto);

        Task<Result<Person>> EditPersonAsync(int id, EditPersonDto editPersonDto);

        Task<Result<Person>> DeletePersonAsync(int id);

    }
}
