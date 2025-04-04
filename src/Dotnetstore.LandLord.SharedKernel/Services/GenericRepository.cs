using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.LandLord.SharedKernel.Services;

public class GenericRepository<T>(DbContext context) : IGenericRepository<T>
    where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken: cancellationToken);
    }
    
    public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }
    
    public async Task InsertAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }
    
    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
    
    public async Task DeleteAsync(object id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FindAsync(id, cancellationToken);
        
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }
    
    public async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}