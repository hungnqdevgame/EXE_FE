using BLL.IService;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.DTO;

namespace Quiz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupscriptionController : ControllerBase
    {
        private readonly ISupscriptionService _supscriptionService;
        public SupscriptionController(ISupscriptionService supscriptionService)
        {
            _supscriptionService = supscriptionService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllSubscriptions()
        {
            var subscriptions = await _supscriptionService.GetAllSubscriptionsAsync();
            return Ok(subscriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriptionById(int id)
        {
            var subscription = await _supscriptionService.GetSubscriptionByIdAsync(id);
            if (subscription == null)
                return NotFound("Subscription not found.");
            return Ok(subscription);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSubscription([FromBody] SupscriptionDTO subscription)
        {
            if (subscription == null)
                return BadRequest("Invalid subscription data.");
            var newSupscription = new Subscription
            {
                Name = subscription.Name,
                Description = subscription.Description,
                Amount = subscription.Amount
            };
            var addedSubscription = await _supscriptionService.AddSubscriptionAsync(newSupscription);
            return CreatedAtAction(nameof(GetSubscriptionById), new { id = addedSubscription.Id }, addedSubscription);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSubscription([FromBody] SupscriptionDTO subscription)
        {
            if (subscription == null || subscription.Id <= 0)
                return BadRequest("Invalid subscription data.");
            var existingSubscription = await _supscriptionService.GetSubscriptionByIdAsync(subscription.Id);
            if (existingSubscription == null)
                return NotFound("Subscription not found.");
            existingSubscription.Name = subscription.Name;
            existingSubscription.Description = subscription.Description;
            existingSubscription.Amount = subscription.Amount;
            var updatedSubscription = await _supscriptionService.UpdateSubscriptionByIdAsync(existingSubscription);
            return Ok(updatedSubscription);
        }
    }
}
