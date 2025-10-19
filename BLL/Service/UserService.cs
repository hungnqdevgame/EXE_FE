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

        public Task<List<User>> GetAllUsersAsync()
        => _userRepository.GetAllUsersAsync();

        public Task<User> GetUserById(int userId)
        => _userRepository.GetUserById(userId);

        public Task<bool> UpdateSupscriptionStatus(int userId, int supscriptionId)
       => _userRepository.UpdateSupscriptionStatus(userId, supscriptionId);
    }
}
