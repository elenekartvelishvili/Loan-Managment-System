using Loan_Managment_System.Models;
using System.ComponentModel.DataAnnotations;
namespace Loan_Managment_System.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Required]
        public int LoanId { get; set; }
        public Loan? Loan { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
