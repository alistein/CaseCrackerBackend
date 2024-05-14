using CaseCracker.Application.Common.Behaviours;
using CaseCracker.Application.Common.Interfaces;
using CaseCracker.Application.Features.UserManagement.Interfaces;
using CaseCracker.Infrastructure.Data.Context;
using CaseCracker.Infrastructure.Data.Repositories;
using CaseCracker.Infrastructure.Data.UoW;
using MediatR;
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
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}