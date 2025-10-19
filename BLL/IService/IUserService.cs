using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IUserService
    {
        Task<User> GetUserById(int userId);
        Task<bool> UpdateSupscriptionStatus(int userId, int supscriptionId);
        Task<List<User>> GetAllUsersAsync();
    }
}
