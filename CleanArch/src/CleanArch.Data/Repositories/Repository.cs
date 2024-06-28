using CleanArch.Data.Context;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Repositories;

public class Repository<T> : IRepository<T> where T: Entity
{
    protected readonly AppDbContext Context;

    public Repository(AppDbContext dbContext)
    {
        Context = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        Context.Set<T>().Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync();
        return entity;
    }
}