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
        await userRepository.Update(user);
        await userRepository.Save();
    }
}