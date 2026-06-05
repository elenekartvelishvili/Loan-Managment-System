using Loan_Managment_System.DTOS;
using Loan_Managment_System.Models;

namespace Loan_Managment_System.Services
{
   
        public interface IPaymentService
        {
            Task<Payment> MakePaymentAsync(CreatePaymentDTO dto);
        }
    }

