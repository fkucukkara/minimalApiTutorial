using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;
public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly SocialDbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public GenericRepository(SocialDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public IQueryable<TEntity> GetQueryable() => _dbSet.AsNoTracking();

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        entity.CreatedOn = DateTime.UtcNow;
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities)
    {
        entities.ToList().ForEach(x => x.CreatedOn = DateTime.UtcNow);
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
        return entities;
    }
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedOn = DateTime.UtcNow;
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        entities.ToList().ForEach(a => a.UpdatedOn = DateTime.UtcNow);
        _dbSet.UpdateRange(entities);
        await _context.SaveChangesAsync();
        return entities;
    }
    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(f => f.Id == id);
        if (entity != null)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        entities.ToList().ForEach(a => a.IsDeleted = true);
        entities.ToList().ForEach(a => a.DeletedOn = DateTime.UtcNow);
        _dbSet.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }
}
