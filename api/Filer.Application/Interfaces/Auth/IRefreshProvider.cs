using System.Security.Claims;

namespace Filer.Application.Interfaces.Auth;

public interface IRefreshProvider{
    string GenerateRefreshToken();
    ClaimsPrincipal GetClaimsPrincipalFromToken(string token);
}