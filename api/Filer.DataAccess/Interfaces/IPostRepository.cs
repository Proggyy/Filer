using Filer.Domain.Domain;
using Filer.Domain.Parameters;
using Filer.Domain.Shared;

namespace Filer.DataAccess.Interfaces;

public interface IPostRepository : IRepository<Post>{
    Task<PagedList<Post>> GetAll(PostParameters postParameters);
}