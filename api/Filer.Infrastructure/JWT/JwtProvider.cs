using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Filer.Application.Interfaces.Auth;
using Filer.Domain.Domain;
using Filer.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Filer.Infrastructure.JWT;

public class JwtProvider : IJwtProvider
{
    private readonly IOptions<AuthOptions> options;
    public JwtProvider(IOptions<AuthOptions> options)
    {
        this.options = options;
    }
    public string GenerateToken(User user)
    {
        Claim[] claims = {new Claim("Id", user.Id.ToString())};
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(options.Value.SecretKey)), 
                SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            signingCredentials: credentials,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(options.Value.ExpiresHours));
        var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
        return generatedToken;
    }
}