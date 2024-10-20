namespace EmployeesCLI.Models
{
	public class ApiErrorModel : ErrorModel
	{
		public HttpResponseMessage HttpResponse { get; set; } = null!;
	}
}
