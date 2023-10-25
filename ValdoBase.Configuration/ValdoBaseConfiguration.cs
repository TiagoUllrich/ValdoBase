using Microsoft.Extensions.Configuration;

namespace ValdoBase.Configuration
{
    public class ValdoBaseConfiguration : IValdoBaseConfiguration
    {
        private readonly IConfiguration _configuration;

        public ValdoBaseConfiguration(IConfiguration configuration)
            => _configuration = configuration;

        public string GetConnectionString(string name)
            => _configuration.GetConnectionString(name);
    }
}