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
    public class SetQuizService : ISetQuizService
    {
        private readonly ISetQuizRepository _setQuizRepository;
        public SetQuizService(ISetQuizRepository setQuizService)
        {
            _setQuizRepository = setQuizService;
        }
        public Task<int> CreateSetQuiz(int userId, string title, string description, string type)
       => _setQuizRepository.CreateSetQuiz(userId, title, description,type);

        public Task<bool> DeleteSetQuiz(int setQuizId)
      => _setQuizRepository.DeleteSetQuiz(setQuizId);

        public Task<SetQuiz?> GetSetQuizById(int setQuizId)
     => _setQuizRepository.GetSetQuizById(setQuizId);

        public Task<List<SetQuiz>> GetSetQuizzesByUserId(int userId)
       => _setQuizRepository.GetSetQuizzesByUserId(userId);

        public Task<bool> UpdateSetQuiz(int setQuizId, string title, string description, bool isPublic)
      => _setQuizRepository.UpdateSetQuiz(setQuizId, title, description, isPublic);
    }
}
