namespace BankingSystem.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(int id) : base($"Employee with ID {id} not found.")
        {
        }
    }

}
