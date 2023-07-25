using SharedCode.Extensions;
using Mapster;
using SharedCode.Entities;

namespace SharedCode.Mapping
{
    public static class SharedMappingUserProfile
    {
        public static TypeAdapterConfig AddSharedMappingUserProfile(this TypeAdapterConfig typeAdapterConfig)
        {
            // typeAdapterConfig.NewConfig<UserProfileDto, Protos.Shared.UserProfile>()
            //     .Map(d => d.Birthday, s => s.Birthday.ToGoogleDateTime());
            //
            // typeAdapterConfig.NewConfig<Protos.Shared.UserProfile, UserProfileDto>()
            //     .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset());

            typeAdapterConfig.NewConfig<UserProfileDto, UserProfileDto>();

            return typeAdapterConfig;
        }
    }
}
