using EmployeesCLI.Models;

namespace EmployeesCLI.Tests.Models
{
	public class EmployeeModelTests
	{
		[Theory]
		[InlineData("Иван", 22, "Менеджер", 70000, "2024-10-20")]
		[InlineData("София", 27, "Аналитик", 85000, "2024-09-20")]
		public void TestToString(string name, int age, string position, decimal salary, string employeedDateStr)
		{
			// Arrange
			DateTime employeedDate = DateTime.Parse(employeedDateStr);
			EmployeeModel employee = new()
			{
				Name = name,
				Age = age,
				Position = position,
				Salary = salary,
				EmployeedDate = employeedDate
			};
			
			// Act
			string representation = employee.ToString();

			// Assert
			Assert.Equal(
			$"""
			Сотрудник {name}:
			Возраст: {age}
			Должность: {position}
			Заработная плата: {salary}
			Дата устройства на работу: {employeedDate}


			""",
			representation
			);
		}
	}
}
