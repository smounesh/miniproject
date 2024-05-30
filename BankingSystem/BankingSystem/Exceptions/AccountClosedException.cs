namespace BankingSystem.Exceptions
{
    public class AccountClosedException : Exception
    {
        public AccountClosedException() : base()
        {
        }

        public AccountClosedException(string message) : base(message)
        {
        }

        public AccountClosedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
