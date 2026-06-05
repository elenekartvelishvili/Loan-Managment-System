namespace Loan_Managment_System.Models
{
    public class LoanSchedule
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public Loan? Loan { get; set; }
        public decimal PMT { get; set; }
        public DateTime DueDate { get; set; }
    }
}
