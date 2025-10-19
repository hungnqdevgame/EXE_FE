using BLL.IService;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class SupscriptionService : ISupscriptionService
    {
        private readonly  ISupscriptionRepository _subscriptions;
        public SupscriptionService(ISupscriptionRepository subscriptions)
        {
            _subscriptions = subscriptions;
        }
        public Task<string> GetSubscriptionByNameAsync(string name)
        =>_subscriptions.GetSubscriptionByNameAsync(name)
            .ContinueWith(t => t.Result?.Name ?? "No Subscription Found");
        public Task<List<string>> GetAllSubscriptionsAsync()
        => _subscriptions.GetAllSubscriptionsAsync()
            .ContinueWith(t => t.Result.Select(s => s.Name).ToList());
    }
}
