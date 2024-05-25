using BankingSystem.Models;
using BankingSystem.Repositories.Interfaces;


namespace BankingSystem.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task<Transaction> Deposit(int accountId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetTransactions(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> Transfer(int fromAccountId, int toAccountId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> Withdraw(int accountId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
