using DogsOnTrail.Interfaces.Actions.Entities.UserProfile;
using Mapster;
using Storage.Entities.UserProfiles;

namespace DogsOnTrail.Actions.Services.UserProfileManage;

internal static class UserProfileMapping
{
    public static TypeAdapterConfig AddUserProfileMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetUserProfileRequest, GetUserProfileInternalStorageRequest>()
            .Ignore(d => d.UserId);
        typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse, GetUserProfileResponse>();

        typeAdapterConfig.NewConfig<UpdateUserProfileRequest, UpdateUserProfileInternalStorageRequest>();
        typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageResponse, UpdateUserProfileResponse>();

        typeAdapterConfig.NewConfig<CreateUserProfileRequest, AddUserProfileInternalStorageRequest>();
        typeAdapterConfig.NewConfig<AddUserProfileInternalStorageResponse, CreateUserProfileResponse>();

        return typeAdapterConfig;
    }
}