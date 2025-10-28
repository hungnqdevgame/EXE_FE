using BLL.IService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.DTO;
using System.Security.Claims;

namespace Quiz.Server.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
   
    public class SetQuizController : ControllerBase
    {
        private readonly ISetQuizService _setQuizService;
        public SetQuizController(ISetQuizService setQuizService)
        {
            _setQuizService = setQuizService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSetQuiz([FromBody] SetQuizDTO dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

           

            var setQuizId = await _setQuizService.CreateSetQuiz(userId, dto.Title, dto.Description,dto.Type);
            return Ok(new { SetQuizId = setQuizId });
        }

        [HttpGet("{setQuizId}")]
        public async Task<IActionResult> GetSetQuizById(int setQuizId)
        {
            var setQuiz = await _setQuizService.GetSetQuizById(setQuizId);
            if (setQuiz == null)
            {
                return NotFound();
            }
            return Ok(setQuiz);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSetQuiz(int setQuizId)
        {
            var result = await _setQuizService.DeleteSetQuiz(setQuizId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSetQuiz(int setQuizId, string title, string description, bool isPublic)
        {
            var result = await _setQuizService.UpdateSetQuiz(setQuizId, title, description, isPublic);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("user-setQuiz")]    
        public async Task<IActionResult> GetUserSetQuiz()
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                  ?? User.FindFirst("sub");
            if (userIdClaim == null)
                return Unauthorized();

            // Parse sang int
            if (!int.TryParse(userIdClaim.Value, out int userId))
                return Unauthorized();

            var setQuizzes = await _setQuizService.GetSetQuizzesByUserId(userId);
            return Ok(setQuizzes);
        }
    }
}
