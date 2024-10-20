using EmployeesCLI.Models;

namespace EmployeesCLI.Services.ErrorProcessing
{
	public class ApiErrorProcessor : IErrorProcessor
	{
		public const string ErrorTypeHeaderName = "ErrorType";

		public ApiErrorModel Error { get; }

        public ApiErrorProcessor(ApiErrorModel error)
        {
            Error = error;
        }

        public void Process()
		{
			var httpResponse = Error.HttpResponse;
			var errorHeader = httpResponse.Headers
										  .FirstOrDefault(x => x.Key.ToLower() == ErrorTypeHeaderName.ToLower())
										  .Value?
										  .FirstOrDefault();

            if (IsUserError(errorHeader))
            {
                ProcessUserError(httpResponse);
            }
			else
			{
				ProcessAnotherError(httpResponse);
			}

        }

		private bool IsUserError(string? errorHeader)
		{
			return errorHeader == "UserError";
		}

		private void ProcessUserError(HttpResponseMessage httpResponse)
		{
			var message = httpResponse.Content.ReadAsStringAsync().Result;
			Console.WriteLine(message);
		}

		private void ProcessAnotherError(HttpResponseMessage httpResponse)
		{
			var message = httpResponse.Content.ReadAsStringAsync().Result;
			Console.WriteLine($"В ходе выполнения действия возникла ошибка: {httpResponse.StatusCode} - {message}");
		}
	}
}
