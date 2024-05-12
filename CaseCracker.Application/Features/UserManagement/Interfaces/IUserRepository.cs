using CaseCracker.Domain.Entities;

namespace CaseCracker.Application.Features.UserManagement.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByIdAsync(int userId);
}