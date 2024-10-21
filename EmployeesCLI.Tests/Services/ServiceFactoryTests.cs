using EmployeesCLI.Models;
using EmployeesCLI.Services;
using EmployeesCLI.Services.Api;
using EmployeesCLI.Services.Configuration;
using EmployeesCLI.Services.ErrorProcessing;

namespace EmployeesCLI.Tests.Services
{
    public class ServiceFactoryTests
    {
        [Fact]
        public void TestCreateConfigurationVendor_ResultIsIConfigurationVendor()
        {
            // Arrange
            IServiceFactory serviceFactory = new ServiceFactory();

            // Act
            IConfigurationVendor vendor = serviceFactory.CreateConfigurationVendor();

            // Assert
            Assert.True(vendor is IConfigurationVendor);
        }

        [Fact]
        public void TestCreateApiConnector_ResultIsIApiConnector()
        {
			// Arrange
			IServiceFactory serviceFactory = new ServiceFactory();

            // Act
            IApiConnector apiConnector = serviceFactory.CreateApiConnector();

            // Assert
            Assert.True(apiConnector is IApiConnector);
		}

        [Fact]
        public void TestCreateErrorProcessor_InputIsApiErrorModel_ResultIsApiErrorProcessor()
        {
			// Arrange
			IServiceFactory serviceFactory = new ServiceFactory();
            ApiErrorModel error = new();

            // Act
            IErrorProcessor errorProcessor = serviceFactory.CreateErrorProcessor(error);

            // Assert
            Assert.True(errorProcessor is ApiErrorProcessor);
		}

        [Fact]
        public void TestCreateErrorProcessor_InputIsErrorModel_ResultIsDefaultErrorProcessor()
		{
			// Arrange
			IServiceFactory serviceFactory = new ServiceFactory();
			ErrorModel error = new();

			// Act
			IErrorProcessor errorProcessor = serviceFactory.CreateErrorProcessor(error);

			// Assert
			Assert.True(errorProcessor is DefaultErrorProcessor);
		}

	}
}