using BankingSystem.Contexts;
using BankingSystem.Models;
using BankingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Repositories
{
    public class LoanRepository : IRepository<Loan>
    {
        private readonly BankingSystemContext _context;

        public LoanRepository(BankingSystemContext context)
        {
            _context = context;
        }

        public async Task Add(Loan entity)
        {
            await _context.Loans.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Loan>> GetAll()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan> GetById(int id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task Update(Loan entity)
        {
            _context.Loans.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Loan>> GetByUserId(int userId)
        {
            return await _context.Loans
                .Where(l => l.UserID == userId)
                .ToListAsync();
        }

    }
}
