using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Validators;
using RealEstate.Domain.Common;

namespace RealEstate.API.Extensions
{
    public static class FluentValidatiorExtension
    {
        public static void SetupValidators(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation();

            services.AddScoped<IValidator<RequestPaginationQuery>, RequestPaginationQueryValidator>();
        }
    }
}
