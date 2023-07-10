using Mapster;
using Microsoft.Extensions.DependencyInjection;
using QrGenerator.Services;

namespace QrGenerator;

public static class DIComposer
{
    public static IServiceCollection AddEmails(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig)
    {
        services.AddScoped<IQrGeneratorService, QrGeneratorService>();
        
        return services;
    }
}