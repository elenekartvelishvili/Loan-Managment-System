using System.ComponentModel.DataAnnotations;

namespace Loan_Managment_System.DTOS
{
    public class CreatePaymentDTO
    {
        [Required]
        public int LoanId { get; set; }

        [Range(typeof(decimal), "0.01", "1000000")]
        public decimal Amount { get; set; }
    }
}
