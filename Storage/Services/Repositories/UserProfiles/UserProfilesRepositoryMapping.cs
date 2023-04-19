using Mapster;
using Storage.Entities.UserProfiles;
using Storage.Models;

namespace Storage.Services.Repositories.UserProfiles
{
    internal static class UserProfilesRepositoryMapping
    {
        internal static TypeAdapterConfig AddUserProfilesRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddUserProfileInternalStorageRequest, UserProfileRecord>();
            typeAdapterConfig.NewConfig<UserProfileRecord, AddUserProfileInternalStorageResponse>();

            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest, UserProfileRecord>();

            typeAdapterConfig.NewConfig<UserProfileRecord, GetUserProfileInternalStorageResponse>();

            return typeAdapterConfig;
        }
    }
}