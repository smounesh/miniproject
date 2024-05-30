public class AccountOnHoldException : Exception
{
    public AccountOnHoldException() : base()
    {
    }

    public AccountOnHoldException(string message) : base(message)
    {
    }

    public AccountOnHoldException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
