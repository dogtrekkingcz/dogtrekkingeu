using Mapster;
using Protos.UserProfiles;

namespace DogsOnTrailApp.Models;

internal static class UserProfileModelMapping
{
    internal static TypeAdapterConfig AddUserProfileModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfile.GetUserProfileResponse, UserProfileModel>()
            .Ignore(d => d.Rights);
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfile.Address, UserProfileModel.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfile.Contact, UserProfileModel.ContactDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfile.Dog, UserProfileModel.DogDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfile.Vaccination, UserProfileModel.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfile.VaccinationType, UserProfileModel.VaccinationType>();

        return typeAdapterConfig;
    }
}