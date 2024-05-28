using Frontpoint.Core.Interfaces;
using Frontpoint.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Frontpoint.Core;
public static class CoreServiceExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IDateTimeNowProvider, FrontpointDateTime>();

        return services;
    }
}
