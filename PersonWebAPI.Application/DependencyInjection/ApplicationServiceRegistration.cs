using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonWebAPI.Application.DTO.Voucher;
using PersonWebAPI.Application.Services.Implementation;
using PersonWebAPI.Application.Services.Intrfaces;
using PersonWebAPI.Application.Validator.Person;

namespace PersonWebAPI.Application.DependencyInjection
{
    public static class ApplicationServiceRegistration
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {

            services.AddValidatorsFromAssemblyContaining<CreatePersonDtoValidator>();

            services.AddValidatorsFromAssemblyContaining<EditPersonDtoValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateVoucherDto>();

            services.AddValidatorsFromAssemblyContaining<EditVoucherDto>();

            services.AddScoped<IPersonService, PersonService>();

            services.AddScoped<IGroupService, GroupService>();

            services.AddScoped<IVoucherService, VoucherService>();


            return services;
        }

    }
}
