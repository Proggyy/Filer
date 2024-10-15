using Filer.Domain.Domain;
using Filer.Domain.Parameters;

namespace Filer.DataAccess.Interfaces;

public interface IPostRepository : IRepository<Post>{
    Task<IEnumerable<Post>> GetAll(PostParameters postParameters);
}