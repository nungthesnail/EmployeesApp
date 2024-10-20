using Microsoft.Extensions.Configuration;

namespace EmployeesCLI.Services.Configuration
{
	public interface IConfigurationVendor
	{
		IConfiguration Configuration { get; }
	}
}