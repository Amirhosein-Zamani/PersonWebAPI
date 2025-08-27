using Microsoft.Extensions.DependencyInjection;
using PersonWebAPI.Domain.Interfaces;
using PersonWebAPI.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Infra.Data.DependencyInjection
{
    public static class InfraDataServiceRegistration
    {
        public static IServiceCollection AddInfraDataService(this IServiceCollection services)
        {
            services.AddScoped<IPersonReposirory, PersonReposirory>();

            services.AddScoped<IGroupRepository, GroupRepository>();

            services.AddScoped<IVoucherRepository, VoucherRepository>();

            return services;
        }
    }
}
