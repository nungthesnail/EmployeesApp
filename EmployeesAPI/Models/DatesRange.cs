using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.Models
{
    /// <summary>
    /// Описывает промежуток дат.
    /// </summary>
	public class DatesRange
	{
        private DateTime _from;
        private DateTime _to;

        /// <summary>
        /// Начало промежутка.
        /// </summary>
        [Required]
		public DateTime From
        {
            get => _from;
            set => _from = value;
        }

        /// <summary>
        /// Конец промежутка.
        /// </summary>
        [Required]
		public DateTime To
        {
            get => _to;
            set => _to = value;
        }
    }
}
