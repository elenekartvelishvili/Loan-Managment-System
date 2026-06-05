using System.ComponentModel.DataAnnotations;
namespace Loan_Managment_System.DTOS
{
    public class CreateCustomerDTO
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string PersonalNumber { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }
        public int CreditScore { get; set; }



    }
}
