using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface ISupscriptionRepository
    {
        Task<Subscription> GetSubscriptionByNameAsync(string name);
        Task<List<Subscription>> GetAllSubscriptionsAsync();
        Task<Subscription> AddSubscriptionAsync(Subscription subscription);

        Task<Subscription> GetSubscriptionByIdAsync(int id);
        Task<Subscription> UpdateSubscriptionByIdAsync(Subscription subscription);
    }
}
