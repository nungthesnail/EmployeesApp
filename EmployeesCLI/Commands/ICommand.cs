namespace EmployeesCLI.Commands
{
	/// <summary>
	/// Команда для взаимодействия с пользователем.
	/// </summary>
	/// <typeparam name="TResult">Тип возвращаемого значения.</typeparam>
	public interface ICommand<TResult>
	{
		/// <summary>
		/// Исполняет команду.
		/// </summary>
		/// <returns>Результат команды.</returns>
		TResult Execute();
	}
}
