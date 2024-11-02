using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Filer.Application.Interfaces.Auth;
using Filer.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Filer.Infrastructure.JWT;

public class RefreshProvider : IRefreshProvider
{
    private readonly IOptions<AuthOptions> options;
    public RefreshProvider(IOptions<AuthOptions> options)
    {
        this.options = options;
    }
    public string GenerateRefreshToken()
    {
        var bytes = new byte[32];
        using(var rng = RandomNumberGenerator.Create()){
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }

    public ClaimsPrincipal GetClaimsPrincipalFromToken(string token)
    {
        var parameters = new TokenValidationParameters{
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey))
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token,parameters, out securityToken);
        var jwtToken = securityToken as JwtSecurityToken;
        if(jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase)){
            throw new SecurityTokenException("Invalid token");
        }
        return principal;
    }
}