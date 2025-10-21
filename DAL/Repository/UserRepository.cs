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
    public class UserRepository : IUserRepository
    {
        private readonly QuizDBContext _context;
        public UserRepository(QuizDBContext context)
        {
            _context = context;
        }

        public async Task<bool> UpdateSupscriptionStatus(int userId, int supscriptionId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false; // User not found
            }

            // Verify subscription exists before assigning
            var subscription = await _context.Subscriptions.FindAsync(supscriptionId);
            if (subscription == null)
            {
                return false; // Subscription not found
            }

            user.SubscriptionId = supscriptionId;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserById(int userId)
        {
            // Include Subscription navigation property to prevent null reference issues
            return await _context.Users
                .Include(u => u.Subscription)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            // Include Subscription navigation property and handle potential null values
            return await _context.Users
                .Include(u => u.Subscription)
                .ToListAsync();
        }
    }
}
