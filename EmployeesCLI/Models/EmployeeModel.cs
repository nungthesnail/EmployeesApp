using System.Text;

namespace EmployeesCLI.Models
{
	/// <summary>
	/// Модель сотрудника.
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
		public string Name { get; set; } = null!;

		/// <summary>
		/// Возраст.
		/// </summary>
		public int Age { get; set; }

		/// <summary>
		/// Должность.
		/// </summary>
		public string Position { get; set; } = null!;

		/// <summary>
		/// Заработная плата.
		/// </summary>
		public decimal Salary { get; set; }

		/// <summary>
		/// Дата устройства на работу.
		/// </summary>
		public DateTime EmployeedDate { get; set; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine($"Сотрудник {Name}:");
			sb.AppendLine($"Возраст: {Age}");
			sb.AppendLine($"Должность: {Position}");
			sb.AppendLine($"Заработная плата: {Salary}");
			sb.AppendLine($"Дата устройства на работу: {EmployeedDate}");
			sb.AppendLine();
			return sb.ToString();
		}
	}
}
