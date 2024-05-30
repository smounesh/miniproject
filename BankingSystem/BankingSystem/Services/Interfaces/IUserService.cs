using BankingSystem.Models;
using BankingSystem.Models.DTO_s;

namespace BankingSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserLoginResponseDTO> Register(UserRegisterDTO userRegisterDTO);
        Task<UserDetailDTO> GetUserDetail(int userId);
        Task<AccountBalanceDTO> GetAccountBalance(int accountId);
        Task<IEnumerable<AccountDTO>> GetAccounts(int userId);
        Task<IEnumerable<LoanDTO>> GetLoanDetails(int userId);
        Task<IEnumerable<TransactionDTO>> GetTransactions(int accountId);
        Task<bool> DoesAccountBelongToUser(int accountId, int userId);
    }
}
