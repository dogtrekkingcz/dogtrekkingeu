using DogsOnTrail.Actions.Options;
using DogsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions.Services.CurrentUserId;

internal static class DiComposerCurrentUserId
{
    public static IServiceCollection AddCurrentUserId(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        services.AddScoped<ICurrentUserIdService, CurrentUserIdService>();
        
        return services;
    }
}