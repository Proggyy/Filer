using Filer.Domain.Domain;

namespace Filer.Application.Interfaces.Auth;

public interface IJwtProvider{
    string GenerateToken(User user);
}