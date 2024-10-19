using EmployeesAPI.Data.Exceptions;
using EmployeesAPI.Models;


namespace EmployeesAPI.Services.Repository
{
    /// <summary>
    /// Репозиторий сотрудников.
    /// </summary>
    public interface IEmployeesRepository
    {
        /// <summary>
        /// Добавляет сотрудника в базу данных.
        /// </summary>
        /// <param name="employee">Модель сотрудника.</param>
        /// <exception cref="AlreadyExistsException"></exception>
        /// <exception cref="CreationFailedException"></exception>
        Task CreateAsync(EmployeeModel employee);

        /// <summary>
        /// Ищет сотрудника в базы данных по имени.
        /// </summary>
        /// <param name="employeeName">Имя сотрудника.</param>
        /// <returns>Найденный сотрудник.</returns>
        /// <exception cref="NotFoundException"></exception>
        Task<EmployeeModel> GetAsync(string employeeName);

        /// <summary>
        /// Получает всех сотрудников из базы данных.
        /// </summary>
        /// <returns>Все сотрудники, представленные в базе данных.</returns>
        Task<IEnumerable<EmployeeModel>> GetAllAsync();

		/// <summary>
		/// Обновляет данные сотрудника в базе данных по имени.
		/// </summary>
		/// <param name="employee">Имя сотрудника.</param>
		/// <exception cref="NotFoundException"></exception>
		/// <exception cref="UpdateFailedException"></exception>
		Task UpdateAsync(EmployeeModel employee);

		/// <summary>
		/// Удаляет сотрудника из базы данных по имени.
		/// </summary>
		/// <param name="employeeName">Имя сотрудника.</param>
		/// <exception cref="NotFoundException"></exception>
		/// <exception cref="DeleteFailedException"></exception>
		Task DeleteAsync(string employeeName);
    }
}
