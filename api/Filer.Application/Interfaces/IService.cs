namespace Filer.Application.Interfaces;

public interface IService<T>{
    Task<IEnumerable<T>> GetAll();
    Task<T> Get(int id);
    Task Create(T model);
    Task Delete(int id);
    Task Update(T model);
}