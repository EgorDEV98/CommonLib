namespace CommonLib.Other.JwtProvider;

public interface IJwtProvider
{
    public string GenerateJwtToken(JwtModel? model);
}