using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonWebAPI.Application.Services.Implementation;
using PersonWebAPI.Application.Services.Intrfaces;
using PersonWebAPI.Application.Validator;

namespace PersonWebAPI.Application.DependencyInjection
{
    public static class ApplicationServiceRegistration
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {

            services.AddValidatorsFromAssemblyContaining<PersonCreateDtoValidator>();

            services.AddValidatorsFromAssemblyContaining<PersonEditDtoValidator>();

            services.AddScoped<IPersonService, PersonService>();

            services.AddScoped<IGroupService, GroupService>();


            return services;
        }

    }
}
