using Filer.Domain.Domain;
using Filer.Domain.Parameters;
using Filer.Domain.Shared;

namespace Filer.DataAccess.Interfaces;

public interface IUserRepository : IRepository<User>{
    Task<PagedList<User>> GetAll(UserParameters userParameters);
    Task<User> GetByLogin(string login);
    Task<User> GetWithRefresh(Guid id);
}