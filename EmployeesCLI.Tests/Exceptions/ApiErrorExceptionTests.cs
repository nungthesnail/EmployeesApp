using EmployeesCLI.Exceptions;

namespace EmployeesCLI.Tests.Exceptions
{
	public class ApiErrorExceptionTests
	{
		[Fact]
		public void TestData_InputIsHttpResponseMessage_ResultIsHttpResponseMessage()
		{
			// Arrange
			HttpResponseMessage response = new();
			var exception = new ApiErrorException(response);

			// Act
			var responseFromData = exception.Data[ApiErrorException.ResponseDataKey];

			// Assert
			Assert.True(responseFromData is HttpResponseMessage);
		}
	}
}
