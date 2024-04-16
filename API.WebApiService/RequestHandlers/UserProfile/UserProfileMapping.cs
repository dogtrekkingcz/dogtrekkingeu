using API.WebApiService.Entities;
using Mapster;
using API_CreateUserProfileRequest = PetsOnTrail.Interfaces.Actions.Entities.UserProfile.CreateUserProfileRequest;
using API_CreateUserProfileResponse = PetsOnTrail.Interfaces.Actions.Entities.UserProfile.CreateUserProfileResponse;
using API_GetUserProfileResponse = PetsOnTrail.Interfaces.Actions.Entities.UserProfile.GetUserProfileResponse;



namespace API.WebApiService.RequestHandlers.Activities;

internal static class UserProfileMapping
{
    internal static TypeAdapterConfig AddUserProfileMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<API_GetUserProfileResponse, GetUserProfileResponse>();
        typeAdapterConfig.NewConfig<API_GetUserProfileResponse.VaccinationType, GetUserProfileResponse.VaccinationType>();
        typeAdapterConfig.NewConfig<API_GetUserProfileResponse.AddressDto, GetUserProfileResponse.AddressDto>();
        typeAdapterConfig.NewConfig<API_GetUserProfileResponse.ContactDto, GetUserProfileResponse.ContactDto>();
        typeAdapterConfig.NewConfig<API_GetUserProfileResponse.PetDto, GetUserProfileResponse.PetDto>();
        typeAdapterConfig.NewConfig<API_GetUserProfileResponse.VaccinationDto, GetUserProfileResponse.VaccinationDto>();
        typeAdapterConfig.NewConfig<API_GetUserProfileResponse.LatLngDto, GetUserProfileResponse.LatLngDto>();

        typeAdapterConfig.NewConfig<CreateUserProfileRequest, API_CreateUserProfileRequest>();
        typeAdapterConfig.NewConfig<CreateUserProfileRequest.VaccinationType, API_CreateUserProfileRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<CreateUserProfileRequest.AddressDto, API_CreateUserProfileRequest.AddressDto>();
        typeAdapterConfig.NewConfig<CreateUserProfileRequest.ContactDto, API_CreateUserProfileRequest.ContactDto>();
        typeAdapterConfig.NewConfig<CreateUserProfileRequest.PetDto, API_CreateUserProfileRequest.PetDto>();
        typeAdapterConfig.NewConfig<CreateUserProfileRequest.VaccinationDto, API_CreateUserProfileRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<CreateUserProfileRequest.LatLngDto, API_CreateUserProfileRequest.LatLngDto>();
        typeAdapterConfig.NewConfig<API_CreateUserProfileResponse, CreateUserProfileResponse>();

        return typeAdapterConfig;
    }
}