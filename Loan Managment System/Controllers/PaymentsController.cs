using Microsoft.AspNetCore.Mvc;
using Loan_Managment_System.Services;
using Loan_Managment_System.DTOS;
using System.Net;
namespace Loan_Managment_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController:ControllerBase
    {
       private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]

        public async Task<IActionResult> MakePaymentAsync(CreatePaymentDTO dto)
        {
            var payment = await _paymentService.MakePaymentAsync(dto);
            return Created(string.Empty, payment);
        }


    }
}
