using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface ISetQuizRepository
    {
        public Task<int> CreateSetQuiz(int userId, string title, string description, string type);

        Task<bool> DeleteSetQuiz(int setQuizId);
        Task<SetQuiz?> GetSetQuizById(int setQuizId);
        Task<bool> UpdateSetQuiz(int setQuizId, string title, string description, bool isPublic);
        Task<List<SetQuiz>> GetSetQuizzesByUserId(int userId);
    }
}
