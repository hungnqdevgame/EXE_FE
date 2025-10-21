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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            // Filter out deleted users and ensure subscription data is safe to access
            return users.Where(u => !u.IsDeleted).ToList();
        }

        public async Task<User> GetUserById(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid user ID", nameof(userId));
            }

            var user = await _userRepository.GetUserById(userId);
            if (user == null || user.IsDeleted)
            {
                return null;
            }

            return user;
        }

        public async Task<bool> UpdateSupscriptionStatus(int userId, int supscriptionId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid user ID", nameof(userId));
            }

            if (supscriptionId <= 0)
            {
                throw new ArgumentException("Invalid subscription ID", nameof(supscriptionId));
            }

            return await _userRepository.UpdateSupscriptionStatus(userId, supscriptionId);
        }
    }
}
