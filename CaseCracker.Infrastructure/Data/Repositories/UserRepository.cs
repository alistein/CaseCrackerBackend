using CaseCracker.Application.Features.UserManagement.Interfaces;
using CaseCracker.Domain.Entities;
using CaseCracker.Infrastructure.Data.Context;

namespace CaseCracker.Infrastructure.Data.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task AddAsync(User user)
    {
        await dbContext.Users.AddAsync(user);

        await dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(int userId)
    {
        return await dbContext.Users.FindAsync(userId);
    }
}