using BankingSystem.Contexts;
using BankingSystem.Models;
using BankingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly BankingSystemContext _context;

        public EmployeeRepository(BankingSystemContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetById(int employeeId)
        {
            return await _context.Employees
                .Include(e => e.Branch)
                .FirstOrDefaultAsync(e => e.EmployeeID == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.Include(e => e.Branch).ToListAsync();
        }


        public async Task Add(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

    }
}
