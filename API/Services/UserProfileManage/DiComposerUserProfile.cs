using PetsOnTrail.Actions.Options;
using PetsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace PetsOnTrail.Actions.Services.UserProfileManage;

internal static class DiComposerUserProfile
{
    public static IServiceCollection AddUserProfiles(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, PetsOnTrailOptions options)
    {
        typeAdapterConfig.AddUserProfileMapping();
        
        services.AddScoped<IUserProfileService, UserProfileService>();
        
        return services;
    }
}