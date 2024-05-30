namespace BankingSystem.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("You don't have an account in the bank.")
        {
        }
    }

}
