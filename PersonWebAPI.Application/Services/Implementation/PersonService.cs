using PersonWebAPI.Application.DTO;
using PersonWebAPI.Application.Services.Intrfaces;
using PersonWebAPI.Domain.Common;
using PersonWebAPI.Domain.Interfaces;
using PersonWebAPI.Domain.Common;
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
        public async Task<Result<Person>> AddPersonAsync(CreatePersonDto personDto)
        {

            var existingPerson = await personReposirory.GetPersonByMobileAsync(personDto.Mobile);

            if (existingPerson != null)
            {
                return Result<Person>.Failure("کاربری با این شماره موبایل قبلاً ثبت شده است!");
            }

            var person = new Person
            {
                Name = personDto.Name,
                Mobile = personDto.Mobile,
                Age = personDto.Age,
                Address = personDto.Address,
                City = personDto.City,
                Email = personDto.Email
            };

            await personReposirory.AddPersonAsync(person);

            return Result<Person>.Success(person);

        }

        public async Task<Result<Person>> DeletePersonAsync(int id)
        {

            var person = await personReposirory.GetPersonByIdAsync(id);

            if (person != null)
            {
                await personReposirory.DeletePersonAsync(person);

                return Result<Person>.Success(person);
            }

            return Result<Person>.Failure("کاربری با این آیدی وجود ندارد!");
        }

        public async Task<Result<Person>> EditPersonAsync(int id, EditPersonDto editpersonDto)
        {
            var person = await personReposirory.GetPersonByIdAsync(id);

            if (person != null)
            {
                person.Name = editpersonDto.Name;
                person.Mobile = editpersonDto.Mobile;
                person.Age = editpersonDto.Age;
                person.Address = editpersonDto.Address;
                person.City = editpersonDto.City;
                person.Email = editpersonDto.Email;

                await personReposirory.UpdatePersonAsync(person);

                return Result<Person>.Success(person);
            }

            return Result<Person>.Failure("کاربری با این آیدی وجود ندارد!");

        }

        public async Task<Result<List<Person>>> GetAllPersonAsync()
        {
            var People = await personReposirory.GetAllPerson();

            if (People != null && People.Any())
            {
                return Result<List<Person>>.Success(People);
            }

            return Result<List<Person>>.Failure("هیچ کاربری یافت نشد!");
        }

        public async Task<Result<Person>> GetPersonByIdAsync(int id)
        {
            var person = await personReposirory.GetPersonByIdAsync(id);

            if (person != null)
            {
                return Result<Person>.Success(person);
            }

            return Result<Person>.Failure("کاربری با این آیدی وجود ندارد!");

        }
    }
}

