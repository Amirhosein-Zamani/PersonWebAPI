using Microsoft.Extensions.DependencyInjection;
using PersonWebAPI.Application.Services.Implementation;
using PersonWebAPI.Application.Services.Intrfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.DependencyInjection
{
    public static class ApplicationServiceRegistration 
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();

            return services;
        }
    }
}
