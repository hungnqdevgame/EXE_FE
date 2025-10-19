using BLL.IService;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.DTO;

namespace Quiz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizResultController : ControllerBase
    {
        private readonly IQuizResultService _quizResultService;
        public QuizResultController(IQuizResultService quizResultService)
        {
            _quizResultService = quizResultService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateQuizResult([FromBody] QuizResultDTO quizResult)
        {
            var newQuizResult = new QuizResult
            {
                SessionId = quizResult.SessionId,
                Score = quizResult.Score,
                CorrectCount = quizResult.CorrectCount,
                WrongCount = quizResult.WrongCount,
                CompleteAt = DateTime.UtcNow
            };
            var createdQuizResult = await _quizResultService.CreateQuizResult(newQuizResult);
            return Ok(createdQuizResult);
        }

        [HttpGet("{quizResultId}")]
        public async Task<IActionResult> GetQuizResultById(int quizResultId)
        {
            var quizResult = await _quizResultService.GetQuizResultById(quizResultId);
            if (quizResult == null)
            {
                return NotFound();
            }
            return Ok(quizResult);
        }

        [HttpDelete("delete/{quizResultId}")]
        public async Task<IActionResult> DeleteQuizResult(int quizResultId)
        {
            var result = await _quizResultService.DeleteQuizResult(quizResultId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateQuizResult(int quizResultId,[FromBody] QuizResultDTO quizResult)
        {
            var existingQuizResult = await _quizResultService.GetQuizResultById(quizResultId);

            var quizResultToUpdate = new QuizResult
            {
                Id = quizResultId,
                SessionId = quizResult.SessionId,
                Score = quizResult.Score,
                CorrectCount = quizResult.CorrectCount,
                WrongCount = quizResult.WrongCount,
                CompleteAt = quizResult.CompleteAt
            };
            var updatedQuizResult = await _quizResultService.UpdateQuizResult(quizResultToUpdate);
            if (updatedQuizResult == null)
            {
                return NotFound();
            }
            return Ok(updatedQuizResult);
        }
    }
}
