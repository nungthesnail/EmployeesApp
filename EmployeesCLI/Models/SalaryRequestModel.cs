namespace EmployeesCLI.Models
{
	public class SalaryRequestModel
	{
		public string EmployeeName { get; set; } = null!;
		public DatesRange Period { get; set; } = null!;
	}
}
