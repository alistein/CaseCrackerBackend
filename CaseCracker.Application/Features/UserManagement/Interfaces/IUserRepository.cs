using CaseCracker.Application.Common.Interfaces;
using CaseCracker.Domain.Entities;

namespace CaseCracker.Application.Features.UserManagement.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}