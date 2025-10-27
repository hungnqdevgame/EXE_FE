using BLL.IService;
using DAL.IRepository;
using DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Net.payOS;
using Net.payOS.Types;
using NetCoreDemo.Types;
using Share;
using System.Security.Claims;


namespace Quiz.Server.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IMomoService _momoService;
        private IPaymentRepository _paymentRepository;
        private readonly PayOS _payOS;
      //  private readonly IVnPayService _vnPayService;
        public PaymentController(IMomoService momoService,PayOS payOS,IPaymentRepository paymentRepository)
        {
            _momoService = momoService;
            _payOS = payOS;
            _paymentRepository = paymentRepository;

        }
        [HttpPost("CreatePaymentUrl")]
        public async Task<IActionResult> CreatePaymentMomo(PaymentRequest dto)
        {
            
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString))
            {
                return Unauthorized(new { Error = "User not logged in" });
            }

            var userId = int.Parse(userIdString);
            var payment = new Payment
            {
                UserId = userId,
                Amount = dto.Amount,
                IsSuccess = false,
                CreateAt = DateTime.Now
                
            };

            var response = await _momoService.CreatePaymentAsync(payment);
            return Ok(new { payUrl = response.PayUrl });
        }

        [HttpGet("PaymentCallBack")]
        public IActionResult PaymentCallback()
        {
            var response = _momoService.PaymentExcuteAsync(Request.Query);

            return Ok(response); 
        }

        [HttpPost("MomoNotify")]
        public IActionResult MomoNotify()
        {
            var response = _momoService.PaymentExcuteAsync(Request.Query);
            // TODO: xử lý cập nhật DB
            return Ok(response);
        }

        [HttpPost("payos_transfer_handler")]
        public IActionResult payOSTransferHandler(WebhookType body)
        {
            try
            {
                WebhookData data = _payOS.verifyPaymentWebhookData(body);

                if (data.description == "Ma giao dich thu nghiem" || data.description == "VQRIO123")
                {
                    return Ok(new Response(0, "Ok", null));
                }
                return Ok(new Response(0, "Ok", null));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Ok(new Response(-1, "fail", null));
            }

        }

        [HttpGet("GetAllPayments")]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentRepository.GetAllAsync();
            return Ok(payments);
        }
    }
}
