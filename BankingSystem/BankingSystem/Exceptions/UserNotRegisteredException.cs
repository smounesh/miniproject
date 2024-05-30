namespace BankingSystem.Exceptions
{
    public class UserNotRegisteredException : Exception
    {
        public UserNotRegisteredException() : base("Username is not found")
        {
        }
    }

}
