using DogsOnTrail.Actions.Options;
using DogsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions.Services.UserProfileManage;

internal static class DiComposerUserProfile
{
    public static IServiceCollection AddUserProfiles(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        typeAdapterConfig.AddUserProfileMapping();
        
        services.AddScoped<IUserProfileService, UserProfileService>();
        
        return services;
    }
}