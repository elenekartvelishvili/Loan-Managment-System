using System.Net.NetworkInformation;
using Loan_Managment_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Loan_Managment_System.StatusEnum;
using System.ComponentModel.DataAnnotations;
namespace Loan_Managment_System.Models
{
    public class Loan
    {
        
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public decimal Amount { get; set; }
        public double InterestRate { get; set; }
        public int TermMonths { get; set; }
        public decimal MonthlyPayment { get; set; }
        public LoanStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Payment>? Payments { get; set; }
        public List<LoanSchedule>? LoanSchedules { get; set; }
    }
}






