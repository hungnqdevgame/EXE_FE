using BLL.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
