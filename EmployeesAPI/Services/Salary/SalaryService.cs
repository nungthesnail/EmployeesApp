using EmployeesAPI.Models;
using EmployeesAPI.Services.Repository;

namespace EmployeesAPI.Services.Salary
{
	/// <summary>
	/// Сервис для рассчета заработной платы сотрудника.
	/// </summary>
	public class SalaryService(IEmployeesRepository repository) : ISalaryService
	{
		private readonly IEmployeesRepository _employeesRepository = repository;

		public async Task<decimal> CalculateAsync(EmployeeSalaryRequest request)
		{
			var employee = await GetEmployeeAsync(request.EmployeeName);
			var period = CalculatePeriod(employee.EmployeedDate, request.Period);
			return CalculateSalary(employee, period);
		}

		private async Task<EmployeeModel> GetEmployeeAsync(string employeeName)
		{
			return await _employeesRepository.GetAsync(employeeName);
		}

		private TimeSpan CalculatePeriod(DateTime employeedDate, DatesRange period)
		{
			ThrowIfPeriodIsInvalid(period);

			var alteredPeriod = CutPeriod(employeedDate, period);
			return alteredPeriod.To - alteredPeriod.From;
		}

		private void ThrowIfPeriodIsInvalid(DatesRange period)
		{
			if (period.To < period.From)
				throw new InvalidOperationException("Невозможно рассчитать заработную плату для отрицательного периода.");
		}

		private DatesRange CutPeriod(DateTime employeedDate, DatesRange period)
		{
			var periodFrom = period.From < employeedDate ? employeedDate : period.From;
			var periodTo = periodFrom > period.To ? periodFrom : period.To;

			return new DatesRange
			{
				From = periodFrom,
				To = periodTo
			};
		}

		private decimal CalculateSalary(EmployeeModel employee, TimeSpan period)
		{
			var daysPerYear = 365;
			var monthsPerYear = 12;
			var averageDaysPerMonth = daysPerYear / monthsPerYear;
			var monthsCount = period.Days / averageDaysPerMonth;
			return monthsCount * employee.Salary;
		}
	}
}
