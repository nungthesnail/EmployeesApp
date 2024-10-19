using EmployeesAPI.Data.Exceptions;
using EmployeesAPI.Models;
using EmployeesAPI.Services.Salary;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SalaryController(ILogger<SalaryController> logger, ISalaryService salaryService) : ControllerBase
	{
		private readonly ILogger<SalaryController> _logger = logger;
		private readonly ISalaryService _salaryService = salaryService;

		/// <summary>
		/// Метод API, производящий расчет заработной платы сотрудника за указанный период.
		/// </summary>
		/// <param name="requestData">Данные запроса.</param>
		/// <returns>Ответ HTTP.</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ResponseCache(Duration = 60)]
		public async Task<IActionResult> CalculateAsync([FromQuery] EmployeeSalaryRequest requestData)
		{
			try
			{
				var salary = await _salaryService.CalculateAsync(requestData);
				return Ok(salary);
			}
			catch (NotFoundException)
			{
				return NotFound();
			}
			catch (InvalidOperationException exc)
			{
				return BadRequest(exc.Message);
			}
		}
	}
}
