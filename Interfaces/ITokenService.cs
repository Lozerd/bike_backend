namespace bike_backend.Interfaces;

public interface ITokenService
{
    public bool VerifyToken(string token);
}