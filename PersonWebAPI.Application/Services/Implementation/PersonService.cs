using PersonWebAPI.Application.DTO;
using PersonWebAPI.Application.Services.Intrfaces;
using PersonWebAPI.Domain.Interfaces;
using PersonWebAPI.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.Services.Implementation
{
    public class PersonService(IPersonReposirory personReposirory) : IPersonService
    {
        public async Task AddPersonAsync(CreatePersonDto personDto)
        {

            if (await personReposirory.GetPersonByMobileAsync(personDto.Mobile) != null)
            {
                throw new Exception("کاربری با این شماره موبایل قبلاً ثبت شده است!");
            }

            //if (await personReposirory.GetPersonByName(personDto.Name) != null)
            //{
            //    throw new Exception("کاربری با این نام قبلاً ثبت شده است!");
            //}

            Person person = new Person
            {
                Name = personDto.Name,
                Mobile = personDto.Mobile,
                Age = personDto.Age,
                Address = personDto.Address,
                City = personDto.City,
                Email = personDto.Email
            };

            await personReposirory.AddPersonAsync(person);
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            var person = await personReposirory.GetPersonByIdAsync(id);

            if (person != null)
            {
                await personReposirory.DeletePersonAsync(person);
                return true;
            }

            return false;

           
        }
           

        public async Task<bool> EditPersonAsync(int id, EditPersonDto editpersonDto)
        {
            var person = await personReposirory.GetPersonByIdAsync(id);

            if (person == null)
            {

                return false;
            }

            person.Name = editpersonDto.Name;
            person.Mobile = editpersonDto.Mobile;
            person.Age = editpersonDto.Age;
            person.Address = editpersonDto.Address;
            person.City = editpersonDto.City;
            person.Email = editpersonDto.Email;

            await personReposirory.UpdatePersonAsync(person);

            return true;

        }

        //public Task EditPersonAsync(int id, EditPersonDto editpersonDto)
        //{
        //    var Person = personReposirory.GetPersonByIdAsync(id);

        //    if (Person != null)
        //    {
        //     Person person = new Person
        //     {
        //         Id = id,
        //         Name = editpersonDto.Name,
        //         Mobile = editpersonDto.Mobile,
        //         Age = editpersonDto.Age,
        //         Address = editpersonDto.Address,
        //         City = editpersonDto.City,
        //         Email = editpersonDto.Email
        //     };
        //        return personReposirory.AddPersonAsync(person);
        //    }

        //    throw new Exception("شخص مورد نظر یافت نشد.");
        //}

        public async Task<List<Person>> GetAllPersonAsync()
        {
            return await personReposirory.GetAllPerson();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            var person = personReposirory.GetPersonByIdAsync(id);

            return await person;
        }
    }
}

