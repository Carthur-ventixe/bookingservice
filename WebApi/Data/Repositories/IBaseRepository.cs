using System.Linq.Expressions;
using WebApi.Models;

namespace WebApi.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<RepositoryResult> CreateAsync(TEntity entity);
        Task<RepositoryResult> DeleteAsync(TEntity entity);
        Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync();
        Task<RepositoryResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<RepositoryResult> UpdateAsync(TEntity entity);
    }
}