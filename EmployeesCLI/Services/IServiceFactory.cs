using EmployeesCLI.Models;
using EmployeesCLI.Services.Api;
using EmployeesCLI.Services.Configuration;
using EmployeesCLI.Services.ErrorProcessing;

namespace EmployeesCLI.Services
{
	public interface IServiceFactory
	{
		IApiConnector CreateApiConnector();
		IConfigurationVendor CreateConfigurationVendor();
		IErrorProcessor CreateErrorProcessor(ErrorModel error);
	}
}