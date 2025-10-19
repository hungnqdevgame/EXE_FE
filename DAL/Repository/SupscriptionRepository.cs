using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.IRepository;

namespace DAL.Repository
{
    public class SupscriptionRepository : ISupscriptionRepository
    {
        private readonly QuizDBContext _context;
        public SupscriptionRepository(QuizDBContext context)
        {
            _context = context;
        }

        public async Task<Subscription> GetSubscriptionByNameAsync(string name)
        {
            return await _context.Subscriptions.FirstOrDefaultAsync(s => s.Name == name && !s.IsDeleted);
        }

        public async Task<List<Subscription>> GetAllSubscriptionsAsync()
        {
            return await _context.Subscriptions.Where(s => !s.IsDeleted).ToListAsync();
        }
    }
}
