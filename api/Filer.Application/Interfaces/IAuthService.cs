using Filer.Domain.Shared;

namespace Filer.Application.Interfaces;

public interface IAuthService{
    Task<bool> RegisterNewUser(string login, string name, string password);
    Task<TokenDto> LoginUser(string login, string password);
    Task<TokenDto> Refresh(TokenDto tokenDto);
}