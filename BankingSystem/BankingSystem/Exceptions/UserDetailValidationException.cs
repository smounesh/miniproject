using System.Runtime.Serialization;

namespace BankingSystem.Exceptions
{
    [Serializable]
    internal class UserDetailValidationException : Exception
    {
        public UserDetailValidationException()
        {
        }

        public UserDetailValidationException(string? message) : base(message)
        {
        }

        public UserDetailValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserDetailValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}