using EmployeesCLI.Controllers;
using EmployeesCLI.Exceptions;

ConfigureConsole();

var controllerFactory = new ControllerFactory();
var defaultController = controllerFactory.CreateDefaultController();

Process(defaultController);

void ConfigureConsole()
{
	Console.Title = "EmployeesCLI";
	Console.WriteLine("---- Консоль управления сотрудниками ----");
}

void Process(IController controller)
{
	try
	{
		while (true)
		{
			controller.Process();
        }
	}
	catch (ExitRequestedException)
	{
		// Выход из программы.
	}
}