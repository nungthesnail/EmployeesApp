using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.Models
{
	/// <summary>
	/// Модель, описывающая данные сотрудника.
	/// </summary>
	public class EmployeeModel
	{
		/// <summary>
		/// Первичный ключ.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Имя сотрудника.
		/// </summary>
		[Required]
		public string Name { get; set; } = null!;

		/// <summary>
		/// Возраст.
		/// </summary>
		[Required]
		[Range(0, double.MaxValue)]
		public int Age { get; set; }

		/// <summary>
		/// Должность.
		/// </summary>
		[Required]
		public string Position { get; set; } = null!;

		/// <summary>
		/// Заработная плата.
		/// </summary>
		[Required]
		[Range(0, (double)decimal.MaxValue)]
		public decimal Salary { get; set; }

		/// <summary>
		/// Дата устройства на работу.
		/// </summary>
		[Required]
		public DateTime EmployeedDate { get; set; }
	}
}
