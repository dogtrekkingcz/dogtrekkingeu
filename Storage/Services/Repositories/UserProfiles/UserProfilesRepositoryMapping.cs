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
            typeAdapterConfig.NewConfig<AddUserProfileRequest.AddressDto, UserProfileRecord.AddressDto>();
            typeAdapterConfig.NewConfig<AddUserProfileRequest.ContactDto, UserProfileRecord.ContactDto>();
            typeAdapterConfig.NewConfig<AddUserProfileRequest.DogDto, UserProfileRecord.DogDto>();
            
            typeAdapterConfig.NewConfig<UpdateUserProfileRequest, UserProfileRecord>();
            typeAdapterConfig.NewConfig<UpdateUserProfileRequest.AddressDto, UserProfileRecord.AddressDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileRequest.ContactDto, UserProfileRecord.ContactDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileRequest.DogDto, UserProfileRecord.DogDto>();

            typeAdapterConfig.NewConfig<UserProfileRecord, GetUserProfileResponse>();
            typeAdapterConfig.NewConfig<UserProfileRecord.AddressDto, GetUserProfileResponse.AddressDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ContactDto, GetUserProfileResponse.ContactDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.DogDto, GetUserProfileResponse.DogDto>();

            return typeAdapterConfig;
        }
    }
}