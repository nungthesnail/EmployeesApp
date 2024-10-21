namespace EmployeesCLI.Commands
{
	/// <summary>
	/// Просит пользователя выбрать действие для выполнения.
	/// </summary>
	public class ActionSelectCommand : ICommand<int>
	{
		private const int MinCommandNumber = 1;
		private const int MaxCommandNumber = 7;

		public int Execute()
		{
			PrintPrimaryText();
			var selection = MakeChoice();
			return selection;
		}

		private void PrintPrimaryText()
		{
            Console.WriteLine("\n\n");
            Console.WriteLine("====================================================");
			Console.WriteLine("Введите номер действия, которое вы хотите совершить:");
			Console.WriteLine("1. Добавление сотрудника");
			Console.WriteLine("2. Просмотр данных сотрудника");
			Console.WriteLine("3. Просмотр данных всех сотрудников");
			Console.WriteLine("4. Обновление данных сотрудника");
			Console.WriteLine("5. Удаление сотрудника");
			Console.WriteLine("6. Рассчет заработной платы сотрудника за период");
			Console.WriteLine("7. Выход");
			Console.WriteLine("====================================================");
			Console.Write("> ");
		}

		private int MakeChoice()
		{
			int input;
            while (!Int32.TryParse(Console.ReadLine(), out input)
				|| input < MinCommandNumber
				|| input > MaxCommandNumber)
			{
				Console.WriteLine("Похоже, вы ввели некорректную команду. Пожалуйста, попробуйте еще раз.");
				Console.Write("> ");
			}

			return input;
        }
	}
}
