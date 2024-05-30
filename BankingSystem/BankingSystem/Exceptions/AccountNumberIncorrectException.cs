namespace BankingSystem.Exceptions
{
    public class AccountNumberIncorrectException : Exception
    {
        public AccountNumberIncorrectException(string message) : base(message)
        {
        }
    }

}
