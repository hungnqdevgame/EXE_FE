using DAL.IRepository;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SetQuizRepository : ISetQuizRepository
    {
        private readonly QuizDBContext _context;
        public SetQuizRepository(QuizDBContext context)
        {
            _context = context;
        }
        public async Task<int> CreateSetQuiz(int userId, string title, string description, string type)
        {
            
            var newSetQuiz = new SetQuiz
            {
                CreateBy = userId,
                Title = title,
                Description = description,
                CreatedAt = DateTime.UtcNow,
                Type = type,
                IsDeleted = false,
                IsPublic = false
            };
            _context.SetQuizzes.Add(newSetQuiz);
            await _context.SaveChangesAsync();
            return newSetQuiz.Id;
        }

        public async Task<SetQuiz?> GetSetQuizById(int setQuizId)
        {
            return await _context.SetQuizzes.FindAsync(setQuizId);
        }

        public async Task<bool> DeleteSetQuiz(int setQuizId)
        {
            var setQuiz = await _context.SetQuizzes.FindAsync(setQuizId);
            if (setQuiz == null)
            {
                return false;
            }
            setQuiz.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSetQuiz(int setQuizId, string title, string description, bool isPublic)
        {
            var setQuiz = await _context.SetQuizzes.FindAsync(setQuizId);
            if (setQuiz == null)
            {
                return false;
            }
            setQuiz.Title = title;
            setQuiz.Description = description;
            setQuiz.IsPublic = isPublic;
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<SetQuiz>> GetSetQuizzesByUserId(int userId)
        {
           var setQuizzes = _context.SetQuizzes
                .Where(sq => sq.CreateBy == userId && !sq.IsDeleted)
                .ToListAsync();
            return setQuizzes;
        }
    }
}
