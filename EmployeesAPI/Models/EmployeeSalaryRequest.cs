using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.Models
{
    /// <summary>
    /// Модель запроса, содержащего необходимые данные для осуществления расчета заработной платы сотрудника.
    /// </summary>
	public class EmployeeSalaryRequest
	{
        /// <summary>
        /// Имя сотрудника.
        /// </summary>
        [Required]
		public string EmployeeName { set; get; } = null!;

        /// <summary>
        /// Период, за который необходимо рассчитать заработную плату.
        /// </summary>
        [Required]
		public DatesRange Period { set; get; } = null!;
    }
}
