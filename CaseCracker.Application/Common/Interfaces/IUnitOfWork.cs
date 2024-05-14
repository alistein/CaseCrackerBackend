using CaseCracker.Application.Features.UserManagement.Interfaces;
using CaseCracker.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace CaseCracker.Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    
    Task<IDbContextTransaction> BeginTransaction();
    Task SaveChangesAsync();
}
