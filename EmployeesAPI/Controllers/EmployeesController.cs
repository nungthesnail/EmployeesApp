using EmployeesAPI.Data.Exceptions;
using EmployeesAPI.Models;
using EmployeesAPI.Services.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAPI.Controllers
{
	/// <summary>
	/// Контроллер, обеспечивающий операции CRUD над сотрудниками.
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeesRepository _repository;
		private readonly ILogger<EmployeesController> _logger;

		/// <summary>
		/// Контроллер, обеспечивающий операции CRUD над сотрудниками.
		/// </summary>
		/// <param name="repository">Репозиторий сотрудников.</param>
		/// <param name="logger">Логгер.</param>
		public EmployeesController(IEmployeesRepository repository, ILogger<EmployeesController> logger)
		{
			_repository = repository;
			_logger = logger;
        }

		/// <summary>
		/// Метод API, добавляющий сотрудника в базу данных.
		/// </summary>
		/// <param name="employee">Данные сотрудника</param>
		/// <returns>Ответ HTTP.</returns>
        [HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> CreateAsync([FromBody] EmployeeModel employee)
		{
			try
			{
				await _repository.CreateAsync(employee);
				return Ok();
			}
			catch (AlreadyExistsException)
			{
				AddUserErrorHeader();
				return BadRequest("Сотрудник с таким именем уже существует.");
			}
			catch (CreationFailedException exc)
			{
				_logger.LogError("Произошла ошибка при добавлении сотрудника в базу данных:\n{0}", exc);
				return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при добавлении сотрудника в базу данных.");
			}
		}

		private void AddUserErrorHeader()
		{
			Response.Headers.Append("ErrorType", "UserError");
		}

		/// <summary>
		/// Метод API, который ищет сотрудника в базе данных по имени.
		/// </summary>
		/// <param name="employeeName">Имя сотрудника.</param>
		/// <returns>Ответ HTTP.</returns>
		[HttpGet]
		[Route("{employeeName}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ResponseCache(Duration = 60)]
		public async Task<IActionResult> GetAsync([FromRoute] string employeeName)
		{
			try
			{
				var employee = await _repository.GetAsync(employeeName);
				return Ok(employee);
			}
			catch (NotFoundException)
			{
				AddUserErrorHeader();
				return NotFound("Сотрудник с таким именем не найден.");
			}
		}

		/// <summary>
		/// Метод API, позволяющий получить всех сотрудников, внесенных в базу данных.
		/// </summary>
		/// <returns>Ответ HTTP.</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ResponseCache(Duration = 60)]
		public async Task<IActionResult> GetAllAsync()
		{
			return Ok(await _repository.GetAllAsync());
		}

		/// <summary>
		/// Метод API, обновляющий данные сотрудника с указанным именем.
		/// </summary>
		/// <param name="employee">Данные сотрудника.</param>
		/// <returns>Ответ HTTP.</returns>
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> UpdateAsync([FromBody] EmployeeModel employee)
		{
			try
			{
				await _repository.UpdateAsync(employee);
				return Ok();
			}
			catch (NotFoundException)
			{
				AddUserErrorHeader();
				return NotFound("Сотрудник с таким именем не найден.");
			}
			catch (UpdateFailedException exc)
			{
				_logger.LogError("Произошла ошибка при обновлении сотрудника в базе данных:\n{0}", exc);
				return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при обновлении сотрудника в базе данных.");
			}
		}

		/// <summary>
		/// Метод API, удаляющий сотрудника из базы данных по имени.
		/// </summary>
		/// <param name="employeeName">Имя сотрудника.</param>
		/// <returns>Ответ HTTP.</returns>
		[HttpDelete]
		[Route("{employeeName}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DeleteAsync([FromRoute] string employeeName)
		{
			try
			{
				await _repository.DeleteAsync(employeeName);
				return Ok();
			}
			catch (NotFoundException)
			{
				AddUserErrorHeader();
				return NotFound("Сотрудник с таким именем не найден.");
			}
			catch (DeleteFailedException exc)
			{
				_logger.LogError("Произошла ошибка при удалении сотрудника из базы данных:\n{0}", exc);
				return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при удалении сотрудника из базы данных.");
			}
		}
	}
}
