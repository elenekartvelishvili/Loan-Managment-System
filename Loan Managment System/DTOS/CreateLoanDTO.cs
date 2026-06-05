using System.ComponentModel.DataAnnotations;

namespace Loan_Managment_System.DTOS
{
    public class CreateLoanDTO
    {
        [Required]
        public int CustomerId { get; set; }
        [Range(500,50000)]
        public decimal Amount { get; set; }

        [Range(6, 60)]
        public int TermMonths { get; set; }
    }
}
