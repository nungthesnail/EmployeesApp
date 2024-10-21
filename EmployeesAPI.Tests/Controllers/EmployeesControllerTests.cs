using EmployeesAPI.Controllers;
using EmployeesAPI.Models;
using EmployeesAPI.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmployeesAPI.Tests.Controllers
{
	public class EmployeesControllerTests
	{
		[Fact]
		public async Task TestCreate_InputIsEmployeeModel_ResultIsOkResult()
		{
			// Arrange
			var loggerMock = new Mock<ILogger<EmployeesController>>();
			var repositoryMock = new Mock<IEmployeesRepository>();
			EmployeesController controller = new EmployeesController(repositoryMock.Object, loggerMock.Object);
			EmployeeModel model = new()
			{
				Name = String.Empty,
				Age = default,
				Position = String.Empty,
				Salary = default,
				EmployeedDate = default
			};

			// Act
			var result = await controller.CreateAsync(model);

			// Assert
			Assert.IsType<OkResult>(result);
		}

		[Fact]
		public async Task TestUpdate_InputIsEmployeeModel_ResultIsOkResult()
		{
			// Arrange
			var loggerMock = new Mock<ILogger<EmployeesController>>();
			var repositoryMock = new Mock<IEmployeesRepository>();
			EmployeesController controller = new EmployeesController(repositoryMock.Object, loggerMock.Object);
			EmployeeModel model = new()
			{
				Name = String.Empty,
				Age = default,
				Position = String.Empty,
				Salary = default,
				EmployeedDate = default
			};

			// Act
			var result = await controller.UpdateAsync(model);

			// Assert
			Assert.IsType<OkResult>(result);
		}

		[Fact]
		public async Task TestGet_InputIsEmployeeModel_ResultIsOkObjectResult()
		{
			// Arrange
			string employeeName = "Иван";

			var loggerMock = new Mock<ILogger<EmployeesController>>();
			var repositoryMock = new Mock<IEmployeesRepository>();
			repositoryMock.Setup(x => x.GetAsync(employeeName)).ReturnsAsync(new EmployeeModel());
			EmployeesController controller = new EmployeesController(repositoryMock.Object, loggerMock.Object);

			// Act
			var result = await controller.GetAsync(employeeName);

			// Assert
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task TestGetAll_ResultIsOkObjectResult()
		{
			// Arrange
			var loggerMock = new Mock<ILogger<EmployeesController>>();
			var repositoryMock = new Mock<IEmployeesRepository>();
			repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<EmployeeModel>());
			EmployeesController controller = new EmployeesController(repositoryMock.Object, loggerMock.Object);

			// Act
			var result = await controller.GetAllAsync();

			// Assert
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task TestDelete_InputIsEmployeeModel_ResultIsOkResult()
		{
			// Arrange
			string employeeName = "Иван";

			var loggerMock = new Mock<ILogger<EmployeesController>>();
			var repositoryMock = new Mock<IEmployeesRepository>();
			EmployeesController controller = new EmployeesController(repositoryMock.Object, loggerMock.Object);

			// Act
			var result = await controller.DeleteAsync(employeeName);

			// Assert
			Assert.IsType<OkResult>(result);
		}
	}
}
