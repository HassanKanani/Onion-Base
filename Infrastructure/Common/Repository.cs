
using Apllication.Defination;
using Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Common;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly IHttpContextAccessor? _httpContextAccessor;
    protected readonly DbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;
    protected virtual IQueryable<TEntity> Table => _dbSet;

    protected virtual IQueryable<TEntity> TableNoTracking => _dbSet.AsNoTracking();
    public Repository(DbContext dbContext, IHttpContextAccessor? httpContextAccessor = null)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
        _httpContextAccessor = httpContextAccessor;
    }

    #region Read Operations

    public virtual async Task<TEntity?> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
    {
        return await _dbSet.FindAsync(ids, cancellationToken);
    }

    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    public virtual async Task<IReadOnlyList<TEntity>> FindAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        return await _dbSet.Where(predicate).AsNoTracking().ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity?> FirstOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }

    public virtual async Task<int> CountAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        return await _dbSet.CountAsync(predicate, cancellationToken);
    }

    #endregion

    #region Write Operations

    public virtual async Task<TEntity> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken,
        bool saveNow = true)
    {
        // تنظیم Audit Fields
        SetAuditForCreate(entity);

        await _dbSet.AddAsync(entity, cancellationToken);

        if (saveNow)
            await SaveChangesAsync(cancellationToken);

        return entity;
    }

    public virtual async Task AddRangeAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken,
        bool saveNow = true)
    {
        foreach (var entity in entities)
            SetAuditForCreate(entity);

        await _dbSet.AddRangeAsync(entities, cancellationToken);

        if (saveNow)
            await SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken,
        bool saveNow = true)
    {
        SetAuditForUpdate(entity);

        _dbSet.Update(entity);

        if (saveNow)
            await SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateRangeAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken,
        bool saveNow = true)
    {
        foreach (var entity in entities)
            SetAuditForUpdate(entity);

        _dbSet.UpdateRange(entities);

        if (saveNow)
            await SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(
        TEntity entity,
        CancellationToken cancellationToken,
        bool saveNow = true)
    {
        _dbSet.Remove(entity);

        if (saveNow)
            await SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteRangeAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken,
        bool saveNow = true)
    {
        _dbSet.RemoveRange(entities);

        if (saveNow)
            await SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Bulk Operations (برای تعداد بالا و بهبود عملکرد)

    public virtual async Task BulkInsertAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken)
    {
        foreach (var entity in entities)
            SetAuditForCreate(entity);

        await _dbSet.AddRangeAsync(entities, cancellationToken);
        await SaveChangesAsync(cancellationToken);
    }

    public virtual async Task BulkUpdateAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken)
    {
        foreach (var entity in entities)
            SetAuditForUpdate(entity);

        _dbSet.UpdateRange(entities);
        await SaveChangesAsync(cancellationToken);
    }

    public virtual async Task BulkDeleteAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken)
    {
        _dbSet.RemoveRange(entities);
        await SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Transaction & Save

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

  
    #endregion

    #region Private Helpers

    private void SetAuditForCreate(TEntity entity)
    {
        if (entity is IReportEntity reportEntity)
        {
            reportEntity.CreateOn = DateTime.UtcNow;
            reportEntity.CreateBy = GetCurrentUser();
        }
    }

    private void SetAuditForUpdate(TEntity entity)
    {
        if (entity is IReportEntity reportEntity)
        {
            reportEntity.ModifiedOn = DateTime.UtcNow;
            reportEntity.ModifiedBy = GetCurrentUser();
        }
    }

    private string GetCurrentUser()
    {
        return _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "system";
    }

    #endregion
}
