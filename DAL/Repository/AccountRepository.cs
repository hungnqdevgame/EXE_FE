using DAL.IRepository;
using DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DAL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new Exception("Invalid email or password.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
                throw new Exception("Invalid email or password.");

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // ✅ userId thực tế
            new Claim(ClaimTypes.Name, user.UserName),                     // ✅ tên người dùng
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            Console.WriteLine(claims);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<User> RegisterAsync(string email, string password, string fullname, string phone)
        {
            if (await _userManager.FindByEmailAsync(email) != null)
                throw new Exception("Email already exists.");
            if (await _userManager.Users.AnyAsync(u => u.PhoneNumber == phone))
                throw new Exception("Phone already exists.");

            var user = new User
            {
                UserName = email,
                Email = email,
                PhoneNumber = phone,
                FullName = fullname,
                Role = 0,
                IsDeleted = false,
                SubscriptionId = 1
            };

            var result = await _userManager.CreateAsync(user, password);
            user.SubscriptionId = 1;
            await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            return user;
        }

        public async Task<User> FindUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User> FindUserById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid user Id", nameof(id));

            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<string> GenerateResetTokenAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }
    }
}
