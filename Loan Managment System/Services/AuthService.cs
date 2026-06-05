using Loan_Managment_System.DTOS;
using Loan_Managment_System.Repositories;
using Loan_Managment_System.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Abstractions;
namespace Loan_Managment_System.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<string> _passwordHasher;

        public AuthService(IUserRepository userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
            _passwordHasher = new PasswordHasher<string>();
        }



        private string GenerateToken(User user)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:KEY"]!));


            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task RegisterAsync(RegisterDTO dto)
        {
            var existingUser = await _userRepo.GetbyUsernameAsync(dto.Username);
            if (existingUser != null)
            {
                throw new ArgumentException("Username already exists.");
            }
            var user = new User
            {
                Username = dto.Username

            };
            user.PasswordHash = _passwordHasher.HashPassword(dto.Username, dto.Password);

            await _userRepo.AddAsync(user);
            await _userRepo.SaveChangesAsync();
        }


        public async Task<string> LoginAsync(LoginDTO dto)
        {
            var user = await _userRepo.GetbyUsernameAsync(dto.Username);
            if (user == null)
            {

                throw new ArgumentException("Invalid username or password");

            }

            var result = _passwordHasher.VerifyHashedPassword(dto.Username, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new ArgumentException("Invalid username or password");
            }

            return GenerateToken(user);
        }


       



    }
}
