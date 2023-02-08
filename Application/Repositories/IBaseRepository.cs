namespace Application
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T item);
        Task SaveChangesAsync();
    }
}