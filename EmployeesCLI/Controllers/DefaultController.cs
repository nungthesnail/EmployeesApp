using EmployeesCLI.Commands;
using EmployeesCLI.Exceptions;
using EmployeesCLI.Models;
using EmployeesCLI.Services;

namespace EmployeesCLI.Controllers
{
	public class DefaultController : IController
	{
		private readonly ICommandFactory _commandFactory = new CommandFactory();
		private readonly IServiceFactory _serviceFactory = new ServiceFactory();

		public void Process()
		{
			try
			{
				var command = RequestCommand();
				var task = command.Execute();
				task.Wait();
			}
			catch (ApiErrorException exc)
			{
				HandleApiErrorException(exc);
			}
			catch (AggregateException exc)
			{
				if (exc.InnerExceptions.Any() && exc.InnerExceptions.All(x => x is ApiErrorException))
				{
					HandleApiErrorException((exc.InnerExceptions.First() as ApiErrorException)!);
				}
				else if (exc.InnerExceptions.Any() && exc.InnerExceptions.All(x => x is ExitRequestedException))
				{
					throw exc.InnerExceptions.First();
				}
				else
				{
					HandleException(exc);
				}
			}
			catch (Exception exc)
			{
				HandleException(exc);
			}

		}

		private ICommand<Task> RequestCommand()
		{
			var actionSelectCommand = _commandFactory.CreateActionSelectCommand();
			var action = actionSelectCommand.Execute();

			return _commandFactory.CreateActionCommand(action);
		}

		private void HandleApiErrorException(ApiErrorException exc)
		{
			var httpResponse = exc.Data[ApiErrorException.ResponseDataKey] as HttpResponseMessage;
			var error = new ApiErrorModel()
			{
				HttpResponse = httpResponse!
			};

			var errorProcessor = _serviceFactory.CreateErrorProcessor(error);
			errorProcessor.Process();
		}

		private void HandleException(Exception exc)
		{
			var error = new ErrorModel()
			{
				Exception = exc
			};

			var errorProcessor = _serviceFactory.CreateErrorProcessor(error);
			errorProcessor.Process();
		}
	}
}
