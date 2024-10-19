using EmployeesAPI.Models;
using EmployeesAPI.Data.Exceptions;

namespace EmployeesAPI.Services.Salary
{
    /// <summary>
    /// Сервис для расчета заработной платы сотрудника.
    /// </summary>
    public interface ISalaryService
	{
		/// <summary>
		/// Рассчитывает заработную плату сотрудника на основании указанного периода.
		/// </summary>
		/// <param name="request">Запрос, содержащий данные, необходимые для расчета заработной платы сотрудника.</param>
		/// <returns>Заработная плата сотрудника за указанный период.</returns>
		/// <exception cref="NotFoundException"></exception>
		Task<decimal> CalculateAsync(EmployeeSalaryRequest request);
	}
}
