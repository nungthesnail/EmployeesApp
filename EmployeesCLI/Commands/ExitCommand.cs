using EmployeesCLI.Exceptions;

namespace EmployeesCLI.Commands
{
	public class ExitCommand : ICommand<Task>
	{
		public async Task Execute()
		{
			PrintPrimaryText();
			await Task.Delay(1000);
			throw new ExitRequestedException();
		}

		private void PrintPrimaryText()
		{
			Console.WriteLine("Выход из консоли управления сотрудниками...");
		}
	}
}
