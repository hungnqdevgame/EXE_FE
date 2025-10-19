using BLL.IService;
using DAL.IRepository;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class QuizResultService : IQuizResultService
    {
        private readonly IQuizResultRepository _quizResultRepository;
        public QuizResultService(IQuizResultRepository quizResultRepository)
        {
            _quizResultRepository = quizResultRepository;
        }
        public Task<QuizResult> CreateQuizResult(QuizResult quizResult)
       => _quizResultRepository.CreateQuizResult(quizResult);
        public Task<bool> DeleteQuizResult(int quizResultId)
       => _quizResultRepository.DeleteQuizResult(quizResultId);
        public Task<QuizResult> GetQuizResultById(int quizResultId)
       => _quizResultRepository.GetQuizResultById(quizResultId);
        public Task<QuizResult> UpdateQuizResult(QuizResult quizResult)
       => _quizResultRepository.UpdateQuizResult(quizResult);
    }
}
