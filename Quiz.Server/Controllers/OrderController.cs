using DAL.IRepository;
using DAL.Model;
using DAL.Model.Momo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using NetCoreDemo.Types;
using System;

namespace Quiz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly PayOS _payOS;
       
        public OrderController(PayOS payOS )
        {
            _payOS = payOS;
           
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePaymentLink(CreatePaymentLinkRequest body, [FromServices] QuizDBContext context)
        {
            try
            {
                int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));

                ItemData item = new ItemData(body.supscriptionName, 1, body.amount);
                var items = new List<ItemData> { item };

                PaymentData paymentData = new PaymentData(
                    orderCode,
                    body.amount,
                    body.description,
                    items,
                    body.cancelUrl,
                    body.returnUrl
                );

                CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                // 💾 Lưu vào DB
                var payment = new Payment
                {
                    UserId = body.userId,
                    SubscriptionId = body.supscriptionId,
                    Amount = body.amount,
                    OrderCode = orderCode,
                    IsSuccess = false,
                    CreateAt = DateTime.UtcNow
                };

                context.Payments.Add(payment);
                await context.SaveChangesAsync();

                return Ok(new Response(0, "success", createPayment));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Ok(new Response(-1, "fail", null));
            }
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder([FromRoute] int orderId)
        {
            try
            {
                PaymentLinkInformation paymentLinkInformation = await _payOS.getPaymentLinkInformation(orderId);
                return Ok(new Response(0, "Ok", paymentLinkInformation));
            }
            catch (System.Exception exception)
            {

                Console.WriteLine(exception);
                return Ok(new Response(-1, "fail", null));
            }

        }
        [HttpPut("{orderId}")]
        public async Task<IActionResult> CancelOrder([FromRoute] int orderId)
        {
            try
            {
                PaymentLinkInformation paymentLinkInformation = await _payOS.cancelPaymentLink(orderId);
                return Ok(new Response(0, "Ok", paymentLinkInformation));
            }
            catch (System.Exception exception)
            {

                Console.WriteLine(exception);
                return Ok(new Response(-1, "fail", null));
            }

        }
        [HttpPost("confirm-webhook")]
        public async Task<IActionResult> ConfirmWebhook(ConfirmWebhook body)
        {
            try
            {
                await _payOS.confirmWebhook(body.webhook_url);
                return Ok(new Response(0, "Ok", null));
            }
            catch (System.Exception exception)
            {

                Console.WriteLine(exception);
                return Ok(new Response(-1, "fail", null));
            }

        }
    }
}
