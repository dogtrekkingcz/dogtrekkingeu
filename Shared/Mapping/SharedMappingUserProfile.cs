using Mapster;
using DogtrekkingCz.Shared.Entities;
using DogtrekkingCz.Shared.Extensions;

namespace DogtrekkingCz.Shared.Mapping
{
    public static class SharedMappingUserProfile
    {
        public static TypeAdapterConfig AddSharedMappingUserProfile(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<UserProfileDto, Protos.Shared.UserProfile>()
                .Map(d => d.Birthday, s => s.Birthday.ToGoogleDateTime());

            typeAdapterConfig.NewConfig<Protos.Shared.UserProfile, UserProfileDto>()
                .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset());

            return typeAdapterConfig;
        }
    }
}
