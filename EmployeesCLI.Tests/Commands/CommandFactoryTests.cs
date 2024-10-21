using EmployeesCLI.Commands;

namespace EmployeesCLI.Tests.Commands
{
	public class CommandFactoryTests
	{
		[Fact]
		public void TestCreateActionSelectCommand_ResultIsActionSelectCommand()
		{
			// Arrange
			ICommandFactory factory = new CommandFactory();

			// Act
			ICommand<int> command = factory.CreateActionSelectCommand();

			// Assert
			Assert.IsType<ActionSelectCommand>(command);
		}

		[Fact]
		public void TestCreateActionCommand_InputIs1_ResultIsCreateCommand()
		{
			// Assert
			ICommandFactory factory = new CommandFactory();
			int commandNum = 1;

			// Act
			ICommand<Task> command = factory.CreateActionCommand(commandNum);

			// Assert
			Assert.IsType<CreateCommand>(command);
		}

		[Fact]
		public void TestCreateActionCommand_InputIs2_ResultIsGetCommand()
		{
			// Assert
			ICommandFactory factory = new CommandFactory();
			int commandNum = 2;

			// Act
			ICommand<Task> command = factory.CreateActionCommand(commandNum);

			// Assert
			Assert.IsType<GetCommand>(command);
		}

		[Fact]
		public void TestCreateActionCommand_InputIs3_ResultIsGetAllCommand()
		{
			// Assert
			ICommandFactory factory = new CommandFactory();
			int commandNum = 3;

			// Act
			ICommand<Task> command = factory.CreateActionCommand(commandNum);

			// Assert
			Assert.IsType<GetAllCommand>(command);
		}

		[Fact]
		public void TestCreateActionCommand_InputIs4_ResultIsUpdateCommand()
		{
			// Assert
			ICommandFactory factory = new CommandFactory();
			int commandNum = 4;

			// Act
			ICommand<Task> command = factory.CreateActionCommand(commandNum);

			// Assert
			Assert.IsType<UpdateCommand>(command);
		}

		[Fact]
		public void TestCreateActionCommand_InputIs5_ResultIsDeleteCommand()
		{
			// Assert
			ICommandFactory factory = new CommandFactory();
			int commandNum = 5;

			// Act
			ICommand<Task> command = factory.CreateActionCommand(commandNum);

			// Assert
			Assert.IsType<DeleteCommand>(command);
		}

		[Fact]
		public void TestCreateActionCommand_InputIs6_ResultIsSalaryCommand()
		{
			// Assert
			ICommandFactory factory = new CommandFactory();
			int commandNum = 6;

			// Act
			ICommand<Task> command = factory.CreateActionCommand(commandNum);

			// Assert
			Assert.IsType<SalaryCommand>(command);
		}

		[Fact]
		public void TestCreateActionCommand_InputIs7_ResultIsExitCommand()
		{
			// Assert
			ICommandFactory factory = new CommandFactory();
			int commandNum = 7;

			// Act
			ICommand<Task> command = factory.CreateActionCommand(commandNum);

			// Assert
			Assert.IsType<ExitCommand>(command);
		}
	}
}
