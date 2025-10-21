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
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<Subscription> GetSubscriptionByIdAsync(int id)
        {
            return await _context.Subscriptions.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task<Subscription> AddSubscriptionAsync(Subscription subscription)
        {
            var newSupScription = new Subscription
            {
                Name = subscription.Name,
                Description = subscription.Description,
                Amount = subscription.Amount,
                IsDeleted = false
            };
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
            return newSupScription;
        }

        public async Task<Subscription> UpdateSubscriptionByIdAsync(Subscription subscription)
        {
            var existingSubscription = await _context.Subscriptions.FindAsync(subscription.Id);
            if (existingSubscription == null || existingSubscription.IsDeleted)
            {
                return null; // Subscription not found
            }
            existingSubscription.Name = subscription.Name;
            existingSubscription.Description = subscription.Description;
            existingSubscription.Amount = subscription.Amount;
            _context.Entry(existingSubscription).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return existingSubscription;
        }
    }
}
