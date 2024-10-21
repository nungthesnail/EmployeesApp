using EmployeesCLI.Controllers;

namespace EmployeesCLI.Tests.Controllers
{
	public class ControllerFactoryTests
	{
		[Fact]
		public void TestCreateDefaultController_ResultIsDefaultController()
		{
			// Arrange
			IControllerFactory factory = new ControllerFactory();

			// Act
			IController controller = factory.CreateDefaultController();

			// Assert
			Assert.True(controller is DefaultController);
		}
	}
}
