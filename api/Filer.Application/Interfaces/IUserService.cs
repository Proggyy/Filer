using Filer.Domain.Domain;
using Filer.Domain.Parameters;

namespace Filer.Application.Interfaces;

public interface IUserService : IService<User>{
    Task<IEnumerable<User>> GetAll(UserParameters userParameters);
}