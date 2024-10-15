using Filer.Domain.Domain;
using Filer.Domain.Parameters;

namespace Filer.DataAccess.Interfaces;

public interface IUserRepository : IRepository<User>{
    Task<IEnumerable<User>> GetAll(UserParameters userParameters);
}