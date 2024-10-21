using EmployeesCLI.Commands;
using EmployeesCLI.Exceptions;

namespace EmployeesCLI.Tests.Commands
{
	public class ExitCommandTests
	{
		[Fact]
		public async Task TestExecute_AssertThrowsExitRequestedException()
		{
			// Arrange
			ICommand<Task> command = new ExitCommand();

			// Act

			// Assert
			await Assert.ThrowsAsync<ExitRequestedException>(command.Execute);
		}
	}
}
