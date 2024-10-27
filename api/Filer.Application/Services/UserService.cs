using Filer.Application.Exceptions;
using Filer.Application.Interfaces;
using Filer.Application.Interfaces.Auth;
using Filer.DataAccess.Interfaces;
using Filer.DataAccess.Repository;
using Filer.Domain.Domain;
using Filer.Domain.Parameters;
using Filer.Domain.Shared;
namespace Filer.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IPasswordHasher passwordHasher;
    private readonly IJwtProvider jwtProvider;
    public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        this.userRepository = userRepository;
        this.passwordHasher = passwordHasher;
        this.jwtProvider = jwtProvider;
    }
    public async Task Create(User user)
    {
        await userRepository.Create(user);
        await userRepository.Save();
    }

    public async Task Delete(Guid id)
    {
        var user = await userRepository.Get(id);
        if(user.Id == Guid.Empty){
            throw new UserNotFoundException(id);
        }
        await userRepository.Delete(id);
        await userRepository.Save();
    }

    public async Task<PagedList<User>> GetAll(UserParameters userParameters)
    {
        return await userRepository.GetAll(userParameters);
    }

    public async Task<User> Get(Guid id)
    {
        var user = await userRepository.Get(id);
        if(user.Id == Guid.Empty){
            throw new UserNotFoundException(id);
        }
        return user;
    }

    public async Task Update(User user)
    {
        var existedUser = await userRepository.Get(user.Id);
        if(existedUser.Id == Guid.Empty){
            throw new UserNotFoundException(user.Id);
        }
        await userRepository.Update(user);
        await userRepository.Save();
    }

    public async Task RegisterNewUser(string login, string name, string password)
    {
        var registred = await userRepository.GetByLogin(login);
        if(registred.Id != Guid.Empty)
        {
            throw new LoginExistException(login);
        }
        var passwordHash = passwordHasher.Hash(password);
        var user = User.CreateNewUser(Guid.NewGuid() ,name, login, passwordHash);
        await userRepository.Create(user);
        await userRepository.Save();        
    }

    public async Task<string> LoginUser(string login, string password)
    {
        var registred = await userRepository.GetByLogin(login);
        var hash = passwordHasher.Hash(password);
        if(registred.Id != Guid.Empty && registred.PasswordHash == hash)
        {
            return jwtProvider.GenerateToken(registred);
        }
        return "";
    }
}