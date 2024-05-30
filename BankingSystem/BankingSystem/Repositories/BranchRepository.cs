using BankingSystem.Contexts;
using BankingSystem.Models;
using BankingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repositories
{
    public class BranchRepository : IRepository<Branch>
    {
        private readonly BankingSystemContext _context;

        public BranchRepository(BankingSystemContext context)
        {
            _context = context;
        }

        public async Task<Branch> GetById(int branchId)
        {
            return await _context.Branches.FindAsync(branchId);
        }

        public async Task<IEnumerable<Branch>> GetAll()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task Add(Branch branch)
        {
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Branch branch)
        {
            if (_context.Entry(branch).State == EntityState.Detached)
            {
                _context.Entry(branch).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }


        public async Task Delete(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch != null)
            {
                _context.Branches.Remove(branch);
                await _context.SaveChangesAsync();
            }
        }
    }
}
