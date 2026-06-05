using Loan_Managment_System.DTOS;
using Loan_Managment_System.Models;
using Loan_Managment_System.Repositories;
using Loan_Managment_System.Services;
using Loan_Managment_System.StatusEnum;
using Moq;
namespace Tests
{
    public class LoanServiceTest
    {
        [Fact]
        public async Task CreateLoan_ShouldReturnRejected_WhenCreditScoreIsLow()
        {
            
            var customer = new Customer
            {
                Id = 1,
                CreditScore = 200
            };

            var customerRepo = new Mock<ICustomerRepository>();
            var loanRepo = new Mock<ILoanRepository>();
            var scheduleRepo = new Mock<ILoanScheduleRepository>();

            customerRepo.Setup(x => x.GetbyIdAsync(1))
                .ReturnsAsync(customer);

            var service = new LoanService(
                loanRepo.Object,
                customerRepo.Object,
                scheduleRepo.Object
            );

            var dto = new CreateLoanDTO
            {
                CustomerId = 1,
                Amount = 1000,
                TermMonths = 12
            };

            var result = await service.CreateApplicationAsync(dto);

            Assert.Equal(LoanStatus.Rejected, result.Status);
        }
    }
}

