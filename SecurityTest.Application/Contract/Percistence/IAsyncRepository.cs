using System.Linq.Expressions;

namespace SecurityTest.Application.Contract.Percistence
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetByExpressionAsync(Expression<Func<T, bool>> expression);
        Task<bool> ExistAsync(Expression<Func<T, bool>> expression);
    }
}
