namespace BankingSystem.Exceptions
{
    public class InvalidUsernameOrPasswordException : Exception
    {
        public InvalidUsernameOrPasswordException() : base("Username or password is incorrect.")
        {
        }
    }

}
