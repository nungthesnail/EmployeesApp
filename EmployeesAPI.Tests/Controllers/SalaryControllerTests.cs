using EmployeesAPI.Controllers;
using EmployeesAPI.Models;
using EmployeesAPI.Services.Salary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmployeesAPI.Tests.Controllers
{
	public class SalaryControllerTests
	{
		[Fact]
		public async Task TestCalculateAsync_InputIsEmployeeSalaryRequest_ReturnIsOkObjectResult()
		{
			// Arrange
			var loggerMock = new Mock<ILogger<SalaryController>>();
			var salaryServiceMock = new Mock<ISalaryService>();
			salaryServiceMock.Setup(x => x.CalculateAsync(It.IsAny<EmployeeSalaryRequest>()))
							 .Returns(Task.FromResult((decimal)100000));

			SalaryController controller = new(loggerMock.Object, salaryServiceMock.Object);
			EmployeeSalaryRequest request = new();

			// Act
			var result = await controller.CalculateAsync(request);

			// Assert
			Assert.IsType<OkObjectResult>(result);
		}
	}
}
