using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CampusConnect.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CampusConnectContext Context;

        public Repository(CampusConnectContext context)
        {
            Context = context;
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public async void AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public async void AddRangeAsync(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }

        public virtual void Edit(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().AsNoTracking().Where(predicate);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public T First()
        {
            return Context.Set<T>().First();
        }

        public async Task<T> FirstAsync()
        {
            return await Context.Set<T>().FirstAsync();
        }

        public T FirstOrDefault()
        {
            return Context.Set<T>().FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate) => FirstOrDefault(predicate, false);

        public T FirstOrDefault(Expression<Func<T, bool>> predicate, bool local)
        {
            T result = default(T);

            if (predicate != null)
            {
                result = local
                    ? Context.Set<T>().FirstOrDefault(predicate.Compile())
                    : Context.Set<T>().FirstOrDefault(predicate);
            }

            return result;
        }

        public async Task<T> FirstOrDefaultAsync()
        {
            return await Context.Set<T>().FirstOrDefaultAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await FirstOrDefaultAsync(predicate, false);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool local)
        {
            return await Context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public T Last()
        {
            return Context.Set<T>().Last();
        }

        public async Task<T> LastAsync()
        {
            return await Context.Set<T>().LastAsync();
        }

        public T LastOrDefault(Expression<Func<T, bool>> predicate) => LastOrDefault(predicate, false);

        public T LastOrDefault(Expression<Func<T, bool>> predicate, bool local)
        {
            T result = default(T);

            if (predicate != null)
            {
                result = local
                    ? Context.Set<T>().LastOrDefault(predicate.Compile())
                    : Context.Set<T>().LastOrDefault(predicate);
            }

            return result;
        }

        public T LastOrDefault()
        {
            return Context.Set<T>().LastOrDefault();
        }

        public async Task<T> LastOrDefaultAsync()
        {
            return await Context.Set<T>().LastOrDefaultAsync();
        }

        public async Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await LastOrDefaultAsync(predicate, false);
        }

        public Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> predicate, bool local)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }
    }
}
