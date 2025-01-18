using Microsoft.EntityFrameworkCore;
using SecurityTest.Application.Contract.Percistence;
using SecurityTest.Domain.Entities;
using System.Linq.Expressions;

namespace SecurityTest.Persistence.Repositories.Base
{
    public class BaseRepository<T>(SecurityTestDataContext dbContext) : IAsyncRepository<T> where T : BaseClass, new()
    {
        protected readonly SecurityTestDataContext _dbContext = dbContext;

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int Id) => await _dbContext.Set<T>().FindAsync(Id);
        public IQueryable<T> GetByExpressionAsync(Expression<Func<T, bool>> expression) => _dbContext.Set<T>().Where(expression).AsQueryable();
        public virtual async Task<IReadOnlyList<T>> ListAllAsync() => await _dbContext.Set<T>().ToListAsync();
        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> ExistAsync(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().AnyAsync(expression);
        }
    }
}
