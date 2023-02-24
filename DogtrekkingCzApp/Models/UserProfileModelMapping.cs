using System.Globalization;
using Google.Protobuf.Collections;
using Mapster;
using Protos.UserProfiles;

namespace DogtrekkingCzApp.Models;

internal static class UserProfileModelMapping
{
    internal static TypeAdapterConfig AddUserProfileModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.UserProfiles.UserProfileDto, UserProfileModel>()
            .Map(d => d.Birthday, s => DateTime.ParseExact(s.Birthday, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.UserProfiles.AddressDto, UserProfileModel.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.DogDto, UserProfileModel.DogDto>()
            .Map(d => d.BirthDate, s => DateTime.ParseExact(s.BirthDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.DeathDate,s => DateTime.ParseExact(s.DeathDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.UserProfiles.ContactDto, UserProfileModel.ContactDto>();

        typeAdapterConfig.NewConfig<UserProfileModel, Protos.UserProfiles.UserProfileDto>()
            .Map(d => d.Birthday, s => s.Birthday.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<UserProfileModel.AddressDto, Protos.UserProfiles.AddressDto>();
        typeAdapterConfig.NewConfig<UserProfileModel.ContactDto, Protos.UserProfiles.ContactDto>();
        typeAdapterConfig.NewConfig<UserProfileModel.DogDto, Protos.UserProfiles.DogDto>()
            .Map(d => d.BirthDate, s => s.BirthDate.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.DeathDate, s => s.DeathDate.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));

        return typeAdapterConfig;
    }
}