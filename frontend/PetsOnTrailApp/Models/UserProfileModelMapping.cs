using Mapster;
using Protos.UserProfiles;

namespace PetsOnTrailApp.Models;

internal static class UserProfileModelMapping
{
    internal static TypeAdapterConfig AddUserProfileModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfile.GetUserProfileResponse, UserProfileModel>()
            .Ignore(d => d.Rights);
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfile.Address, UserProfileModel.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfile.Contact, UserProfileModel.ContactDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfile.Pet, UserProfileModel.PetDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfile.Vaccination, UserProfileModel.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfile.VaccinationType, UserProfileModel.VaccinationType>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, UserProfileModel.LatLngDto>();

        typeAdapterConfig.NewConfig<UserProfileModel, UserProfileModel>();
        typeAdapterConfig.NewConfig<UserProfileModel.AddressDto, UserProfileModel.AddressDto>();
        typeAdapterConfig.NewConfig<UserProfileModel.ContactDto, UserProfileModel.ContactDto>();
        typeAdapterConfig.NewConfig<UserProfileModel.PetDto, UserProfileModel.PetDto>();
        typeAdapterConfig.NewConfig<UserProfileModel.VaccinationDto, UserProfileModel.VaccinationDto>();
        typeAdapterConfig.NewConfig<UserProfileModel.VaccinationType, UserProfileModel.VaccinationType>();
        typeAdapterConfig.NewConfig<UserProfileModel.LatLngDto, UserProfileModel.LatLngDto>();
        typeAdapterConfig.NewConfig<UserProfileModel.ActionRightsDto, UserProfileModel.ActionRightsDto>();
        
        typeAdapterConfig.NewConfig<UserProfileModel, Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest>();
        typeAdapterConfig.NewConfig<UserProfileModel.AddressDto, Protos.UserProfiles.CreateUserProfile.Address>();
        typeAdapterConfig.NewConfig<UserProfileModel.ContactDto, Protos.UserProfiles.CreateUserProfile.Contact>();
        typeAdapterConfig.NewConfig<UserProfileModel.PetDto, Protos.UserProfiles.CreateUserProfile.Pet>();
        typeAdapterConfig.NewConfig<UserProfileModel.VaccinationDto, Protos.UserProfiles.CreateUserProfile.Vaccination>();
        typeAdapterConfig.NewConfig<UserProfileModel.VaccinationType, Protos.UserProfiles.CreateUserProfile.VaccinationType>();
        typeAdapterConfig.NewConfig<UserProfileModel.LatLngDto, Google.Type.LatLng>();
        
        typeAdapterConfig.NewConfig<UserProfileModel, Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest>();
        typeAdapterConfig.NewConfig<UserProfileModel.AddressDto, Protos.UserProfiles.UpdateUserProfile.Address>();
        typeAdapterConfig.NewConfig<UserProfileModel.ContactDto, Protos.UserProfiles.UpdateUserProfile.Contact>();
        typeAdapterConfig.NewConfig<UserProfileModel.PetDto, Protos.UserProfiles.UpdateUserProfile.Pet>();
        typeAdapterConfig.NewConfig<UserProfileModel.VaccinationDto, Protos.UserProfiles.UpdateUserProfile.Vaccination>();
        typeAdapterConfig.NewConfig<UserProfileModel.VaccinationType, Protos.UserProfiles.UpdateUserProfile.VaccinationType>();

        return typeAdapterConfig;
    }
}