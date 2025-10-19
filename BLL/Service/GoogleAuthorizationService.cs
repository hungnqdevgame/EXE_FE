using BLL.IService;
using DAL.Model;
using DAL.Repository;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
   
    public class GoogleAuthorizationService(
        QuizDBContext _context,IGoogleAuthHelperService _googleAuthHelper,IConfiguration _configuration) : IGoogleAuthorizationService
    {

       
        private string RedirectUrl = _configuration["Google:RedirectUri"]!;
        public async Task<UserCredential> ExchangeCodeForTokenAsync(string code)
        {
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = _googleAuthHelper.GetClientSecrets(),
                Scopes = _googleAuthHelper.GetScopes()
            });
            var token = await flow.ExchangeCodeForTokenAsync(
               "user", code, RedirectUrl, CancellationToken.None);

            _context.Add(new Credential
            { 
                AccessToken = token.AccessToken,
                RefreshToken = token.RefreshToken,
                ExpiresInSeconds = token.ExpiresInSeconds,
                IdToken = token.IdToken,
                UserId = Guid.NewGuid(),
                IssuedUtc = token.IssuedUtc
            });
            await _context.SaveChangesAsync();
            return new UserCredential(flow, "user", token);
        }

        public string GetAuthorizationUrl()
                   => new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = _googleAuthHelper.GetClientSecrets(),
                    Scopes = _googleAuthHelper.GetScopes(),
                    Prompt = "consent"
                }).CreateAuthorizationCodeRequest(RedirectUrl).Build().ToString();

         

        public async Task<UserCredential> ValidToken(string accessToken)
        {
            var _credential = await _context.Credentials.FirstOrDefaultAsync(c => c.AccessToken == accessToken)
                ?? throw new UnauthorizedAccessException("No Authencation token found.Please login again");
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = _googleAuthHelper.GetClientSecrets(),
                Scopes = _googleAuthHelper.GetScopes()
            });

            var tokenResponse = new TokenResponse
            {
                AccessToken = _credential.AccessToken,
                RefreshToken = _credential.RefreshToken,
                ExpiresInSeconds = _credential.ExpiresInSeconds,
                IdToken = _credential.IdToken,
                IssuedUtc = _credential.IssuedUtc,

            };
            return new UserCredential(flow, "user", tokenResponse);



        }
    }
}
