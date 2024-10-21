using EmployeesAPI.Services.Repository;
using EmployeesAPI.Services.Salary;
using EmployeesAPI.Models;
using Moq;

namespace EmployeesAPI.Tests.Services.Salary
{
	public class SalaryServiceTests
	{
		[Fact]
		public async Task TestCalculateAsync_InputIsIvan_20240808_20241231_ResultIs400000()
		{
			// Arrange
			var repositoryMock = new Mock<IEmployeesRepository>();
			repositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(
				new EmployeeModel()
				{
					Salary = 100000
				}
			);
			ISalaryService service = new SalaryService(repositoryMock.Object);

			EmployeeSalaryRequest request = new EmployeeSalaryRequest()
			{
				EmployeeName = "Иван",
				Period = new DatesRange()
				{
					From = DateTime.Parse("2024-08-08"),
					To = DateTime.Parse("2024-12-31")
				}
			};

			// Act
			decimal result = await service.CalculateAsync(request);

			// Assert
			Assert.Equal(400000, result);
		}

		[Fact]
		public async Task TestCalculateAsync_InputIsIvan_20241231_20240808_ThrowsInvalidOperationException()
		{
			// Arrange
			var repositoryMock = new Mock<IEmployeesRepository>();
			repositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(
				new EmployeeModel()
				{
					Salary = 100000
				}
			);
			ISalaryService service = new SalaryService(repositoryMock.Object);

			EmployeeSalaryRequest request = new EmployeeSalaryRequest()
			{
				EmployeeName = "Иван",
				Period = new DatesRange()
				{
					From = DateTime.Parse("2024-12-31"),
					To = DateTime.Parse("2024-08-08")
				}
			};

			// Act

			// Assert
			await Assert.ThrowsAsync<InvalidOperationException>(async () => await service.CalculateAsync(request));
		}
	}
}
