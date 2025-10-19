using DAL.IRepository;
using DAL.Model;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Share;
using BLL.IService;

namespace Quiz.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorizeController(
         IGoogleAuthorizationService _googleAuthService,QuizDBContext _context) : ControllerBase
    {
        [HttpGet]
        public IActionResult Authorize() => Ok(_googleAuthService.GetAuthorizationUrl());

        [HttpGet("callback")]
        public async Task<IActionResult> CallBack(string code)
        {
            var userCredential = await _googleAuthService.ExchangeCodeForTokenAsync(code);
            var _credential = await _context.Credentials.
                FirstOrDefaultAsync(c => c.AccessToken == userCredential.Token.AccessToken);
            return Redirect($"https://localhost:7078/connect/{_credential!.UserId}");
        }

       [HttpGet("token/{userId}")]
            public async Task<IActionResult> GetAccessToken(string userId)
            {
                Guid _userId = Guid.Empty;
                try
                {
                    _userId = Guid.Parse(userId);
                }
                catch (Exception ex) { return Unauthorized(); }

                var credential = await _context.Credentials.FirstOrDefaultAsync(c => c.UserId == _userId);
            return Ok(JsonSerializer.Serialize(new Token(credential!.AccessToken,credential.UserId.ToString())));
        }
     
    }
}



    

