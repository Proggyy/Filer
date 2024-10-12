namespace Filer.Application.Interfaces;

public interface IService<T>{
    Task<IEnumerable<T>> GetAll();
    Task<T> Get(Guid id);
    Task Create(T model);
    Task Delete(Guid id);
    Task Update(T model);
}