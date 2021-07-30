using System;
namespace RealEstate.API.Helpers
{
    public class ConfigurationHelper
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public SwaggerConfigurations SwaggerConfigurations { get; set; }
    }

    public class ConnectionStrings
    {
        public string PostgreSQL { get; set; }
    }

    public class SwaggerConfigurations
    {
        public string Title { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }

}
