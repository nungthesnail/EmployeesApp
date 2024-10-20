using EmployeesCLI.Services.Configuration;
using EmployeesCLI.Services.Api;
using EmployeesCLI.Services.ErrorProcessing;
using EmployeesCLI.Models;

namespace EmployeesCLI.Services
{
	public class ServiceFactory : IServiceFactory
	{
		public IConfigurationVendor CreateConfigurationVendor() => new ConfigurationVendor();
		public IApiConnector CreateApiConnector() => new ApiConnector();

		public IErrorProcessor CreateErrorProcessor(ErrorModel error)
		{
			if (error is ApiErrorModel apiError)
			{
				return new ApiErrorProcessor(apiError);
			}
			else
			{
				return new DefaultErrorProcessor(error);
			}
		}
	}
}
