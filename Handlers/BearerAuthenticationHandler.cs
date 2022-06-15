using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using bike_backend.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace bike_backend.Handlers;

public class BearerAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly ITokenService _tokenService;
    public BearerAuthenticationHandler(
        ITokenService tokenService,
        IOptionsMonitor<AuthenticationSchemeOptions> options, 
        ILoggerFactory logger, 
        UrlEncoder encoder, 
        ISystemClock clock) : base(options, logger, encoder, clock)
    {
        _tokenService = tokenService;
    }

    // protected override Task HandleChallengeAsync(AuthenticationProperties properties)
    // {
    //     Response.Headers["WWW-Authenticate"] = "Bearer";
    //     return base.HandleChallengeAsync(properties);
    // }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        string token;
        try
        {
            var authenticationHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            token = authenticationHeader.Parameter ?? "";
            
            if (!_tokenService.VerifyToken(token))
            {
                throw new ArgumentException("Invalid token value");
            }
        }
        catch (Exception e)
        {
            return AuthenticateResult.Fail(e.Message);
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, token)
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}