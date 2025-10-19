using BLL.IService;
using DAL.IRepository;
using DAL.Model;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository) 
        { 
            _accountRepository = accountRepository;
        }

        public Task<User> FindUserByEmail(string email)
        =>_accountRepository.FindUserByEmail(email);

        public Task<string> GenerateResetTokenAsync(User user)
        =>_accountRepository.GenerateResetTokenAsync(user);
        public Task<string> LoginAsync(string email, string password)
        =>_accountRepository.LoginAsync(email, password);

        public Task<User> RegisterAsync(string email, string password, string fullname, string phone)
        => _accountRepository.RegisterAsync(email, password, fullname, phone);

        public Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
      => _accountRepository.ResetPasswordAsync(email, token, newPassword);
    }
}
