using Loan_Managment_System.DTOS;
using Loan_Managment_System.Services;
using Microsoft.AspNetCore.Mvc;
namespace Loan_Managment_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            await _authService.RegisterAsync(dto);
            return Ok("User registered successfully");

        }
        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var token = await _authService.LoginAsync(dto);

            return Ok(token);
        }
    }
}
