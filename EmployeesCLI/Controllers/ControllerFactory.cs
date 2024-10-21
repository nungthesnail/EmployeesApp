namespace EmployeesCLI.Controllers
{
	/// <summary>
	/// Фабрика контроллеров.
	/// </summary>
	public class ControllerFactory : IControllerFactory
	{
		public IController CreateDefaultController() => new DefaultController();
	}
}
