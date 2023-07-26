using DogsOnTrail.Interfaces.Actions.Entities.UserProfile;
using Mapster;
using Storage.Entities.UserProfiles;

namespace DogsOnTrail.Actions.Services.UserProfileManage;

internal static class UserProfileMapping
{
    public static TypeAdapterConfig AddUserProfileMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetUserProfileRequest, GetUserProfileInternalStorageRequest>();
        typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse, GetUserProfileResponse>();
        typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.AddressDto, GetUserProfileResponse.AddressDto>();
        typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.VaccinationType, GetUserProfileResponse.VaccinationType>();
        typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.VaccinationDto, GetUserProfileResponse.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.DogDto, GetUserProfileResponse.DogDto>();
        typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.ContactDto, GetUserProfileResponse.ContactDto>();
        typeAdapterConfig.NewConfig<GetUserProfileInternalStorageResponse.LatLngDto, GetUserProfileResponse.LatLngDto>();

        typeAdapterConfig.NewConfig<UpdateUserProfileRequest, UpdateUserProfileInternalStorageRequest>();
        typeAdapterConfig.NewConfig<UpdateUserProfileRequest.AddressDto, UpdateUserProfileInternalStorageRequest.AddressDto>();
        typeAdapterConfig.NewConfig<UpdateUserProfileRequest.VaccinationType, UpdateUserProfileInternalStorageRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<UpdateUserProfileRequest.VaccinationDto, UpdateUserProfileInternalStorageRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<UpdateUserProfileRequest.DogDto, UpdateUserProfileInternalStorageRequest.DogDto>();
        typeAdapterConfig.NewConfig<UpdateUserProfileRequest.ContactDto, UpdateUserProfileInternalStorageRequest.ContactDto>();
        typeAdapterConfig.NewConfig<UpdateUserProfileRequest.LatLngDto, UpdateUserProfileInternalStorageRequest.LatLngDto>();
        typeAdapterConfig.NewConfig<UpdateUserProfileInternalStorageResponse, UpdateUserProfileResponse>();

        typeAdapterConfig.NewConfig<CreateUserProfileRequest, CreateUserProfileInternalStorageRequest>();
        typeAdapterConfig.NewConfig<CreateUserProfileRequest.AddressDto, CreateUserProfileInternalStorageRequest.AddressDto>();
        typeAdapterConfig.NewConfig<CreateUserProfileRequest.VaccinationType, CreateUserProfileInternalStorageRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<CreateUserProfileRequest.VaccinationDto, CreateUserProfileInternalStorageRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<CreateUserProfileRequest.DogDto, CreateUserProfileInternalStorageRequest.DogDto>();
        typeAdapterConfig.NewConfig<CreateUserProfileRequest.ContactDto, CreateUserProfileInternalStorageRequest.ContactDto>();
        typeAdapterConfig.NewConfig<CreateUserProfileRequest.LatLngDto, CreateUserProfileInternalStorageRequest.LatLngDto>();
        typeAdapterConfig.NewConfig<CreateUserProfileInternalStorageResponse, CreateUserProfileResponse>();


        return typeAdapterConfig;
    }
}