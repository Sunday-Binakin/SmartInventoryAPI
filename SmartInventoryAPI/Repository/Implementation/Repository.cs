using Microsoft.EntityFrameworkCore;
using SmartInventoryAPI.Data;
using SmartInventoryAPI.Models.Product_Management;
using SmartInventoryAPI.Repository.Interface;

namespace SmartInventoryAPI.Repository.Implementation;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly SmartInventoryDbContext _context;
    protected readonly DbSet<T> _entities;

    public Repository(SmartInventoryDbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public virtual async Task<IEnumerable<T?>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task AddAsync(T? entity)
    {
        await _entities.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T? entity)
    {
        _entities.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _entities.FindAsync(id);
        _entities.Remove(entity);
        await _context.SaveChangesAsync();
    }
}






