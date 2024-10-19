namespace EmployeesAPI.Data.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при попытке создать сотрудника с уже существующем именем.
    /// </summary>
    public class AlreadyExistsException : Exception
    { }
}
