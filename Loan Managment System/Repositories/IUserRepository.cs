using Loan_Managment_System.Models;
namespace Loan_Managment_System.Repositories
{
    public interface IUserRepository
    {

        Task<User?> GetbyUsernameAsync (string username);
        Task AddAsync (User user);
        Task SaveChangesAsync();
    }

}
