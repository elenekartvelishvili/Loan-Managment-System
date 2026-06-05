using Loan_Managment_System.DTOS;
namespace Loan_Managment_System.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDTO dto);
        Task<string> LoginAsync(LoginDTO dto);
    }
}
