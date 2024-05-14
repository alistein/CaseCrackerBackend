using CaseCracker.Application.Common.Interfaces;
using CaseCracker.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CaseCracker.Infrastructure.Data.Repositories;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T>
    where T : class
{
    protected readonly DbSet<T> DbSet = context.Set<T>();
    
    public async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public IQueryable<T> GetAllAsync()
    {
        return DbSet.AsNoTracking();
    }

    public async Task AddAsync(T entity)
    {
         await DbSet.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity, params string[] excludeProperties)
    {
        DbSet.Attach(entity);
        var entry = context.Entry(entity);
        entry.State = EntityState.Modified;

        foreach (var property in excludeProperties)
        {
            entry.Property(property).IsModified = false;
        }

        await context.SaveChangesAsync();
    }

    public Task DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        return Task.CompletedTask;
    }
}