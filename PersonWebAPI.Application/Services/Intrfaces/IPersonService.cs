using PersonWebAPI.Application.DTO;
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
        Task<Result<List<Person>> GetAllPersonAsync();

        Task<Result<Person>> GetPersonByIdAsync(int id);

        Task<Result<Person>> AddPersonAsync(CreatePersonDto personDto);

        Task<Result<Person>> EditPersonAsync(int id, EditPersonDto editpersonDto);

        Task<Result<Person>> DeletePersonAsync(int id);

    }
}
