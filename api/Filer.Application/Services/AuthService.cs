using Filer.Application.Exceptions;
using Filer.Application.Interfaces;
using Filer.Application.Interfaces.Auth;
using Filer.DataAccess.Interfaces;
using Filer.Domain.Domain;
using Filer.Domain.Shared;

namespace Filer.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository userRepository;
    private readonly IPasswordHasher passwordHasher;
    private readonly IJwtProvider jwtProvider;
    private readonly IRefreshProvider refreshProvider;
    public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider, IRefreshProvider refreshProvider)
    {
        this.userRepository = userRepository;
        this.passwordHasher = passwordHasher;
        this.jwtProvider = jwtProvider;
        this.refreshProvider = refreshProvider;
    }
    public async Task<bool> RegisterNewUser(string login, string name, string password)
    {
        var registred = await userRepository.GetByLogin(login);
        if(registred.Id != Guid.Empty)
        {
            return false;
        }
        var passwordHash = passwordHasher.Hash(password);
        var user = User.CreateNewUser(Guid.NewGuid() ,name, login, passwordHash);
        await userRepository.Create(user);
        await userRepository.Save(); 
        return true;       
    }

    public async Task<TokenDto> LoginUser(string login, string password)
    {
        var registred = await userRepository.GetByLogin(login);
        var hash = passwordHasher.Hash(password);
        if(registred.Id != Guid.Empty && registred.PasswordHash == hash)
        {
            return await UpdateToken(registred);           
        }
        throw new UnauthorizedException();
    }

    public async Task<TokenDto> Refresh(TokenDto tokenDto)
    {
        var principal = refreshProvider.GetClaimsPrincipalFromToken(tokenDto.AccessToken);
        Guid id;
        var claimId = principal.Claims.FirstOrDefault(x => x.Type == "Id");
        if(claimId != null && Guid.TryParse(claimId.Value, out id)){
            var user = await userRepository.GetWithRefresh(id);
            if(user.Id == Guid.Empty || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now){
                throw new RefreshTokenBadRequestException(); 
            }
            return await UpdateToken(user);
        }
        throw new RefreshTokenBadRequestException(); 
    }

    private async Task<TokenDto> UpdateToken(User user){
            var refresh = refreshProvider.GenerateRefreshToken();
            user.RefreshToken = refresh;
            user.RefreshTokenExpiryTime = DateTimeOffset.Now.ToUniversalTime().AddHours(jwtProvider.ExpiresHours);
            await userRepository.Update(user);
            await userRepository.Save();
            var jwt = jwtProvider.GenerateToken(user);
            return new TokenDto(jwt, refresh);
    }
}