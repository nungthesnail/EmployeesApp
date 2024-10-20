using EmployeesCLI.Exceptions;
using EmployeesCLI.Models;

namespace EmployeesCLI.Services.ErrorProcessing
{
	public class DefaultErrorProcessor : IErrorProcessor
	{
		public ErrorModel Error { get; }

        public DefaultErrorProcessor(ErrorModel error)
        {
            Error = error;
        }

        public void Process()
		{
			if (Error.Exception is AggregateException exc
				&& exc.InnerExceptions.All(x => x is ApiRequestFailedException))
			{
				ProcessApiRequestFailedException();
			}
			else
			{
				ProcessException(Error.Exception);
			}
		}

		private void ProcessApiRequestFailedException()
		{
            Console.WriteLine(
			"""
			Упс. Не удается отправить запрос API. Пожалуйста, убедитесь, что клиент командной строки настроен правильно
			и может установить соединение с API.
			""");
        }

		private void ProcessException(Exception? exc)
		{
			Console.WriteLine($"Упс. При выполнении операции произошла ошибка: {exc?.Message}");
		}
	}
}
