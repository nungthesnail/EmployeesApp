using EmployeesCLI.Models;
using EmployeesCLI.Services;

namespace EmployeesCLI.Commands
{
	/// <summary>
	/// Запрашивает у пользователя данные для рассчета зарплаты сотрудника, отправляет запрос API на рассчета заработной платы
	/// и отображает ответ.
	/// </summary>
	public class SalaryCommand : ICommand<Task>
	{
		private readonly IServiceFactory _serviceFactory = new ServiceFactory();

		public async Task Execute()
		{
			PrintPrimaryText();
			var requestData = RequestData();
			var apiConnector = _serviceFactory.CreateApiConnector();
			var result = await apiConnector.SalaryAsync(requestData);
			PrintSalary(result);
		}

		private void PrintPrimaryText()
		{
			Console.WriteLine("Рассчет заработной платы сотрудника за период:");
		}

		private SalaryRequestModel RequestData()
		{
			var result = new SalaryRequestModel();
			result.EmployeeName = RequestName();
			result.Period = new DatesRange();
			result.Period.From = RequestPeriodFrom();
			result.Period.To = RequestPeriodTo();
			return result;
		}

		private string RequestName()
		{
			Console.Write("Введите имя сотрудника: ");
			return Console.ReadLine()!;
		}

		private DateTime RequestPeriodFrom()
		{
			Console.Write("Введите начало периода, за который необходимо произвести рассчет: ");

			DateTime periodFrom;
			while (!DateTime.TryParse(Console.ReadLine(), out periodFrom))
			{
                Console.WriteLine("Похоже, дата имеет некорректный формат. Пожалуйста, попробуйте еще раз");
				Console.Write("Введите начало периода, за который необходимо произвести рассчет: ");
            }
			return periodFrom;
		}
		private DateTime RequestPeriodTo()
		{
			Console.Write("Введите конец периода: ");

			DateTime periodTo;
			while (!DateTime.TryParse(Console.ReadLine(), out periodTo))
			{
				Console.WriteLine("Похоже, дата имеет некорректный формат. Пожалуйста, попробуйте еще раз");
				Console.Write("Введите конец периода: ");
			}
			return periodTo;
		}

		private void PrintSalary(decimal salary)
		{
			Console.WriteLine($"Заработок этого сотрудника за данный период составляет {salary}");
		}
	}
}
