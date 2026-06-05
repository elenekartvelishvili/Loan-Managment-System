
using Loan_Managment_System.DTOS;
using Loan_Managment_System.Models;
using Loan_Managment_System.Repositories;
namespace Loan_Managment_System.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<Customer> CreateAsync(CreateCustomerDTO dto)
        {
            var age=DateTime.Today.Year-dto.BirthDate.Year;
            if(dto.BirthDate>DateTime.Today.AddYears(-age)) age--;
            if(age<18)
            {
                throw new ArgumentException("Customer must be at least 18 years old.");

            }
            if (await _repo.ExistsByPersonalNumber(dto.PersonalNumber)) {
                throw new ArgumentException("A customer with the same personal number already exists.");
            }
            var customer = new Customer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PersonalNumber = dto.PersonalNumber,
                BirthDate = dto.BirthDate,
                CreditScore = dto.CreditScore,
            };
            await _repo.AddAsync(customer);
            await _repo.SaveChangesAsync();
            return customer;
        }

        public Task<List<Customer>> GetAllAsync()=> _repo.GetAllAsync();
       

        public Task<Customer?> GetByIdAsync(int id)=>_repo.GetbyIdAsync(id);


        public async Task DeleteAsync(int id)
        {
            var customer=await _repo.GetbyIdAsync(id);

            if (customer==null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }

            customer.IsDeleted=true;
            await _repo.SaveChangesAsync();
        }




    }
}
