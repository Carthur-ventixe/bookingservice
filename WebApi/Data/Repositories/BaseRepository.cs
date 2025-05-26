using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Data.Contexts;
using WebApi.Models;

namespace WebApi.Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DataContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<RepositoryResult> CreateAsync(TEntity entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResult { Success = true };
        }
        catch (Exception ex)
        {
            return new RepositoryResult { Success = false, Error = ex.Message };
        }
    }

    public virtual async Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return new RepositoryResult<IEnumerable<TEntity>> { Success = true, Result = entities };
    }

    public virtual async Task<RepositoryResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(expression);
        return new RepositoryResult<TEntity> { Success = true, Result = entity };
    }

    public virtual async Task<RepositoryResult> UpdateAsync(TEntity entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResult { Success = true };
        }
        catch (Exception ex)
        {
            return new RepositoryResult { Success = false, Error = ex.Message };
        }
    }

    public virtual async Task<RepositoryResult> DeleteAsync(TEntity entity)
    {
        try
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResult { Success = true };
        }
        catch (Exception ex)
        {
            return new RepositoryResult { Success = false, Error = ex.Message };
        }
    }
}
