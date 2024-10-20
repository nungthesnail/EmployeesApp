namespace EmployeesCLI.Exceptions
{
	public class ApiErrorException : Exception
	{
        public const string ResponseDataKey = "Response";

        public ApiErrorException(HttpResponseMessage httpResponse)
        {
            Data[ResponseDataKey] = httpResponse;
        }
    }
}
