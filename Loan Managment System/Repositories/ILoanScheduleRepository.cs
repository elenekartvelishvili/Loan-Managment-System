using Loan_Managment_System.Models;

namespace Loan_Managment_System.Repositories
{
    public interface ILoanScheduleRepository
    {
        Task<LoanSchedule?> GetByIdAsync(int id);
        Task<List<LoanSchedule>> GetByLoanIdAsync(int loanId);
        Task AddAsync(LoanSchedule schedule);
        Task SaveChangesAsync();
    }
}
