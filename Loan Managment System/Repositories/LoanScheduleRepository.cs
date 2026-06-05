using Loan_Managment_System.Data;
using Loan_Managment_System.Models;
using Loan_Managment_System.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Loan_Managment_System.Repositories
{



    public class LoanScheduleRepository : ILoanScheduleRepository
    {
        private readonly LoanDbContext _context;

        public LoanScheduleRepository(LoanDbContext context)
        {
            _context = context;
        }

        public async Task<LoanSchedule?> GetByIdAsync(int id)
        {
            return await _context.LoanSchedules
                .Include(x => x.Loan)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LoanSchedule>> GetByLoanIdAsync(int loanId)
        {
            return await _context.LoanSchedules
                .Where(x => x.LoanId == loanId)
                .ToListAsync();
        }

        public async Task AddAsync(LoanSchedule schedule)
        {
            await _context.LoanSchedules.AddAsync(schedule);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}