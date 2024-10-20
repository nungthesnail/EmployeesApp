using EmployeesCLI.Models;

namespace EmployeesCLI.Services.Api
{
	public interface IApiConnector
	{
		Task CreateAsync(EmployeeModel employee);
		Task DeleteAsync(string employeeName);
		Task<EmployeeModel> GetAsync(string employeeName);
		Task<IEnumerable<EmployeeModel>> GetAllAsync();
		Task<decimal> SalaryAsync(SalaryRequestModel salaryRequest);
		Task UpdateAsync(EmployeeModel employee);
	}
}