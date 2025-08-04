using PersonWebAPI.Application.Services.Intrfaces;
using PersonWebAPI.Domain.Common;
using PersonWebAPI.Domain.Interfaces;
using Mapster;
using PersonWebAPI.Application.DTO.Person;

namespace PersonWebAPI.Application.Services.Implementation
{
    public class PersonService(IPersonReposirory personReposirory) : IPersonService
    {
        public async Task<Result<Person>> AddPersonAsync(PersonCreateDto personCreateDto)
        {
            var existingPerson = await personReposirory.GetPersonByMobile(personCreateDto.Mobile);

            if (existingPerson != null)
            {
                return Result<Person>.Failure("کاربری با این شماره موبایل قبلا ثبت نام شده");
            }

            var person = personCreateDto.Adapt<Person>();

            await personReposirory.AddPersonAsync(person);

            var dto = personCreateDto.Adapt<Person>();

            return Result<Person>.Success(dto);

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


        public async Task<Result<Person>> EditPersonAsync(int id, PersonEditDto personEditDto)
        {
            var person = await personReposirory.GetPersonByIdAsync(id);

            if (person != null)
            {
                personEditDto.Adapt(person);

                await personReposirory.UpdatePersonAsync(person);

                return Result<Person>.Success(person);
            }

            return Result<Person>.Failure("کاربری با این آیدی وجود ندارد!");

        }


        public async Task<Result<List<PersonReadDto>>> GetAllPersonAsync()
        {

            var People = await personReposirory.GetAllPerson();

            if (People != null && People.Any())
            {
                var dto = People.Adapt<List<PersonReadDto>>();

                return Result<List<PersonReadDto>>.Success(dto);
            }

            return Result<List<PersonReadDto>>.Failure("هیچ کاربری یافت نشد!");
        }



        public async Task<Result<PersonReadDto>> GetPersonByIdAsync(int id)
        {
            var person = await personReposirory.GetPersonByIdAsync(id);

            if (person != null)
            {
                var dto = person.Adapt<PersonReadDto>();

                return Result<PersonReadDto>.Success(dto);
            }

            return Result<PersonReadDto>.Failure("کاربری با این آیدی وجود ندارد!");

        }



    }
}

