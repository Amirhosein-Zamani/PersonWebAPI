using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Domain.Interfaces;
using PersonWebAPI.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Infra.Data.Repository
{
    public class PersonReposirory(PersonWebAPIContext context) : IPersonReposirory
    {

        public async Task AddPersonAsync(Person person)
        {
            context.Persons.Add(person);
            await context.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(Person person)
        {
             context.Persons.Remove(person);
            await context.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAllPerson()
        {
            return await context.Persons.ToListAsync();
        }

        public async Task<Person?> GetPersonByIdAsync(int id)
        {
            return await context.Persons.FirstOrDefaultAsync(p => p.ID == id);
        }

        public Task<Person?> GetPersonByMobileAsync(string mobile)
        {
            return context.Persons
                .FirstOrDefaultAsync(p => p.Mobile == mobile);
        }

        public Task<Person?> GetPersonByName(string name)
        {
            return context.Persons
                .FirstOrDefaultAsync(p => p.Name == name);
        }

        public Task UpdatePersonAsync(Person person)
        {
            context.Persons.Update(person);
            return context.SaveChangesAsync();
        }
    }
}
