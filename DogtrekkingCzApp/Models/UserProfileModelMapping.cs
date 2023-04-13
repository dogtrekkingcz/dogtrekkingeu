using DogtrekkingCzShared.Extensions;
using Mapster;

namespace DogtrekkingCzApp.Models;

internal static class UserProfileModelMapping
{
    internal static TypeAdapterConfig AddUserProfileModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Shared.UserProfile, UserProfileModel>()
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset());

        typeAdapterConfig.NewConfig<UserProfileModel, Protos.Shared.UserProfile>()
            .Map(d => d.Birthday, s => s.Birthday.ToGoogleDateTime());

        return typeAdapterConfig;
    }
}