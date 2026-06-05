using Loan_Managment_System.DTOS;
using Microsoft.AspNetCore.Mvc;
using Loan_Managment_System.Services;
using Microsoft.AspNetCore.Authorization;
namespace Loan_Managment_System.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost("CreateApplication")]

        public async Task<IActionResult> CreateApplication(CreateLoanDTO dto)
        {
            var loan=await _loanService.CreateApplicationAsync(dto);
            return CreatedAtAction(nameof(GetLoan), new { id = loan.Id }, loan);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoan(int id)
        {
            var loan=await _loanService.GetByIdAsync(id);
            return Ok(loan);
        }


    }

}
