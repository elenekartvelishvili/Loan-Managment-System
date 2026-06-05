using Loan_Managment_System.Models;
namespace Loan_Managment_System.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetbyIdAsync (int id);
        Task<List<Customer>> GetAllAsync();
        Task AddAsync (Customer customer);
        Task <bool> ExistsByPersonalNumber (string personalNumber);
        Task SaveChangesAsync();
    }
}
