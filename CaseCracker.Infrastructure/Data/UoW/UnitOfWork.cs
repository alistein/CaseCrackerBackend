using CaseCracker.Application.Common.Interfaces;
using CaseCracker.Application.Features.UserManagement.Interfaces;
using CaseCracker.Domain.Entities;
using CaseCracker.Infrastructure.Data.Context;
using CaseCracker.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

namespace CaseCracker.Infrastructure.Data.UoW;

public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    private IUserRepository? _userRepository;

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(dbContext);

    public async Task<IDbContextTransaction> BeginTransaction()
    {
        return await dbContext.Database.BeginTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}

