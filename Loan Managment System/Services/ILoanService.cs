using Loan_Managment_System.Models;
using Loan_Managment_System.DTOS;
namespace Loan_Managment_System.Services
{
    public interface ILoanService
    {
        Task<Loan> CreateApplicationAsync (CreateLoanDTO dto);
        Task<Loan?> GetByIdAsync(int id);
        Task<List<Loan>> GetCustomerLoansAsync(int customerId);
    }
}
