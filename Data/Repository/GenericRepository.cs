using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;
public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly SocialDbContext _context;
    public GenericRepository(SocialDbContext context) => _context = context;

    public IQueryable<TEntity> GetQueryable()
    {
        return _context.Set<TEntity>().AsQueryable().AsNoTracking();
    }
    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(false);
    }
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        entity.CreatedOn = DateTime.UtcNow;
        await _context.Set<TEntity>().AddAsync(entity).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return entity;
    }
    public async Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities)
    {
        entities.ToList().ForEach(x => x.CreatedOn = DateTime.UtcNow);
        await _context.Set<TEntity>().AddRangeAsync(entities).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return entities;
    }
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedOn = DateTime.UtcNow;
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return entity;
    }
    public async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        entities.ToList().ForEach(a => a.UpdatedOn = DateTime.UtcNow);
        _context.Set<TEntity>().UpdateRange(entities);
        await _context.SaveChangesAsync().ConfigureAwait(false);
        return entities;
    }
    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(f => f.Id == id).ConfigureAwait(false);
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
        _context.Set<TEntity>().UpdateRange(entities);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }
}
