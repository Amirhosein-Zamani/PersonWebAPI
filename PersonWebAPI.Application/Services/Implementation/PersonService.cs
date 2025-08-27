using PersonWebAPI.Application.Services.Intrfaces;
using PersonWebAPI.Domain.Common;
using PersonWebAPI.Domain.Interfaces;
using Mapster;
using PersonWebAPI.Application.DTO.Person;

namespace PersonWebAPI.Application.Services.Implementation
{
    public class PersonService(IPersonReposirory personReposirory) : IPersonService
    {

        public async Task<Result<Person>> AddPersonAsync(CreatePersonDto createPersonDto)
        {
            var existingPerson = await personReposirory.GetPersonByMobile(createPersonDto.Mobile);

            if (existingPerson != null)
                return Result<Person>.Failure("کاربری با این شماره موبایل قبلا ثبت نام شده");

            var person = createPersonDto.Adapt<Person>();

            await personReposirory.AddPersonAsync(person);

            var dto = createPersonDto.Adapt<Person>();

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


        public async Task<Result<Person>> EditPersonAsync(int id, EditPersonDto editPersonDto)
        {
            var person = await personReposirory.GetPersonByIdAsync(id);

            if (person != null)
            {
                editPersonDto.Adapt(person);

                await personReposirory.UpdatePersonAsync(person);

                return Result<Person>.Success(person);
            }

            return Result<Person>.Failure("کاربری با این آیدی وجود ندارد!");

        }


        public async Task<Result<List<GetPersonDto>>> GetAllPersonAsync()
        {
            var People = await personReposirory.GetAllPerson();

            if (People != null && People.Any())
            {
                var dto = People.Adapt<List<GetPersonDto>>();

                return Result<List<GetPersonDto>>.Success(dto);
            }

            return Result<List<GetPersonDto>>.Failure("هیچ کاربری یافت نشد!");
        }


        public async Task<Result<GetPersonDto>> GetPersonByIdAsync(int id)
        {
            var person = await personReposirory.GetPersonByIdAsync(id);

            if (person != null)
            {
                var dto = person.Adapt<GetPersonDto>();

                return Result<GetPersonDto>.Success(dto);
            }

            return Result<GetPersonDto>.Failure("کاربری با این آیدی وجود ندارد!");

        }


    }
}

