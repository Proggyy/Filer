using Filer.DataAccess.Interfaces;
using Filer.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace Filer.DataAccess.Repository;

public class UserRepository : IUserRepository
{
    private readonly PostContext postContext;
    public UserRepository(PostContext postContext)
    {
        this.postContext = postContext;
    }
    public async Task Create(User entity)
    {
        await postContext.UserEntities.AddAsync(new UserEntity{Login = entity.Login, UserName = entity.UserName});
    }

    public async Task Delete(int id)
    {
        var entity = await postContext.UserEntities.FindAsync(id);
        if(entity != null){
            postContext.UserEntities.Remove(entity);
        }
    }

    public async Task<User> Get(int id)
    {
        var post = await postContext.UserEntities.FindAsync(id);
        if (post != null)
        {
            return User.CreateUser(post.Id, post.UserName!, post.Login!);
        }
        else{
            return new User();
        }
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await postContext.UserEntities.AsNoTracking()
        .Select(user => User.CreateUser(user.Id, user.UserName!, user.Login!))
        .ToListAsync();
    }

    public async Task Save()
    {
        await postContext.SaveChangesAsync();
    }

    public async Task Update(User entity)
    {
        var user = await postContext.UserEntities.FindAsync(entity.Id);        
        if(user != null){
            user.Login = entity.Login;
            user.UserName = entity.UserName;
            postContext.UserEntities.Update(user);
        }
    }
}