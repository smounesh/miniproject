namespace BankingSystem.Exceptions
{
    public class EmployeeAlreadyExistsException : Exception
    {
        public EmployeeAlreadyExistsException(string employeeName, string email)
            : base($"An employee with the name '{employeeName}' or email '{email}' already exists.")
        {
        }
    }

}
