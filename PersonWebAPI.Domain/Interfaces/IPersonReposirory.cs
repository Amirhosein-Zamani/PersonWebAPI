using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Domain.Interfaces
{
    public interface IPersonReposirory
    {

        Task<List<Person>> GetAllPerson();

        Task<Person?> GetPersonByIdAsync(int id);

        Task<Person?> GetPersonByName(string name);

        Task<Person?> GetPersonByMobileAsync(string mobile);

        Task AddPersonAsync(Person person);

        Task UpdatePersonAsync(Person person);

        Task DeletePersonAsync(Person person);


    }
}
