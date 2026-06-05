using Loan_Managment_System.Data;
using Loan_Managment_System.Models;
using Microsoft.EntityFrameworkCore;
namespace Loan_Managment_System.Repositories
{
    public class LoanRepository: ILoanRepository
    {
        private readonly LoanDbContext _context;

        public LoanRepository(LoanDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Loan loan)
        {
           await _context.Loans.AddAsync(loan);
        }

        public async Task<List<Loan>> GetAllAsync()
        {
           return await _context.Loans.Include(x=>x.Customer)
                .ToListAsync();
        }

        public async Task<Loan?> GetByIdAsync(int id)
        {
            return await _context.Loans.Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
