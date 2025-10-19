using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IAccountRepository
    {
        Task<User> RegisterAsync(string email, string password, string fullname, string phone);
        Task<string> LoginAsync(string email,string password);
        Task<User> FindUserByEmail(string email);
       
        Task<string> GenerateResetTokenAsync(User user);
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);
    }
}
