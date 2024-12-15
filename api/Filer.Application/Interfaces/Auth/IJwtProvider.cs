using Filer.Domain.Domain;

namespace Filer.Application.Interfaces.Auth;

public interface IJwtProvider{
    int ExpiresHours{get;}
    string GenerateToken(User user);
}