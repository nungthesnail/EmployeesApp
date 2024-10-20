
namespace EmployeesCLI.Commands
{
	public interface ICommandFactory
	{
		ICommand<Task> CreateActionCommand(int commandNumber);
		ICommand<int> CreateActionSelectCommand();
	}
}