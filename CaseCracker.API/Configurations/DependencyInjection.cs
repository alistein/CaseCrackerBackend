using CaseCracker.API.Security;
using CaseCracker.Application.Common.Interfaces;

namespace CaseCracker.API.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddWebLayer(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IHttpUserContext, HttpUserContext>();

        return services;
    }
}