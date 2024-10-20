namespace EmployeesCLI.Controllers
{
	public class ControllerFactory : IControllerFactory
	{
		public IController CreateDefaultController() => new DefaultController();
	}
}
