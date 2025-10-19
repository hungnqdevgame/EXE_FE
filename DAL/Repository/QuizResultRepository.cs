using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class QuizResultRepository
    {
        private readonly QuizDBContext _context;
        public QuizResultRepository(QuizDBContext context)
        {
            _context = context;
        }

        public async Task<QuizResult> CreateQuizResult(QuizResult quizResult)
        {
            var newQuizResult = new QuizResult
            {
                SessionId = quizResult.SessionId,
                Score = quizResult.Score,
                CorrectCount = quizResult.CorrectCount,
                WrongCount = quizResult.WrongCount,
                CompleteAt = DateTime.UtcNow
            };
            _context.QuizResults.Add(newQuizResult);
            await _context.SaveChangesAsync();
            return newQuizResult;
        }

        public async Task<QuizResult> GetQuizResultById(int quizResultId)
        {
            return await _context.QuizResults.FindAsync(quizResultId);
        }

        public async Task<bool> DeleteQuizResult(int quizResultId)
        {
            var quizResult = await _context.QuizResults.FindAsync(quizResultId);
            if (quizResult == null) return false;
            _context.QuizResults.Remove(quizResult);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<QuizResult> UpdateQuizResult(QuizResult quizResult)
        {
            var existingQuizResult = await _context.QuizResults.FindAsync(quizResult.Id);
            existingQuizResult.SessionId = quizResult.SessionId;
            existingQuizResult.Score = quizResult.Score;
            existingQuizResult.CorrectCount = quizResult.CorrectCount;
            existingQuizResult.WrongCount = quizResult.WrongCount;
            existingQuizResult.CompleteAt = quizResult.CompleteAt;
            await _context.SaveChangesAsync();
            return existingQuizResult;
        }
    }
}
