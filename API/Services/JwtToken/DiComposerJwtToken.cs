using PetsOnTrail.Actions.Options;
using PetsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PetsOnTrail.Interfaces.Actions.Entities.JwtToken;

namespace PetsOnTrail.Actions.Services.Checkpoints;

internal static class DiComposerJwtToken
{
    public static IServiceCollection AddJwtToken(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, PetsOnTrailOptions options)
    {
        services.AddScoped<IJwtTokenService, JwtTokenService>();

        return services;
    }
}