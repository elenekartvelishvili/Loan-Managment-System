using Loan_Managment_System.DTOS;
using Loan_Managment_System.Models;
using Loan_Managment_System.Repositories;
using Loan_Managment_System.StatusEnum;

namespace Loan_Managment_System.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _LoanRepo;
        private readonly ICustomerRepository _CustomerRepo;
        private readonly ILoanScheduleRepository _ScheduleRepo;

        public LoanService(ILoanRepository loanRepo, ICustomerRepository customerRepo, ILoanScheduleRepository scheduleRepo)
        {
            _LoanRepo = loanRepo;
            _CustomerRepo = customerRepo;
            _ScheduleRepo = scheduleRepo;
        }
        public async Task<Loan> CreateApplicationAsync(CreateLoanDTO dto)
        {
           var customer=await _CustomerRepo.GetbyIdAsync(dto.CustomerId);
           if(customer==null)
           {
                throw new KeyNotFoundException("Customer not found");
            }

            LoanStatus status = customer.CreditScore < 300 ? LoanStatus.Rejected : LoanStatus.Approved;

            var monthlyRate = 0.10 / 12;
            var monthlyPayment = dto.Amount *
                (decimal)(monthlyRate / (1 - Math.Pow(1 + monthlyRate, -dto.TermMonths)));

            var loan = new Loan
            {
                CustomerId = dto.CustomerId,
                Amount = dto.Amount,
                InterestRate = 10,
                TermMonths = dto.TermMonths,
                MonthlyPayment = monthlyPayment,
                Status = status,
                CreatedAt = DateTime.UtcNow
            };

            await _LoanRepo.AddAsync(loan);
            await _LoanRepo.SaveChangesAsync();

            for(int i=1;i<=dto.TermMonths;i++)
            {
                await _ScheduleRepo.AddAsync(new LoanSchedule
                {
                    LoanId = loan.Id,
                    PMT = monthlyPayment,
                    DueDate = DateTime.UtcNow.AddMonths(i)
                });
            }
            await _ScheduleRepo.SaveChangesAsync();
            return loan;
        }


        public Task<Loan?> GetByIdAsync(int id)=>_LoanRepo.GetByIdAsync(id);
        
        public async Task<List<Loan>> GetCustomerLoansAsync(int customerId)
        {
           var loans= await _LoanRepo.GetAllAsync();
           return loans.Where(l=>l.CustomerId==customerId).ToList();
        }
    }
}
