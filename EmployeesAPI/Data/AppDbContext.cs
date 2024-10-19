using EmployeesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Data
{
	/// <summary>
	/// Контекст базы данных сотрудников.
	/// </summary>
	public class AppDbContext : DbContext
	{
		/// <summary>
		/// Набор сотрудников, представленных в базе данных.
		/// </summary>
		public DbSet<EmployeeModel> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var entity = modelBuilder.Entity<EmployeeModel>();

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				  .ValueGeneratedOnAdd();

			entity.Property(e => e.Name)
				  .IsRequired();

			entity.Property(e => e.Age)
				  .IsRequired();

			entity.Property(e => e.Position)
				  .IsRequired();

			entity.Property(e => e.Salary)
				  .IsRequired();

			entity.Property(e => e.EmployeedDate)
				  .IsRequired();
		}
	}
}
