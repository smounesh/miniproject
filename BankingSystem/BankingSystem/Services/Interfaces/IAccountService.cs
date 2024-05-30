using BankingSystem.Models;
using BankingSystem.Models.DTO_s;

namespace BankingSystem.Services.Interfaces
{
    public interface IAccountService
    {
        Task CreateUserDetail(UserDetailCreateDTO userDetailCreateDTO);
        Task CreateAccount(AccountCreateDTO accountCreateDTO);
        Task UpdateUserDetail(UserDetailUpdateDTO userDetailUpdateDTO);
        Task UpdateAccount(AccountUpdateDTO accountUpdateDTO);
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<IEnumerable<UserDetail>> GetAllUserDetails();
        Task<Account> GetAccountById(int id);
        Task<UserDetail> GetUserDetailById(int id);
        Task EnableAccount(int accountId);
        Task DisableAccount(int accountId);
        Task CloseAccount(int accountId);
    }
}
