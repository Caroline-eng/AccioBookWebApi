using AccioBook.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AccioBook.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var entry = await _context.AddAsync(entity);
            return entry.Entity;
        }

        public async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities)
        {
            var added = new List<TEntity>();
            foreach (var entity in entities)
            {
                added.Add(await AddAsync(entity));
            }

            return added;
        }

        public virtual ValueTask<TEntity> GetAsync(object id)
        {
            return _context.FindAsync<TEntity>(id);
        }

        public virtual Task<TEntity> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _context.Set<TEntity>().AsNoTracking();
            return entities.FirstOrDefaultAsync(predicate);
        }

        public virtual Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.Run(() =>
            {
                var entities = _context.Set<TEntity>();
                return entities.Where(predicate).AsQueryable();
            });
        }

        public virtual Task<IQueryable<TEntity>> GetAllAsyncNoTracking()
        {
            return Task.Run(() =>
            {
                var entities = _context.Set<TEntity>().AsNoTracking();
                return entities;
            });
        }

        public virtual Task<IQueryable<TEntity>> GetAllAsyncNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.Run(() =>
            {
                var entities = _context.Set<TEntity>().AsNoTracking();
                return entities.Where(predicate).AsQueryable();
            });
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.Run(() =>
            {
                var entry = _context.Update(entity);
                return entry.Entity;
            });
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            return Task.Run(() => _context.Remove(entity));
        }

        public virtual async Task DeleteAsync(object id)
        {
            var entity = await _context.FindAsync<TEntity>(id);
            await Task.Run(() => _context.Remove(entity));
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
