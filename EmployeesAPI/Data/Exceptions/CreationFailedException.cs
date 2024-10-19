namespace EmployeesAPI.Data.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при ошибке сохранения базы данных во время добавления сотрудника.
    /// </summary>
    public class CreationFailedException : Exception
    {
        public CreationFailedException(Exception? innerException = null)
            : base(null, innerException)
        { }
    }
}
