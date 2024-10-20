namespace EmployeesCLI.Commands
{
	public class CommandFactory : ICommandFactory
	{
		private enum CommandEnum : int
		{
			COMMAND_CREATE = 1,
			COMMAND_GET = 2,
			COMMAND_GET_ALL = 3,
			COMMAND_UPDATE = 4,
			COMMAND_DELETE = 5,
			COMMAND_SALARY = 6,
			COMMAND_EXIT = 7
		}

		public ICommand<int> CreateActionSelectCommand() => new ActionSelectCommand();

		public ICommand<Task> CreateActionCommand(int commandNumber)
		{
			return commandNumber switch
			{
				(int)CommandEnum.COMMAND_CREATE => new CreateCommand(),
				(int)CommandEnum.COMMAND_GET => new GetCommand(),
				(int)CommandEnum.COMMAND_GET_ALL => new GetAllCommand(),
				(int)CommandEnum.COMMAND_UPDATE => new UpdateCommand(),
				(int)CommandEnum.COMMAND_DELETE => new DeleteCommand(),
				(int)CommandEnum.COMMAND_SALARY => new SalaryCommand(),
				(int)CommandEnum.COMMAND_EXIT => new ExitCommand(),
				_ => throw new InvalidOperationException("Действие с таким номером не существует.")
			};
		}
	}
}
