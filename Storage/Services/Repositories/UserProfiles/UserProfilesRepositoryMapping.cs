using Mapster;
using Storage.Entities.UserProfiles;
using Storage.Models;

namespace Storage.Services.Repositories.UserProfiles
{
    internal static class UserProfilesRepositoryMapping
    {
        internal static TypeAdapterConfig AddUserProfilesRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest, UserProfileRecord>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.VaccinationType, UserProfileRecord.VaccinationType>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.AddressDto, UserProfileRecord.AddressDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.ContactDto, UserProfileRecord.ContactDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.VaccinationDto, UserProfileRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.LatLngDto, UserProfileRecord.LatLngDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.DogDto, UserProfileRecord.DogDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord, CreateUserProfileInternalStorageResponse>();
            
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest, UserProfileRecord>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.VaccinationType, UserProfileRecord.VaccinationType>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.AddressDto, UserProfileRecord.AddressDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.ContactDto, UserProfileRecord.ContactDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.VaccinationDto, UserProfileRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.LatLngDto, UserProfileRecord.LatLngDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.DogDto, UserProfileRecord.DogDto>();

            typeAdapterConfig.NewConfig<UserProfileRecord, GetUserProfileInternalStorageResponse>();
            typeAdapterConfig.NewConfig<UserProfileRecord.VaccinationType, GetUserProfileInternalStorageResponse.VaccinationType>();
            typeAdapterConfig.NewConfig<UserProfileRecord.AddressDto, GetUserProfileInternalStorageResponse.AddressDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ContactDto, GetUserProfileInternalStorageResponse.ContactDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.VaccinationDto, GetUserProfileInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.LatLngDto, GetUserProfileInternalStorageResponse.LatLngDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.DogDto, GetUserProfileInternalStorageResponse.DogDto>();
            
            return typeAdapterConfig;
        }
    }
}