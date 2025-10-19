using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BLL.IService;
using DAL.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Quiz.Server.TokenHandler
{
    public class GoogleAccessTokenAuthencationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IGoogleAuthorizationService _googleAuthorizeService;
        private readonly QuizDBContext _context;

        public GoogleAccessTokenAuthencationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IGoogleAuthorizationService googleAuthorizeService,
            QuizDBContext context)
            : base(options, logger, encoder, clock)
        {
            _googleAuthorizeService = googleAuthorizeService;
            _context = context;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            string authHeader = Request.Headers["Authorization"].ToString();
            if (!authHeader.StartsWith("Bearer ", System.StringComparison.OrdinalIgnoreCase))
                return AuthenticateResult.Fail("Invalid Authorization Header");

            string accessToken = authHeader["Bearer ".Length..].Trim();

            // Optionally validate token with Google service if available
            try
            {
                var userCredential = await _googleAuthorizeService.ValidToken(accessToken);
                if (userCredential == null)
                    return AuthenticateResult.Fail("Invalid token");
            }
            catch
            {
                // ignore validation failure here; fallthrough to DB check
            }

            var credential = await _context.Credentials.FirstOrDefaultAsync(c => c.AccessToken == accessToken);
            if (credential == null)
                return AuthenticateResult.Fail("Invalid Token Provided");

            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, credential.UserId.ToString()) };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
