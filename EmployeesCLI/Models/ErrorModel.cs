namespace EmployeesCLI.Models
{
	/// <summary>
	/// Модель, описывающая ошибку, возникшую в ходе выполнения операции.
	/// </summary>
	public class ErrorModel
	{
		public Exception? Exception { get; set; }
	}
}
