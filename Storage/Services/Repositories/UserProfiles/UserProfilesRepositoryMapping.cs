using Mapster;
using Storage.Entities.UserProfiles;
using Storage.Models;

namespace Storage.Services.Repositories.UserProfiles
{
    internal static class UserProfilesRepositoryMapping
    {
        internal static TypeAdapterConfig AddUserProfilesRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddUserProfileRequest, UserProfileRecord>()
                .Ignore(d => d.Id);
            
            typeAdapterConfig.NewConfig<UpdateUserProfileRequest, UserProfileRecord>();

            typeAdapterConfig.NewConfig<UserProfileRecord, GetUserProfileResponse>();

            return typeAdapterConfig;
        }
    }
}