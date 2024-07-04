using CaseCracker.Application.Common.Interfaces;
using CaseCracker.Infrastructure.Data.Configurations;
using CaseCracker.Infrastructure.Data.Context;
using CaseCracker.Infrastructure.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CaseCracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseMySQL(configuration["DatabaseString"] ?? ""));
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IMongoDbContext,MongoDbContext>();
        
        MongoDbMappings.Configure();
        
        return services;
    }
}