using EmployeesCLI.Models;
using EmployeesCLI.Services;

namespace EmployeesCLI.Commands
{
	public class CreateCommand : ICommand<Task>
	{
		private readonly IServiceFactory _serviceFactory = new ServiceFactory();

		public async Task Execute()
		{
			PrintPrimaryText();
			var employee = MakeEmployee();

			var apiConnector = _serviceFactory.CreateApiConnector();
			await apiConnector.CreateAsync(employee);
			PrintSuccessText();
        }

		private void PrintPrimaryText()
		{
			Console.WriteLine("Создание сотрудника:");
		}

		private EmployeeModel MakeEmployee()
		{
			var employee = new EmployeeModel();
			employee.Name = RequestName();
			employee.Age = RequestAge();
			employee.Position = RequestPosition();
			employee.Salary = RequestSalary();
			employee.EmployeedDate = RequestEmployeedDate();

			return employee;
        }

		private string RequestName()
		{
			Console.Write("Введите имя сотрудника: ");
			return Console.ReadLine()!;
		}

		private int RequestAge()
		{
			Console.Write("Введите возраст сотрудника: ");

			int age;
			while (!Int32.TryParse(Console.ReadLine(), out age) || age < 0)
			{
                Console.WriteLine("Введен некорректный возраст сотрудника. Пожалуйста, попробуйте еще раз.");
				Console.Write("Введите возраст сотрудника: ");
			}
			return age;
		}

		private string RequestPosition()
		{
			Console.Write("Введите должность сотрудника: ");
			return Console.ReadLine()!;
		}

		private decimal RequestSalary()
		{
			Console.Write("Введите заработную плату сотрудника: ");

			decimal salary;
			while (!Decimal.TryParse(Console.ReadLine(), out salary) || salary < 0)
			{
				Console.WriteLine("Введена некорректная заработная плата сотрудника. Пожалуйста, попробуйте еще раз.");
				Console.Write("Введите заработную плату сотрудника: ");
			}
			return salary;
		}

		private DateTime RequestEmployeedDate()
		{
			Console.Write("Введите дату устройства на работу сотрудника: ");

			DateTime employeedDate;
			while (!DateTime.TryParse(Console.ReadLine(), out employeedDate))
			{
				Console.WriteLine("Введена некорректная дата устройства на работу сотрудника. Пожалуйста, попробуйте еще раз.");
				Console.Write("Введите дату устройства на работу сотрудника: ");
			}
			return employeedDate;
		}

		private void PrintSuccessText()
		{
			Console.WriteLine("Сотрудник успешно создан.");
		}
	}
}
