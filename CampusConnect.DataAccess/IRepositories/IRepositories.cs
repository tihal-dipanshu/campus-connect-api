using System.Linq.Expressions;

namespace CampusConnect.DataAccess.IRepositories
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Edit(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        T FirstOrDefault();
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate, bool local);
        T LastOrDefault();
        T LastOrDefault(Expression<Func<T, bool>> predicate);
        T LastOrDefault(Expression<Func<T, bool>> predicate, bool local);
        T Last();
        T First();

        //// Async Methods
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        void AddAsync(T entity);
        void AddRangeAsync(IEnumerable<T> entities);

        Task<T> FirstOrDefaultAsync();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool local);
        Task<T> LastOrDefaultAsync();
        Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> predicate, bool local);
        Task<T> LastAsync();
        Task<T> FirstAsync();
    }
}
