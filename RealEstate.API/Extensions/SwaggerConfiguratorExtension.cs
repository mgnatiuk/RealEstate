using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RealEstate.API.Helpers;

namespace RealEstate.API.Extensions
{
    public static class SwaggerConfiguratorExtension
    {
        public static void SetupSwaggerConfigurations(this IServiceCollection services, ConfigurationHelper configHelper)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc(configHelper.SwaggerConfigurations.Version, new OpenApiInfo
                {
                    Title = configHelper.SwaggerConfigurations.Title,
                    Version = configHelper.SwaggerConfigurations.Version,
                    Description = configHelper.SwaggerConfigurations.Description,
                    Contact = new OpenApiContact()
                    {
                        Name = configHelper.SwaggerConfigurations.Name,
                        Url = new Uri(configHelper.SwaggerConfigurations.Url)
                    }
                });
            });
        }

        public static void UseSwaggerConfigurations(this IApplicationBuilder app, ConfigurationHelper configHelper)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", configHelper.SwaggerConfigurations.Title);
            });
        }
    }
}
