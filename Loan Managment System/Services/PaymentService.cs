using Loan_Managment_System.DTOS;
using Loan_Managment_System.Models;
using Loan_Managment_System.Repositories;
using Loan_Managment_System.StatusEnum;

namespace Loan_Managment_System.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepo;
        private readonly ILoanRepository _LoanRepo;


        public PaymentService(IPaymentRepository paymentRepo, ILoanRepository loanRepo)
        {
            _paymentRepo = paymentRepo;
            _LoanRepo = loanRepo;
        }
        public async Task<Payment> MakePaymentAsync(CreatePaymentDTO dto)
        {
            var loan = await _LoanRepo.GetByIdAsync(dto.LoanId);
            if (loan == null) {
                throw new KeyNotFoundException("Loan not found");
            }
            if(loan.Status==LoanStatus.Closed) {
                throw new ArgumentException("Closed loan cannot be paid");
            }
            var payment = new Payment
            {
                LoanId = dto.LoanId,
                Amount = dto.Amount,
                PaymentDate = DateTime.UtcNow
            };

            await _paymentRepo.AddAsync(payment);
            await _paymentRepo.SaveChangesAsync();
           
            var payments=await _paymentRepo.GetByLoanIdAsync(dto.LoanId);

            var totalPaid = payments.Sum(p => p.Amount);

            if(totalPaid>=loan.Amount) {
                loan.Status=LoanStatus.Closed;
               await _LoanRepo.SaveChangesAsync();
            }

          
            return payment;


            
        }
    }
}
