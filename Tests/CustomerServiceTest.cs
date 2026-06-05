
using Moq;
using Loan_Managment_System.Services;
using Loan_Managment_System.Repositories;
using Loan_Managment_System.DTOS;
using Loan_Managment_System.Models;

namespace Tests
{
    public class CustomerServiceTest
    {
        [Fact]

        public async Task CreateCustomer_ShouldThrowException_WhenUnder18()
        {

            var repo = new Mock<ICustomerRepository>();
            var service = new CustomerService(repo.Object);

            var dto = new CreateCustomerDTO
            {
                FirstName = "Test",
                LastName = "User",
                PersonalNumber = "1234567890",
                BirthDate = DateTime.Today.AddYears(-16),
                CreditScore = 500
            };
            await Assert.ThrowsAsync<ArgumentException>(() =>
           service.CreateAsync(dto));


        }
    }
}
