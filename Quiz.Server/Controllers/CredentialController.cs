using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Quiz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialController : ControllerBase
    {
        private readonly QuizDBContext _context;
        public CredentialController(QuizDBContext context)
        {
            _context = context;
        }

        [HttpDelete("clear-credentials")]
        public async Task<IActionResult> ClearCredentials()
        {
            var allCredentials = _context.Credentials.ToList();

            if (allCredentials.Any())
            {
                _context.Credentials.RemoveRange(allCredentials);
                await _context.SaveChangesAsync();
            }

            return Ok(new { message = "All Google credentials cleared." });
        }

        [HttpGet("get-credentials")]
        public IActionResult GetCredentials()
        {
            var credentials = _context.Credentials.ToList();
            return Ok(credentials);
        }
    }
}
