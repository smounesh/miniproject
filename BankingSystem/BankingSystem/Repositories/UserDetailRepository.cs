using BankingSystem.Contexts;
using BankingSystem.Models;
using BankingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repositories
{
    public class UserDetailRepository : IRepository<UserDetail>
    {
        private readonly BankingSystemContext _context;

        public UserDetailRepository(BankingSystemContext context)
        {
            _context = context;
        }

        public async Task<UserDetail> GetById(int id)
        {
            return await _context.UserDetails
                .Include(u => u.Accounts)
                .FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<IEnumerable<UserDetail>> GetAll()
        {
            return await _context.UserDetails
                .Include(u => u.Accounts)
                .ToListAsync();
        }

        public async Task Add(UserDetail entity)
        {
            _context.UserDetails.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(UserDetail entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var userDetail = await _context.UserDetails.FindAsync(id);
            if (userDetail != null)
            {
                _context.UserDetails.Remove(userDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
