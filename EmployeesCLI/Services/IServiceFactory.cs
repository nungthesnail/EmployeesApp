using EmployeesCLI.Models;
using EmployeesCLI.Services.Api;
using EmployeesCLI.Services.Configuration;
using EmployeesCLI.Services.ErrorProcessing;

namespace EmployeesCLI.Services
{
	/// <summary>
	/// Фабрика сервисов.
	/// </summary>
	public interface IServiceFactory
	{
		/// <summary>
		/// Создает коннектор к API.
		/// </summary>
		/// <returns>Коннектор API.</returns>
		IApiConnector CreateApiConnector();

		/// <summary>
		/// Создает поставщик конфигурации.
		/// </summary>
		/// <returns>Поставщик конфигурации.</returns>
		IConfigurationVendor CreateConfigurationVendor();

		/// <summary>
		/// Создает обработчик ошибок.
		/// </summary>
		/// <param name="error">Модель ошибки.</param>
		/// <returns>Обработчик ошибок.</returns>
		IErrorProcessor CreateErrorProcessor(ErrorModel error);
	}
}