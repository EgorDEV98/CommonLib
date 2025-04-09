using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CommonLib.Other.DateTimeProvider;
using Microsoft.IdentityModel.Tokens;

namespace CommonLib.Other.JwtProvider;

public class JwtProvider : IJwtProvider
{
    private readonly IDateTimeProvider _dateTimeProvider;
    

    public JwtProvider(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateJwtToken(JwtModel? jwtModel)
    {
        if (jwtModel is null) throw new ArgumentNullException("User is null");
        
        var nowDate = _dateTimeProvider.GetCurrent();
        
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: nowDate,
            claims: new List<Claim>()
            {
                new Claim(nameof(JwtModel.UserId), jwtModel.UserId.ToString()),
                new Claim(nameof(JwtModel.Name), jwtModel.Name)
            },
            expires: nowDate.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}