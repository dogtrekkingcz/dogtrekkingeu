using DogsOnTrail.Actions.Options;
using DogsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions.Services.LiveUpdateSubscription;

internal static class DiComposerLiveUpdateSubscription
{
    public static IServiceCollection AddLiveUpdatesSubscription(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        typeAdapterConfig.AddLiveUpdateSubscriptionMapping();
        services.AddSingleton<ILiveUpdateSubscriptionService, LiveUpdateSubscriptionService>();

        return services;
    }
}