using BankingSystem.Contexts;
using BankingSystem.Models;
using Microsoft.EntityFrameworkCore;
using BankingSystem.Repositories.Interfaces;
using BankingSystem.Models.DTO_s;

namespace BankingSystem.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly BankingSystemContext _context;

        public AccountRepository(BankingSystemContext context)
        {
            _context = context;
        }

        public async Task<Account?> GetById(int id)
        {
            return await _context.Accounts?
                .Include(a => a.UserDetail)
                .Include(a => a.CreatedBranch)
                .Include(a => a.HomeBranch)
                .FirstOrDefaultAsync(a => a.AccountNo == id);
        }

        public async Task<IEnumerable<Account>?> GetAll()
        {
            return await _context.Accounts?
                .Include(a => a.UserDetail)
                .Include(a => a.CreatedBranch)
                .Include(a => a.HomeBranch)
                .ToListAsync();
        }


        public async Task Add(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Account>> GetByUserId(int userId)
        {
            return await _context.Accounts
                .Where(a => a.UserID == userId)
                .Include(a => a.UserDetail)
                .Include(a => a.CreatedBranch)
                .Include(a => a.HomeBranch)
                .ToListAsync();
        }
    }
}
