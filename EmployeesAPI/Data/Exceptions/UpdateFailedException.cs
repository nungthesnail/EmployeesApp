namespace EmployeesAPI.Data.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при ошибке обновления данных сотрудников в базе данных.
    /// </summary>
    public class UpdateFailedException : Exception
    {
        public UpdateFailedException(Exception? innerException = null)
            : base(null, innerException)
        { }
    }
}
