using Microsoft.Extensions.Configuration;

namespace EmployeesCLI.Services.Configuration
{
	public class ConfigurationVendor : IConfigurationVendor
	{
		private static IConfiguration _config;

		public IConfiguration Configuration { get => _config; }

		static ConfigurationVendor()
		{
			_config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();
		}
	}
}
