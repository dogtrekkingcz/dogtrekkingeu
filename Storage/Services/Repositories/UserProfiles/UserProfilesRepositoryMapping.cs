using Mapster;
using Storage.Entities.UserProfiles;
using Storage.Extensions;
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
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.PetDto, UserProfileRecord.PetDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord, CreateUserProfileInternalStorageResponse>();
            
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest, UserProfileRecord>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.VaccinationType, UserProfileRecord.VaccinationType>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.AddressDto, UserProfileRecord.AddressDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.ContactDto, UserProfileRecord.ContactDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.VaccinationDto, UserProfileRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.LatLngDto, UserProfileRecord.LatLngDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.PetDto, UserProfileRecord.PetDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord, UpdateUserProfileInternalStorageResponse>()
                .Map(d => d.Id, s => s.Id.ToGuid());

            typeAdapterConfig.NewConfig<UserProfileRecord, GetUserProfileInternalStorageResponse>();
            typeAdapterConfig.NewConfig<UserProfileRecord.VaccinationType, GetUserProfileInternalStorageResponse.VaccinationType>();
            typeAdapterConfig.NewConfig<UserProfileRecord.AddressDto, GetUserProfileInternalStorageResponse.AddressDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ContactDto, GetUserProfileInternalStorageResponse.ContactDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.VaccinationDto, GetUserProfileInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.LatLngDto, GetUserProfileInternalStorageResponse.LatLngDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.PetDto, GetUserProfileInternalStorageResponse.PetDto>();
            
            typeAdapterConfig.NewConfig<UserProfileRecord, GetSelectedUserProfilesInternalStorageResponse.UserProfileDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.VaccinationType, GetSelectedUserProfilesInternalStorageResponse.VaccinationType>();
            typeAdapterConfig.NewConfig<UserProfileRecord.AddressDto, GetSelectedUserProfilesInternalStorageResponse.AddressDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ContactDto, GetSelectedUserProfilesInternalStorageResponse.ContactDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.VaccinationDto, GetSelectedUserProfilesInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.LatLngDto, GetSelectedUserProfilesInternalStorageResponse.LatLngDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.PetDto, GetSelectedUserProfilesInternalStorageResponse.PetDto>();
            
            return typeAdapterConfig;
        }
    }
}