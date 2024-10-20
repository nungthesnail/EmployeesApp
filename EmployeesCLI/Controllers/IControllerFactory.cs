namespace EmployeesCLI.Controllers
{
	public interface IControllerFactory
	{
		IController CreateDefaultController();
	}
}