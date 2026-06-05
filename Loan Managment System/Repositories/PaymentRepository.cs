using Loan_Managment_System.Data;
using Loan_Managment_System.Models;
using Microsoft.EntityFrameworkCore;
namespace Loan_Managment_System.Repositories
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly LoanDbContext _context;
        
        
        public PaymentRepository(LoanDbContext context)
        {
            _context = context;
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _context.Payments
                .Include(x => x.Loan)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Payment>> GetByLoanIdAsync(int loanId)
        {
            return await _context.Payments
                .Where(x => x.LoanId == loanId)
                .ToListAsync();
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
