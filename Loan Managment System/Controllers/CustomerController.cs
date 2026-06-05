using Microsoft.AspNetCore.Mvc;
using Loan_Managment_System.Services;
using Loan_Managment_System.DTOS;
using Microsoft.AspNetCore.Authorization;
namespace Loan_Managment_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILoanService _loanService;
        public CustomerController(ICustomerService customerService, ILoanService loanService)
        {
            _customerService = customerService;
            _loanService = loanService;
        }
        [HttpPost]

        public async Task<IActionResult> Create(CreateCustomerDTO dto)
        {
            var customer = await _customerService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return Ok(customer);

        }

        [HttpGet("loans")]

        public async Task<IActionResult> GetCustomerLoans([FromQuery]int customerId)
        {
            var loans = await _loanService.GetCustomerLoansAsync(customerId);
            return Ok(loans);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }
    }

}