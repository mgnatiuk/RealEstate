using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.API.Helpers;
using RealEstate.Infrastructure.Data;

namespace RealEstate.API.Extensions
{
    public static class DataBaseConfigurationExtension
    {
        public static void SetupDataBase(this IServiceCollection services, ConfigurationHelper configHelper)
        {
            services.AddDbContext<RealEstateDbContext>(options => options.UseNpgsql(configHelper.ConnectionStrings.PostgreSQL,
                        x => x.MigrationsAssembly("RealEstate.Migrations.Postgres")));
        }
    }
}
