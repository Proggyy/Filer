using Filer.Application.Interfaces;
using Filer.DataAccess.Interfaces;
using Filer.Domain.Domain;
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

    public async Task Delete(int id)
    {
        var user = await userRepository.Get(id);
        if(user.Id == 0){
            return;
        }
        await userRepository.Delete(id);
        await userRepository.Save();
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await userRepository.GetAll();
    }

    public async Task<User> Get(int id)
    {
        return await userRepository.Get(id);
    }

    public async Task Update(User user)
    {
        var existedUser = await userRepository.Get(user.Id);
        if(existedUser.Id == 0){
            return;
        }
        await userRepository.Update(user);
        await userRepository.Save();
    }
}