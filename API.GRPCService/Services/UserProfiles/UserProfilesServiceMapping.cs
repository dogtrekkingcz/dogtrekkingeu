using API.GRPCService.Extensions;
using DogsOnTrail.Interfaces.Actions.Entities.UserProfile;
using Mapster;

namespace API.GRPCService.Services.UserProfiles;

internal static class UserProfilesServiceMapping
{
    internal static TypeAdapterConfig AddUserProfilesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetUserProfileResponse, Protos.UserProfiles.GetUserProfile.GetUserProfileResponse>();
        typeAdapterConfig.NewConfig<GetUserProfileResponse.VaccinationType, Protos.UserProfiles.GetUserProfile.VaccinationType>();
        typeAdapterConfig.NewConfig<GetUserProfileResponse.AddressDto, Protos.UserProfiles.GetUserProfile.Address>();
        typeAdapterConfig.NewConfig<GetUserProfileResponse.ContactDto, Protos.UserProfiles.GetUserProfile.Contact>();
        typeAdapterConfig.NewConfig<GetUserProfileResponse.DogDto, Protos.UserProfiles.GetUserProfile.Dog>();
        typeAdapterConfig.NewConfig<GetUserProfileResponse.VaccinationDto, Protos.UserProfiles.GetUserProfile.Vaccination>();
        typeAdapterConfig.NewConfig<GetUserProfileResponse.LatLngDto, Google.Type.LatLng>()
            .Map(d => d.Latitude, s => s.GpsLatitude)
            .Map(d => d.Longitude, s => s.GpsLongitude);

        typeAdapterConfig.NewConfig<Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest, CreateUserProfileRequest>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.CreateUserProfile.VaccinationType, CreateUserProfileRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.CreateUserProfile.Address, CreateUserProfileRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.CreateUserProfile.Contact, CreateUserProfileRequest.ContactDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.CreateUserProfile.Dog, CreateUserProfileRequest.DogDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.CreateUserProfile.Vaccination, CreateUserProfileRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, CreateUserProfileRequest.LatLngDto>()
            .Map(d => d.GpsLatitude, s => s.Latitude)
            .Map(d => d.GpsLongitude, s => s.Longitude);
        typeAdapterConfig.NewConfig<CreateUserProfileResponse, Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse>();
        
        typeAdapterConfig.NewConfig<Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest, UpdateUserProfileRequest>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.UpdateUserProfile.VaccinationType, UpdateUserProfileRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.UpdateUserProfile.Address, UpdateUserProfileRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.UpdateUserProfile.Contact, UpdateUserProfileRequest.ContactDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.UpdateUserProfile.Dog, UpdateUserProfileRequest.DogDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.UpdateUserProfile.Vaccination, UpdateUserProfileRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, UpdateUserProfileRequest.LatLngDto>()
            .Map(d => d.GpsLatitude, s => s.Latitude)
            .Map(d => d.GpsLongitude, s => s.Longitude);
        
        return typeAdapterConfig;
    }
}