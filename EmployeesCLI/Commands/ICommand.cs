namespace EmployeesCLI.Commands
{
	public interface ICommand<TResult>
	{
		TResult Execute();
	}
}
