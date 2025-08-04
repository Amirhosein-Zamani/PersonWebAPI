using Mapster;
using PersonWebAPI.Application.DTO;
using PersonWebAPI.Application.DTO.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.Mapping
{
    public static class MapsterConfig
    {
        public static void Configure()
        {

            #region Person ---> PersonReadDTO

            TypeAdapterConfig<Person, PersonReadDto>
               .NewConfig()
               .Map(des => des.Name, src => src.Name)
               .Map(des => des.Age, src => src.Age)
               .Map(des => des.City, src => src.City)
               .Map(des => des.Email, src => src.Email)
               .Map(des => des.Address, src => src.Address)
               .Map(des => des.Mobile, src => src.Mobile)
               .Map(des => des.Groups, src => src.PersonGroups != null ? src.PersonGroups.Select(pg => pg.Group).Adapt<List<GroupDto>>()
               : new List<GroupDto>());


            #endregion Person ---> PersonReadDTO


            #region PersonEditDTO ---> Person

            TypeAdapterConfig<PersonEditDto, Person>
                .NewConfig()
                .Map(des => des.Name, src => src.Name)
               .Map(des => des.Age, src => src.Age)
               .Map(des => des.City, src => src.City)
               .Map(des => des.Email, src => src.Email)
               .Map(des => des.Address, src => src.Address)
               .Map(des => des.Mobile, src => src.Mobile)
               .Map(des => des.PersonGroups, src => src.GroupIds != null ? src.GroupIds.Select(id => new PersonGroup { GroupId = id }).ToList()
               : new List<PersonGroup>());

            #endregion PersonEditDTO ---> Person


            #region PersonCreateDTO ---> Person

            TypeAdapterConfig<PersonCreateDto, Person>
            .NewConfig()
            .Map(des => des.Name, src => src.Name)
            .Map(des => des.Mobile, src => src.Mobile)
            .Map(des => des.PersonGroups, src => src.GroupIds != null ? src.GroupIds.Select(id => new PersonGroup { GroupId = id }).ToList()
               : new List<PersonGroup>());

            #endregion PersonCreateDTO ---> Person


        }

    }
}
