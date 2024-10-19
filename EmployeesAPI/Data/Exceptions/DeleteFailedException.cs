namespace EmployeesAPI.Data.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при ошибке удаления сотрудника из базы данных.
    /// </summary>
    public class DeleteFailedException : Exception
    {
        public DeleteFailedException(Exception? innerException = null)
            : base(null, innerException)
        { }
    }
}
