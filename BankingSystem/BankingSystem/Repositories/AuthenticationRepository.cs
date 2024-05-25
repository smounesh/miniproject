using BankingSystem.Models;
using BankingSystem.Repositories.Interfaces;

namespace BankingSystem.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public Task<User> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> Register(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}
