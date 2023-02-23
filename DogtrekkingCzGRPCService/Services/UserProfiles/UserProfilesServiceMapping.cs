using System.Globalization;
using DogtrekkingCz.Storage.Entities.UserProfiles;
using Google.Protobuf.Collections;
using Mapster;
using Protos;
using Storage.Entities.Actions;
using GetAllActionsResponse = Storage.Entities.Actions.GetAllActionsResponse;

namespace DogtrekkingCzGRPCService.Services;

internal static class UserProfilesServiceMapping
{
    internal static TypeAdapterConfig AddUserProfilesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.UserProfiles.UserProfileDto, AddUserProfileRequest>()
            .Map(d => d.Birthday, s => DateTime.ParseExact(s.Birthday, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.UserProfiles.AddressDto, AddUserProfileRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.ContactDto, AddUserProfileRequest.ContactDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.DogDto, AddUserProfileRequest.DogDto>();
        
        typeAdapterConfig.NewConfig<Protos.UserProfiles.UserProfileDto, UpdateUserProfileRequest>()
            .Map(d => d.Birthday, s => DateTime.ParseExact(s.Birthday, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.UserProfiles.AddressDto, UpdateUserProfileRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.ContactDto, UpdateUserProfileRequest.ContactDto>();
        typeAdapterConfig.NewConfig<Protos.UserProfiles.DogDto, UpdateUserProfileRequest.DogDto>();
        
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfileRequest, GetUserProfileRequest>();

        typeAdapterConfig.NewConfig<GetUserProfileResponse, Protos.UserProfiles.UserProfileDto>()
            .Map(d => d.Birthday, s => s.Birthday.ToString("yyyy-MM-dd HH:mm:ss"));
        typeAdapterConfig.NewConfig<GetUserProfileResponse.AddressDto, Protos.UserProfiles.AddressDto>();
        typeAdapterConfig.NewConfig<GetUserProfileResponse.ContactDto, Protos.UserProfiles.ContactDto>();
        typeAdapterConfig.NewConfig<GetUserProfileResponse.DogDto, Protos.UserProfiles.DogDto>();
        
        return typeAdapterConfig;
    }
}