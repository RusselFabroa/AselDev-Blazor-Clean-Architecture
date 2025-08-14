using AselBlazorCleanArchitecture.Application.Interfaces;
using AselBlazorCleanArchitecture.Infrastructure.Services;

namespace AselBlazorCleanArchitecture.Server.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLoggingServices(this IServiceCollection services)
    {
        // Register logging services
        services.AddScoped<ILoggingService, SerilogService>();
        services.AddScoped<IApplicationLogger, ApplicationLoggingService>();

        return services;
    }
}
