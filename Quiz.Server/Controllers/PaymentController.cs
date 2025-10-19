using BLL.IService;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Share;
using System.Security.Claims;


namespace Quiz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IMomoService _momoService;
      //  private readonly IVnPayService _vnPayService;
        public PaymentController(IMomoService momoService)
        {
            _momoService = momoService;

        }
        [HttpPost("CreatePaymentUrl")]
        public async Task<IActionResult> CreatePaymentMomo(PaymentRequest dto)
        {

            //var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (string.IsNullOrEmpty(userIdString))
            //{
            //    return Unauthorized(new { Error = "User not logged in" });
            //}

           // var userId = int.Parse(userIdString);
            var payment = new Payment
            {
                UserId = 1,
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
    }
}
