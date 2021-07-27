using System;
namespace RealEstate.API.Helpers
{
    public class ConfigurationHelper
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings{
        public string PostgreSQL { get; set; }
    }

}
