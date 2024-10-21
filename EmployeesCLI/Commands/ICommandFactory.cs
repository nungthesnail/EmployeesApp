
namespace EmployeesCLI.Commands
{
	/// <summary>
	/// Фабрика команд.
	/// </summary>
	public interface ICommandFactory
	{
		/// <summary>
		/// Создает команду действия.
		/// </summary>
		/// <param name="commandNumber">Номер команды.</param>
		/// <returns>Созданная команда.</returns>
		ICommand<Task> CreateActionCommand(int commandNumber);

		/// <summary>
		/// Создает команду выбора действия.
		/// </summary>
		/// <returns>Созданная команда.</returns>
		ICommand<int> CreateActionSelectCommand();
	}
}