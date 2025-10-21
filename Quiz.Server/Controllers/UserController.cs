using BLL.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.DTO;

namespace Quiz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }
            return Ok(user);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSubscriptionStatus(UpdateSubscriptionDTO dto)
        {
            var result = await _userService.UpdateSupscriptionStatus(dto.UserId, dto.SubscriptionId);
            if (!result)
            {
                return NotFound(new { Message = "User not found or update failed" });
            }
            return Ok(new { Message = "Subscription updated successfully" });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
