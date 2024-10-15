using Filer.Domain.Domain;
using Filer.Domain.Parameters;

namespace Filer.Application.Interfaces;

public interface IPostService : IService<Post>{
    Task<IEnumerable<Post>> GetAll(PostParameters postParameters);
}