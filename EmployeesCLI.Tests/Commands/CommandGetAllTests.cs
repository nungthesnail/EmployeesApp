using EmployeesCLI.Commands;
using EmployeesCLI.Models;
using EmployeesCLI.Services;
using EmployeesCLI.Services.Api;
using Moq;

namespace EmployeesCLI.Tests.Commands
{
	public class CommandGetAllTests
	{
		[Fact]
		private async Task TestExecute_ResultDoesntThrowException()
		{
			// Arrange
			var mockServiceFactory = new Mock<IServiceFactory>();
			var apiConnectorMock = new Mock<IApiConnector>();

			apiConnectorMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult((IEnumerable<EmployeeModel>)new List<EmployeeModel>()));
			mockServiceFactory.Setup(x => x.CreateApiConnector()).Returns(apiConnectorMock.Object);
			
			ICommand<Task> command = new GetAllCommand(mockServiceFactory.Object);

			// Act
			await command.Execute();

			// Assert
		}
	}
}
