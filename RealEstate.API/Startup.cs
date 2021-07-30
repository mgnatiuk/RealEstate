using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RealEstate.API.Extensions;
using RealEstate.API.Helpers;
using RealEstate.API.Middlewares;
using RealEstate.Application.Validators;
using RealEstate.Domain.Common;
using RealEstate.Infrastructure.Data;

namespace RealEstate.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            ConfigurationHelper config = new ConfigurationHelper();
            Configuration.Bind(nameof(ConfigurationHelper), config);
            
            services.AddAutoMapper(Assembly.Load("RealEstate.Application"));

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<RealEstateSeeder>();

            services.SetupRepositories();

            services.SetupServices();

            services.AddScoped<ErrorHandlingMiddleware>();

            services.SetupDataBase(config);

            services.SetupValidators();

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Real Estate API",
                    Version = "v1",
                    Description = "API for Real Estate portal.",
                    Contact = new OpenApiContact()
                    {
                        Name = "Mykola Gnariuk",
                        Url = new System.Uri("https://mgnatiuk.github.io/")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RealEstateSeeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            seeder.Seed();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Real Estate API");
            });

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
