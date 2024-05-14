using CaseCracker.Application.Features.UserManagement.Interfaces;
using CaseCracker.Domain.Entities;
using CaseCracker.Infrastructure.Data.Context;

namespace CaseCracker.Infrastructure.Data.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : GenericRepository<User>(dbContext), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await dbContext.Users.FindAsync(email);
    }
}