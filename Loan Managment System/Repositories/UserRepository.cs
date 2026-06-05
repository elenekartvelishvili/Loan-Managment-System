using Loan_Managment_System.Models;
using Loan_Managment_System.Data;
using Microsoft.EntityFrameworkCore;
namespace Loan_Managment_System.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly LoanDbContext _context;

        public UserRepository(LoanDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User?> GetbyUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task SaveChangesAsync()
        {
           await  _context.SaveChangesAsync();
        }
    }
}
