namespace EmployeesCLI.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при ответе от API c ошибочным кодом ответа.
    /// </summary>
	public class ApiErrorException : Exception
	{
        /// <summary>
        /// Ключ для получения информации об ответе API, инкапсулированном в свойстве Data.
        /// </summary>
        public const string ResponseDataKey = "Response";

		/// <summary>
		/// Исключение, возникающее при ответе от API c ошибочным кодом ответа.
		/// </summary>
		/// <param name="httpResponse">Информация об ответе API.</param>
		public ApiErrorException(HttpResponseMessage httpResponse)
        {
            Data[ResponseDataKey] = httpResponse;
        }
    }
}
