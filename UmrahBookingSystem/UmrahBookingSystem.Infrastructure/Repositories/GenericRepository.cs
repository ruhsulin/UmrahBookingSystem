using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UmrahBookingSystem.Application.Interfaces.Repositories;
using UmrahBookingSystem.Domain.Entities;
using UmrahBookingSystem.Infrastructure.Persistence.Context;

namespace UmrahBookingSystem.Infrastructure.Repositories
{
    public abstract class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected readonly DbSet<TEntity> _dbSet;

        protected GenericRepository(AppDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync([id], cancellationToken);
        }

        public async Task<IEnumerable<TEntity>?> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<TKey> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
