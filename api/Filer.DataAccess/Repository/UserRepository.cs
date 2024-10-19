using Filer.DataAccess.Interfaces;
using Filer.Domain.Domain;
using Filer.Domain.Parameters;
using Microsoft.EntityFrameworkCore;
using Filer.DataAccess.Extensions;
using Filer.Domain.Shared;

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
        await postContext.UserEntities.AddAsync(new UserEntity{Id = Guid.NewGuid(),Login = entity.Login, UserName = entity.UserName});
    }

    public async Task Delete(Guid id)
    {
        var entity = await postContext.UserEntities.FirstOrDefaultAsync(u => u.Id == id);
        if(entity != null){
            postContext.UserEntities.Remove(entity);
        }
    }

    public async Task<User> Get(Guid id)
    {
        var post = await postContext.UserEntities.FirstOrDefaultAsync(u => u.Id == id);
        if (post != null)
        {
            return User.CreateUser(post.Id, post.UserName!, post.Login!);
        }
        else{
            return new User();
        }
    }

    public async Task<PagedList<User>> GetAll(UserParameters userParameters)
    {
        var list = await postContext.UserEntities.AsNoTracking()
        .Search(userParameters.SearchTerm)
        .Select(user => User.CreateUser(user.Id, user.UserName!, user.Login!))      
        .ToListAsync();
        var sortedList = list.Sort(userParameters.OrderBy!);
        return PagedList<User>.CreatePagedList(sortedList, userParameters.PageNumber, userParameters.PageSize);
    }

    public async Task Save()
    {
        await postContext.SaveChangesAsync();
    }

    public async Task Update(User entity)
    {
        var user = await postContext.UserEntities.FirstOrDefaultAsync(u => u.Id == entity.Id);        
        if(user != null){
            user.Login = entity.Login;
            user.UserName = entity.UserName;
            postContext.UserEntities.Update(user);
        }
    }
}