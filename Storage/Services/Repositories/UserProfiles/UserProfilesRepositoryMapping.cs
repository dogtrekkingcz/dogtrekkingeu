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
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest, UserProfileRecord>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.VaccinationType, UserProfileRecord.VaccinationType>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.AddressDto, UserProfileRecord.AddressDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.ContactDto, UserProfileRecord.ContactDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.VaccinationDto, UserProfileRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.LatLngDto, UserProfileRecord.LatLngDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.PetDto, UserProfileRecord.PetDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.ActivityDto, UserProfileRecord.ActivityDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.PositionDto, UserProfileRecord.PositionDto>();
            typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageRequest.ActivityPetDto, UserProfileRecord.ActivityPetDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord, CreateUserProfileInternalStorageResponse>();
            
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest, UserProfileRecord>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.VaccinationType, UserProfileRecord.VaccinationType>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.AddressDto, UserProfileRecord.AddressDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.ContactDto, UserProfileRecord.ContactDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.VaccinationDto, UserProfileRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.LatLngDto, UserProfileRecord.LatLngDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.PetDto, UserProfileRecord.PetDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.ActivityDto, UserProfileRecord.ActivityDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.PositionDto, UserProfileRecord.PositionDto>();
            typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageRequest.ActivityPetDto, UserProfileRecord.ActivityPetDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord, UpdateUserProfileInternalStorageResponse>()
                .Map(d => d.Id, s => s.Id.ToGuid());

            typeAdapterConfig.NewConfig<UserProfileRecord, GetUserProfileInternalStorageResponse>();
            typeAdapterConfig.NewConfig<UserProfileRecord.VaccinationType, GetUserProfileInternalStorageResponse.VaccinationType>();
            typeAdapterConfig.NewConfig<UserProfileRecord.AddressDto, GetUserProfileInternalStorageResponse.AddressDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ContactDto, GetUserProfileInternalStorageResponse.ContactDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.VaccinationDto, GetUserProfileInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.LatLngDto, GetUserProfileInternalStorageResponse.LatLngDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.PetDto, GetUserProfileInternalStorageResponse.PetDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ActivityDto, GetUserProfileInternalStorageResponse.ActivityDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.PositionDto, GetUserProfileInternalStorageResponse.PositionDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ActivityPetDto, GetUserProfileInternalStorageResponse.ActivityPetDto>();

            typeAdapterConfig.NewConfig<UserProfileRecord, GetSelectedUserProfilesInternalStorageResponse.UserProfileDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.VaccinationType, GetSelectedUserProfilesInternalStorageResponse.VaccinationType>();
            typeAdapterConfig.NewConfig<UserProfileRecord.AddressDto, GetSelectedUserProfilesInternalStorageResponse.AddressDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ContactDto, GetSelectedUserProfilesInternalStorageResponse.ContactDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.VaccinationDto, GetSelectedUserProfilesInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.LatLngDto, GetSelectedUserProfilesInternalStorageResponse.LatLngDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.PetDto, GetSelectedUserProfilesInternalStorageResponse.PetDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ActivityDto, GetSelectedUserProfilesInternalStorageResponse.ActivityDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.PositionDto, GetSelectedUserProfilesInternalStorageResponse.PositionDto>();
            typeAdapterConfig.NewConfig<UserProfileRecord.ActivityPetDto, GetSelectedUserProfilesInternalStorageResponse.ActivityPetDto>();

            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse,  UpdateUserProfileInternalStorageRequest>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.VaccinationType, UpdateUserProfileInternalStorageRequest.VaccinationType>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.AddressDto,  UpdateUserProfileInternalStorageRequest.AddressDto>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.ContactDto, UpdateUserProfileInternalStorageRequest.ContactDto>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.VaccinationDto, UpdateUserProfileInternalStorageRequest.VaccinationDto>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.LatLngDto, UpdateUserProfileInternalStorageRequest.LatLngDto>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.PetDto, UpdateUserProfileInternalStorageRequest.PetDto>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.ActivityDto, UpdateUserProfileInternalStorageRequest.ActivityDto>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.PositionDto, UpdateUserProfileInternalStorageRequest.PositionDto>();
            typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.ActivityPetDto, UpdateUserProfileInternalStorageRequest.ActivityPetDto>();

            typeAdapterConfig.NewConfig<CreateActivityInternalStorageRequest, UserProfileRecord.ActivityDto>();
            typeAdapterConfig.NewConfig<CreateActivityInternalStorageRequest.PositionDto, UserProfileRecord.PositionDto>();
            typeAdapterConfig.NewConfig<CreateActivityInternalStorageRequest.PetDto, UserProfileRecord.ActivityPetDto>();

            return typeAdapterConfig;
        }
    }
}