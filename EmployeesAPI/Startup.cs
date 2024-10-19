using EmployeesAPI.Data;
using EmployeesAPI.Services.Repository;
using EmployeesAPI.Services.Salary;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI
{
	/// <summary>
	/// Статический класс для конфигурирования веб-приложения и конвейера обработки запросов.
	/// </summary>
	public static class Startup
	{
		/// <summary>
		/// Настраивает сервисы веб-приложения, необходимые для работы ASP.Net Core.
		/// </summary>
		/// <param name="services">Коллекция сервисов веб-приложения</param>
		public static void ConfigureDefaultServices(this WebApplicationBuilder builder)
		{
			var services = builder.Services;

			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
		}

		/// <summary>
		/// Настраивает сервисы и зависимости, необходимые для работы логики приложения.
		/// </summary>
		/// <param name="services">Коллекция сервисов веб-приложения</param>
		public static void ConfigureBusinessLogicServices(this WebApplicationBuilder builder)
		{
			var services = builder.Services;

			services.AddDbContext<AppDbContext>(options =>
			{
				var connString = builder.Configuration["ConnectionStrings:EmployeesDb"];
				var version = Version.Parse(builder.Configuration["MysqlVersion"]!);
				var mysqlVersion = new MySqlServerVersion(version); 
				options.UseMySql(connString, mysqlVersion);
			});

			services.AddMemoryCache(options => options.SizeLimit = 1024);

			services.AddTransient<IEmployeesRepository, EmployeesRepository>();
			services.AddTransient<ISalaryService, SalaryService>();
		}

		/// <summary>
		/// Настраивает конвейер обработки запросов (компоненты middlewares).
		/// </summary>
		/// <param name="app">Объект веб-приложения ASP.Net Core</param>
		public static void ConfigureMiddlewares(this WebApplication app)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();
		}
	}
}
