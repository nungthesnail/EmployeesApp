using EmployeesCLI.Services.Configuration;

namespace EmployeesCLI.Tests.Services.ConfigurationVendor
{
	public class ConfigurationVendorTests
	{
		[Fact]
		public void TestConfiguration_ResultIsNotNull()
		{
			// Arrange
			IConfigurationVendor vendor = new EmployeesCLI.Services.Configuration.ConfigurationVendor();

			// Act
			var config = vendor.Configuration;

			// Assert
			Assert.NotNull(config);
		}
	}
}
