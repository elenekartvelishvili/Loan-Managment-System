
using Moq;
using Loan_Managment_System.Services;
using Loan_Managment_System.Repositories;
using Loan_Managment_System.DTOS;
using Loan_Managment_System.Models;
namespace Tests
{
    public class CreateCustomerTest
    {
        [Fact]

        public async Task CreateCustomer_ShouldSucceed_WhenDataIsValid()
        {
            var repo=new Mock<ICustomerRepository>();

            repo.Setup(r=>r.ExistsByPersonalNumber(It.IsAny<string>())).ReturnsAsync(false);

            var service=new CustomerService(repo.Object);

            var dto=new CreateCustomerDTO {
                FirstName="John",
                LastName="Doe",
                PersonalNumber="1234567890",
                BirthDate=new DateTime(1990,1,1),
                CreditScore= 700
            };

            var result=await service.CreateAsync(dto);

            Assert.NotNull(result);
            Assert.Equal(dto.FirstName,result.FirstName);
            Assert.Equal(dto.LastName,result.LastName);
            Assert.Equal(dto.PersonalNumber,result.PersonalNumber);
        }
    }
}
