using Filer.Application.Exceptions;
using Filer.Application.Interfaces;
using Filer.DataAccess.Interfaces;
using Filer.Domain.Domain;
using Filer.Domain.Parameters;
namespace Filer.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
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

    public async Task<IEnumerable<User>> GetAll(UserParameters userParameters)
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
}