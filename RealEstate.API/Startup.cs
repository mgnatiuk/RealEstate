using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealEstate.API.Extensions;
using RealEstate.API.Helpers;
using RealEstate.Infrastructure.Data;

namespace RealEstate.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            ConfigurationHelper config = new ConfigurationHelper();
            Configuration.Bind(nameof(ConfigurationHelper), config);
            configHelper = config;
        }

        public IConfiguration Configuration { get; }

        public ConfigurationHelper configHelper;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.SetupDataBase(configHelper);

            services.SetupCustomMiddlewares();

            services.AddAutoMapper(Assembly.Load("RealEstate.Application"));

            services.AddScoped<RealEstateSeeder>();
 
            services.SetupRepositories();

            services.SetupServices();

            services.SetupValidators();

            services.SetupSwaggerConfigurations(configHelper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RealEstateSeeder seeder)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            seeder.Seed();

            app.UseSwaggerConfigurations(configHelper);

            app.UseCustomMiddlewares();

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
