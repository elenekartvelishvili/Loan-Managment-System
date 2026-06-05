using Loan_Managment_System.DTOS;
using Loan_Managment_System.Models;

namespace Loan_Managment_System.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateAsync(CreateCustomerDTO dto);
        Task<Customer?> GetByIdAsync(int id);
        Task<List<Customer>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
