using bike_backend.Interfaces;

namespace bike_backend.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public bool VerifyToken(string token)
    {
        if (token.Contains("Bearer"))
        {
            ReadOnlySpan<char> tokenSpan = token;
            token = tokenSpan.Slice(7).ToString();
        }
        return _configuration.GetSection("Secret").Value.Equals(token);
    }
}