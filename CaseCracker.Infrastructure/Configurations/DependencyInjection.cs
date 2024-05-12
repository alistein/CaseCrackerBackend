using CaseCracker.Application.Features.UserManagement.Interfaces;
using CaseCracker.Infrastructure.Data.Context;
using CaseCracker.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CaseCracker.Infrastructure.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseMySQL(configuration["DatabaseString"] ?? ""));

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}