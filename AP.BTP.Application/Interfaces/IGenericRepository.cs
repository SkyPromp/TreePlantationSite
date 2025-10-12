namespace AP.BTP.Application.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll(int pageNr, int pageSize);
        Task<T> GetById(int id);
        Task<T> Create(T item);
        T Update(T modifiedItem);
        void Delete(T item);
    }
}
