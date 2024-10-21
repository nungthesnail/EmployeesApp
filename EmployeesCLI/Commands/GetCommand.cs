using EmployeesCLI.Services;

namespace EmployeesCLI.Commands
{
	/// <summary>
	/// Запрашивает у пользователя имя сотрудника, отправляет запрос API на поиск сотрудника в базе данных
	/// и отображает его данные.
	/// </summary>
	public class GetCommand : ICommand<Task>
	{
		private readonly IServiceFactory _serviceFactory = new ServiceFactory();

		public async Task Execute()
		{
			PrintPrimaryText();
			var name = RequestName();

			var apiConnector = _serviceFactory.CreateApiConnector();
			var result = await apiConnector.GetAsync(name);
			Console.WriteLine(result);
		}

		private void PrintPrimaryText()
		{
            Console.WriteLine("Просмотр данных сотрудника: ");
        }

		private string RequestName()
		{
			Console.Write("Введите имя сотрудника: ");
			return Console.ReadLine()!;
		}
	}
}
