using BLL.IService;
using BLL.Service;
using DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Quiz.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Quiz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;


        public AccountController
            (IAccountService accountService, IConfiguration config, IEmailService emailService, UserManager<User> userManager)
        {
            _accountService = accountService;
            _config = config;
            _emailService = emailService;
            _userManager = userManager;

        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterDTO request)
        //{
        //    Console.WriteLine($"Email: {request.Email}, Pass: {request.Password}, Phone: {request.Phone}, Fullname: {request.FullName}");
        //    try
        //    {
        //        var user = new IdentityUser
        //        {
        //            UserName = request.Email,
        //            Email = request.Email,
        //            PhoneNumber = request.Phone,
        //            EmailConfirmed = false
        //        };
        //        var result = await _userManager.CreateAsync(user, request.Password);
        //        return Ok(new { Message = "User created successfully", UserId = user.Id });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Error = ex.Message });
        //    }
        //}

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO request)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.Phone,
                FullName = request.FullName,
                EmailConfirmed = false
                 
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Tạo token xác nhận
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmLink = Url.Action("ConfirmEmail", "Account",
                new { userId = user.Id, token = token }, Request.Scheme);

            var subject = "Verify your email";
            var body = $"Click <a href='{confirmLink}'>here</a> to verify your email.";

            await _emailService.SendEmailAsync(user.Email, subject, body);

            return Ok(new { Message = "Registration successful. Please verify your email." });
        }


        //[HttpPost("verify-email-register")]
        //public async Task<IActionResult> VerifyEmailRegister([FromBody] VerifyEmailDTO model)
        //{
        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    if (user == null)
        //        return NotFound(new { Error = "User not found" });



        //    var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    var resetLink = Url.Action("ChangePassword", "Account"
        //        , new { email = model.Email, token = resetToken }, Request.Scheme);
        //    var subject = "Verify email";
        //    var body = $"Click <a href='{resetLink}'>here</a> to verify email.";
        //    await _emailService.SendEmailAsync(model.Email, subject, body);
        //    return RedirectToAction("EmailSent", "Account");



        //}
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound("User not found");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
               return Redirect("/verify-success"); 

            }

            return Redirect("/verify-fail"); ;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            try
            {
                var token = await _accountService.LoginAsync(request.Email, request.Password);

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized(new { Error = "Invalid email or password" });
                }

                // Nếu service của bạn muốn trả thêm thông tin User thì có thể làm kiểu này:
                var user = await _accountService.FindUserByEmail(request.Email);

                return Ok(new
                {
                    Token = token,
                    User = new
                    {
                        user.Id,
                        user.Email,
                        user.FullName,
                        user.Role
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }



        [HttpPost("send-email")]
        public async Task<IActionResult> SendResetPasswordEmail([FromBody] VerifyEmailDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _accountService.FindUserByEmail(request.Email);
            if (user == null)
                return NotFound(new { Error = "User not found" });

            var resetToken = await _accountService.GenerateResetTokenAsync(user);

            // API sẽ gửi link để Blazor dùng (ví dụ link này UI Blazor sẽ điều hướng tới page đổi mật khẩu)
            var resetLink = $"{_config["AppSettings:ClientUrl"]}/reset-password?email={user.Email}&token={resetToken}";

            var subject = "Reset Password";
            var body = $"Click <a href='{resetLink}'>here</a> to reset your password.";

            await _emailService.SendEmailAsync(request.Email, subject, body);

            return Ok(new { Message = "Reset password email sent", ResetLink = resetLink });
        }


        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            var result = await _accountService.ResetPasswordAsync(dto.Email, dto.Token, dto.NewPassword);

            if (result)
                return Ok(new { Message = "Password reset successfully" });

            return BadRequest(new { Error = "Invalid token or reset failed" });
        }

        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return NotFound(new { Error = "User not found" });

            
           
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action("ChangePassword", "Account"
                , new { email = model.Email, token = resetToken }, Request.Scheme);
            var subject = "Verify email";
            var body = $"Click <a href='{resetLink}'>here</a> to verify email.";
            await _emailService.SendEmailAsync(model.Email, subject, body);
            return RedirectToAction("EmailSent", "Account");



        }

        [HttpGet("email-sent")]
        public IActionResult EmailSent()
        {
            return Ok(new { Message = "Reset password email sent" });
        }


        [HttpGet("change-password")]
        public IActionResult ChangePassword(string email, string token)
        {
            // Chuyển hướng đến trang đổi mật khẩu trên client (Blazor)
            var clientUrl = _config["AppSettings:ClientUrl"];
            var redirectUrl = $"{clientUrl}/change-password?email={email}&token={Uri.EscapeDataString(token)}";
            return Redirect(redirectUrl);
        }
    }
}
