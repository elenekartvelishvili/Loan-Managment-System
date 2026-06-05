using System.ComponentModel.DataAnnotations;

namespace Loan_Managment_System.Models
{
    public class Customer
    {

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]

        public string LastName { get; set; } = string.Empty;

        [Required]
        public string PersonalNumber { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public int CreditScore { get; set; }
        public List<Loan>? Loans { get; set; }

        public bool IsDeleted { get; set; } = false;



    }
}









