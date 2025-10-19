using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface ISupscriptionService
    {
        Task<string> GetSubscriptionByNameAsync(string name);
        Task<List<string>> GetAllSubscriptionsAsync();
    }
}
