using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Order_Management_System.Services.Services.Payment.PayPal;

namespace OrderManagementSystem.API.Controllers.Payments
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaypalPaymentController : ControllerBase
    {

        [HttpGet]
        public Task<ActionResult> CreateConnection()
        {

        }





    }
}
