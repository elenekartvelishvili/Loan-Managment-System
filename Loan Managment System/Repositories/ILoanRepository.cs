using Loan_Managment_System.Models;
using Loan_Managment_System.Data;
namespace Loan_Managment_System.Repositories
{
    public interface ILoanRepository
    {
        Task<Loan?> GetByIdAsync (int id);
        Task<List<Loan>> GetAllAsync();
        Task AddAsync (Loan loan);
        Task SaveChangesAsync();

    }
}
