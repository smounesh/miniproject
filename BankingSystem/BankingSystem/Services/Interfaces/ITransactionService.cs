using System.Threading.Tasks;
using BankingSystem.Models;

namespace BankingSystem.Services.Interfaces
{
    public interface ITransactionService
    {
        Task Deposit(int userid, int accountId, decimal amount);
        Task Withdraw(int userid, int accountId, decimal amount);
        Task Transfer(int userid, int fromAccountId, int toAccountId, decimal amount);
    }
}
