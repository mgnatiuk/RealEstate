using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Interfaces;
using RealEstate.Application.Services;

namespace RealEstate.API.Extensions
{
    public static class InjectServicesExtension
    {
        public static void SetupServices(this IServiceCollection services)
        {
            services.AddScoped<IEstateService, EstateService>();
            services.AddScoped<IApartmentService, ApartmentService>();
        }
    }
}
