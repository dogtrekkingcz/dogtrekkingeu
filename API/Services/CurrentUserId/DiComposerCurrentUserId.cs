using PetsOnTrail.Actions.Options;
using PetsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Actions.Services.CurrentUserId;

internal static class DiComposerCurrentUserId
{
    public static IServiceCollection AddCurrentUserId(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, PetsOnTrailOptions options)
    {
        services.AddScoped<ICurrentUserIdService, CurrentUserIdService>();
        
        return services;
    }
}