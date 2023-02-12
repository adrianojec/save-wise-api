namespace Application
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T item);
        Task Update(T item);
        Task Delete(Guid id);
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task SaveChangesAsync();
    }
}