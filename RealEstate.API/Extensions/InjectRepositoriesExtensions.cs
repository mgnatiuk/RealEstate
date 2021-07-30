using System;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.API.Extensions
{
    public static class InjectRepositoriesExtensions
    {
        public static void SetupRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncGenericRepository<>), typeof(AsyncGenericRepository<>));
            services.AddScoped<IEstateRepository, EstateRepository>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
        }
    }
}
