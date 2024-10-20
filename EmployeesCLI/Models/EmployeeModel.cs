using System.Text;

namespace EmployeesCLI.Models
{
	public class EmployeeModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int Age { get; set; }
		public string Position { get; set; } = null!;
		public decimal Salary { get; set; }
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
