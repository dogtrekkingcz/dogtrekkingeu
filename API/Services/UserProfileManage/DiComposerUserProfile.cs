using DogsOnTrail.Actions.Services.UserProfileManage;
using DogsOnTrail.Interfaces.Actions.Services;
using SharedCode.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogsOnTrail.Actions.Services.ActionsManage;

internal static class DiComposerUserProfile
{
    public static IServiceCollection AddUserProfiles(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        typeAdapterConfig.AddUserProfileMapping();
        
        services.AddScoped<IUserProfileService, UserProfileService>();
        
        return services;
    }
}