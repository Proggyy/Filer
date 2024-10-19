using Filer.Domain.Domain;
using Filer.Domain.Parameters;
using Filer.Domain.Shared;

namespace Filer.Application.Interfaces;

public interface IPostService : IService<Post>{
    Task<PagedList<Post>> GetAll(PostParameters postParameters);
}