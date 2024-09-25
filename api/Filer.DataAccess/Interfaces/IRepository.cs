namespace Filer.DataAccess.Interfaces;

public interface IRepository<T>{
    Task<IEnumerable<T>> GetAll();
    Task<T> Get(int id);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(int id);
    Task Save();
}