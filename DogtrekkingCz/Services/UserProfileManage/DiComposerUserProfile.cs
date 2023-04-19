using DogtrekkingCz.Actions.Services.UserProfileManage;
using DogtrekkingCz.Interfaces.Actions.Services;
using DogtrekkingCzShared.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DogtrekkingCz.Actions.Services.ActionsManage;

internal static class DiComposerUserProfile
{
    public static IServiceCollection AddUserProfiles(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
    {
        typeAdapterConfig.AddUserProfileMapping();
        
        services.AddScoped<IUserProfileService, UserProfileService>();
        
        return services;
    }
}