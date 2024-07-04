using CaseCracker.API.Security;
using CaseCracker.Application.Common.Interfaces;
using CaseCracker.Domain;

namespace CaseCracker.API;

public static class DependencyInjection
{
    public static IServiceCollection AddWebLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IHttpUserContext, HttpUserContext>();
        services.AddHttpContextAccessor();

        services.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));
        
        services.AddAutoMapper(typeof(Program));
        
        return services;
    }
}