
using Loan_Managment_System.Models;

namespace Loan_Managment_System.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetByIdAsync(int id);
        Task<List<Payment>> GetByLoanIdAsync(int loanId);
        Task AddAsync(Payment payment);
        Task SaveChangesAsync();
    }
}
