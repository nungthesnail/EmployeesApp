namespace EmployeesCLI.Models
{
	/// <summary>
	/// Модель, описывающая ошибку запроса к API.
	/// </summary>
	public class ApiErrorModel : ErrorModel
	{
		public HttpResponseMessage HttpResponse { get; set; } = null!;
	}
}
