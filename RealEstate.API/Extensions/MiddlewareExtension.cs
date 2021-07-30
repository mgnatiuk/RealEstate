using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.API.Middlewares;

namespace RealEstate.API.Extensions
{
    public static class MiddlewareExtension
    {
        public static void SetupCustomMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<LongTimeRequestMiddleware>();
        }

        public static void UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<LongTimeRequestMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
