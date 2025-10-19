using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IQuizResultService
    {
        Task<QuizResult> CreateQuizResult(QuizResult quizResult);
        Task<QuizResult> GetQuizResultById(int quizResultId);
        Task<bool> DeleteQuizResult(int quizResultId);
        Task<QuizResult> UpdateQuizResult(QuizResult quizResult);
    }
}
