using Filer.Domain.Domain;
using Filer.Domain.Parameters;
using Filer.Domain.Shared;

namespace Filer.Application.Interfaces;

public interface IUserService : IService<User>{
    Task<PagedList<User>> GetAll(UserParameters userParameters);
}