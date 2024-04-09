using PetsOnTrail.Actions.Options;
using PetsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Actions.Services.LiveUpdateSubscription;

internal static class DiComposerLiveUpdateSubscription
{
    public static IServiceCollection AddLiveUpdatesSubscription(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, PetsOnTrailOptions options)
    {
        typeAdapterConfig.AddLiveUpdateSubscriptionMapping();
        services.AddSingleton<ILiveUpdateSubscriptionService, LiveUpdateSubscriptionService>();

        return services;
    }
}