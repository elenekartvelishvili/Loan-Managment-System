using Loan_Managment_System.Models;
using Loan_Managment_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Loan_Managment_System.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly LoanDbContext _context;
        public CustomerRepository(LoanDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);

        }

        public async Task<bool> ExistsByPersonalNumber(string personalNumber)
        {
            return await _context.Customers.AnyAsync(c => c.PersonalNumber == personalNumber);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task<Customer?> GetbyIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id &&!c.IsDeleted);
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }

        
    }
}
