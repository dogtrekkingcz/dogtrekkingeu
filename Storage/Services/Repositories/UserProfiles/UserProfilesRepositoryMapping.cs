using Mapster;
using Storage.Entities.Activities;
using Storage.Entities.UserProfiles;
using Storage.Extensions;
using Storage.Models;

namespace Storage.Services.Repositories.UserProfiles
{
    internal static class UserProfilesRepositoryMapping
    {
        internal static TypeAdapterConfig AddUserProfilesRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest, UserProfileRecord>()
                .Ignore(d => d.CorrelationId);
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.AddressDto, UserProfileRecord.AddressDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.ContactDto, UserProfileRecord.ContactDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.VaccinationDto, UserProfileRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.LatLngDto, UserProfileRecord.LatLngDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.PetDto, UserProfileRecord.PetDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.ActivityDto, UserProfileRecord.ActivityDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord, CreateUserProfileInternalStorageResponse>();
            
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest, UserProfileRecord>()
                .Ignore(d => d.CorrelationId);
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.AddressDto, UserProfileRecord.AddressDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.ContactDto, UserProfileRecord.ContactDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.VaccinationDto, UserProfileRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.LatLngDto, UserProfileRecord.LatLngDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.PetDto, UserProfileRecord.PetDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.ActivityDto, UserProfileRecord.ActivityDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord, UpdateUserProfileInternalStorageResponse>();

            typeAdapterConfig.NewConfig<UserProfileRecord, GetUserProfileInternalStorageResponse>();
            typeAdapterConfig.NewConfig<UserProfileRecord.AddressDto, GetUserProfileInternalStorageResponse.AddressDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ContactDto, GetUserProfileInternalStorageResponse.ContactDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.VaccinationDto, GetUserProfileInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.LatLngDto, GetUserProfileInternalStorageResponse.LatLngDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.PetDto, GetUserProfileInternalStorageResponse.PetDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ActivityDto, GetUserProfileInternalStorageResponse.ActivityDto>();

            typeAdapterConfig.NewConfig<UserProfileRecord, GetSelectedUserProfilesInternalStorageResponse.UserProfileDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.AddressDto, GetSelectedUserProfilesInternalStorageResponse.AddressDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ContactDto, GetSelectedUserProfilesInternalStorageResponse.ContactDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.VaccinationDto, GetSelectedUserProfilesInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.LatLngDto, GetSelectedUserProfilesInternalStorageResponse.LatLngDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.PetDto, GetSelectedUserProfilesInternalStorageResponse.PetDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ActivityDto, GetSelectedUserProfilesInternalStorageResponse.ActivityDto>();

            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse,  UpdateUserProfileInternalStorageRequest>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.AddressDto,  UpdateUserProfileInternalStorageRequest.AddressDto>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.ContactDto, UpdateUserProfileInternalStorageRequest.ContactDto>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.VaccinationDto, UpdateUserProfileInternalStorageRequest.VaccinationDto>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.LatLngDto, UpdateUserProfileInternalStorageRequest.LatLngDto>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.PetDto, UpdateUserProfileInternalStorageRequest.PetDto>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.ActivityDto, UpdateUserProfileInternalStorageRequest.ActivityDto>();

            typeAdapterConfig.NewConfig<CreateActivityInternalStorageRequest, UserProfileRecord.ActivityDto>();

            return typeAdapterConfig;
        }
    }
}