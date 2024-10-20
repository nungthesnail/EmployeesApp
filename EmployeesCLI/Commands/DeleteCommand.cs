using EmployeesCLI.Services;

namespace EmployeesCLI.Commands
{
	public class DeleteCommand : ICommand<Task>
	{
		private readonly IServiceFactory _serviceFactory = new ServiceFactory();

		public async Task Execute()
		{
			PrintPrimaryText();
			var name = RequestName();

			var apiConnector = _serviceFactory.CreateApiConnector();
			await apiConnector.DeleteAsync(name);
			PrintSuccessText();
		}

		private void PrintPrimaryText()
		{
            Console.WriteLine("Удаление сотрудника: ");
        }

		private string RequestName()
		{
			Console.Write("Введите имя сотрудника: ");
			return Console.ReadLine()!;
		}

		private void PrintErrorText(int statusCode)
		{
			Console.WriteLine($"При удалении сотрудника произошла ошибка: {statusCode}");
		}

		private void PrintSuccessText()
		{
            Console.WriteLine("Сотрудник успешно удален.");
        }
	}
}
