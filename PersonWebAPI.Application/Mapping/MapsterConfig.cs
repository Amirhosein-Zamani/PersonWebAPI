using Eshop.Application.Convertor;
using Mapster;
using PersonWebAPI.Application.DTO.Group;
using PersonWebAPI.Application.DTO.Person;
using PersonWebAPI.Application.DTO.Voucher;

namespace PersonWebAPI.Application.Mapping
{
    public static class MapsterConfig
    {
        public static void Configure()
        {

            #region Person ---> GetdPersonDto

            TypeAdapterConfig<Person, GetPersonDto>
               .NewConfig()
               .Map(des => des.Name, src => src.Name)
               .Map(des => des.Age, src => src.Age)
               .Map(des => des.City, src => src.City)
               .Map(des => des.Email, src => src.Email)
               .Map(des => des.Address, src => src.Address)
               .Map(des => des.Mobile, src => src.Mobile)
               .Map(des => des.Groups, src => src.PersonGroups != null ? src.PersonGroups.Select(pg => pg.Group).Adapt<List<GroupDto>>()
               : new List<GroupDto>());


            #endregion Person ---> GetdPersonDto


            #region editPersonDto ---> Person

            TypeAdapterConfig<EditPersonDto, Person>
                .NewConfig()
                .Map(des => des.PersonID, src => src.Id)
                .Map(des => des.Name, src => src.Name)
               .Map(des => des.Age, src => src.Age)
               .Map(des => des.City, src => src.City)
               .Map(des => des.Email, src => src.Email)
               .Map(des => des.Address, src => src.Address)
               .Map(des => des.Mobile, src => src.Mobile)
               .Map(des => des.PersonGroups, src => src.GroupIds != null ? src.GroupIds.Select(id => new PersonGroup { GroupId = id }).ToList()
               : new List<PersonGroup>());

            #endregion editPersonDto ---> Person


            #region CreatepersonDto ---> Person

            TypeAdapterConfig<CreatePersonDto, Person>
            .NewConfig()
            .Map(des => des.Name, src => src.Name)
            .Map(des => des.Mobile, src => src.Mobile)
            .Map(des => des.PersonGroups, src => src.GroupIds != null ? src.GroupIds.Select(id => new PersonGroup { GroupId = id }).ToList()
               : new List<PersonGroup>());

            #endregion CreatepersonDto ---> Person


            #region CreateVoucherDto ---> Voucher


            TypeAdapterConfig<CreateVoucherDto, Voucher>
                .NewConfig()
                .Map(dest => dest.PersonId, src => src.PersonId)
                .Map(dest => dest.VoucherName, src => src.VoucherName)
                .Map(dest => dest.VoucherType, src => src.VoucherType)
                .Map(dest => dest.CreditAmount, src => src.CreditAmount)
                .Map(dest => dest.DebitAmount, src => src.DebitAmount)
                .Map(dest => dest.IssuanceDate, src => src.IssuanceDate.ToShamsi())
                .Map(dest => dest.Description, src => src.Description);


            #endregion CreateVoucherDto ---> Voucher


            #region EditVoucherDto ---> Voucher


            TypeAdapterConfig<CreateVoucherDto, Voucher>
                .NewConfig()
                .Map(dest => dest.PersonId, src => src.PersonId)
                .Map(dest => dest.VoucherName, src => src.VoucherName)
                .Map(dest => dest.VoucherType, src => src.VoucherType)
                .Map(dest => dest.CreditAmount, src => src.CreditAmount)
                .Map(dest => dest.DebitAmount, src => src.DebitAmount)
                .Map(dest => dest.IssuanceDate, src => src.IssuanceDate.ToShamsi())
                .Map(dest => dest.Description, src => src.Description);


            #endregion EditVoucherDto ---> Voucher


        }

    }
}
