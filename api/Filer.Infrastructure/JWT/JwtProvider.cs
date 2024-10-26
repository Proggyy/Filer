using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Filer.Application.Interfaces.Auth;
using Filer.Domain.Domain;
using Microsoft.IdentityModel.Tokens;

namespace Filer.Infrastructure.JWT;

public class JwtProvider : IJwtProvider
{
    public string GenerateToken(User user)
    {
        Claim[] claims = {new Claim("Id", user.Id.ToString())};
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("secretkeysecretkeysecretkeysecretkeysecretkeysecretkeysecretkey")), 
                SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            signingCredentials: credentials,
            issuer: "issuer",
            audience: "user",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(5));
        var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
        return generatedToken;
    }
}