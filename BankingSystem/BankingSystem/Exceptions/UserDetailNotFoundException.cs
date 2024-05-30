namespace BankingSystem.Exceptions
{
    public class UserDetailNotFoundException : Exception
    {
        public UserDetailNotFoundException(int id)
            : base($"UserDetail with ID {id} was not found.")
        {
        }
    }

}
