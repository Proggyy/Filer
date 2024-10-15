using Filer.Domain.Parameters;

namespace Filer.DataAccess.Interfaces;

public interface IRepository<T>{
    Task<T> Get(Guid id);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(Guid id);
    Task Save();
}