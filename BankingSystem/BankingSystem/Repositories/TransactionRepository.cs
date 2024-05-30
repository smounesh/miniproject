using BankingSystem.Contexts;
using BankingSystem.Models;
using BankingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BankingSystem.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private readonly BankingSystemContext _context;

        public TransactionRepository(BankingSystemContext context)
        {
            _context = context;
        }

        public async Task<Transaction> GetById(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Transaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Transaction>> GetByAccountId(int accountId)
        {
            return await _context.Transactions
                .Where(t => t.AccountID == accountId)
                .ToListAsync();
        }
    }
}
