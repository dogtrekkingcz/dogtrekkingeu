using DogtrekkingCz.Storage.Entities.UserProfiles;
using DogtrekkingCz.Storage.Models;
using Mapster;
using Storage.Entities.Actions;

namespace Storage.Services.Repositories
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