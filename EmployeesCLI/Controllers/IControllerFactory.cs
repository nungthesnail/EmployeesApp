namespace EmployeesCLI.Controllers
{
	/// <summary>
	/// Фабрика контроллеров.
	/// </summary>
	public interface IControllerFactory
	{
		/// <summary>
		/// Создает контроллер по умолчанию.
		/// </summary>
		/// <returns>Контроллер по умолчанию.</returns>
		IController CreateDefaultController();
	}
}