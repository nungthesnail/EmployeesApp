namespace EmployeesCLI.Models
{
	/// <summary>
	/// Модель запроса рассчета заработной платы.
	/// </summary>
	public class SalaryRequestModel
	{
		/// <summary>
		/// Имя сотрудника.
		/// </summary>
		public string EmployeeName { get; set; } = null!;

		/// <summary>
		/// Период, за который необходимо выполнить рассчет.
		/// </summary>
		public DatesRange Period { get; set; } = null!;
	}
}
