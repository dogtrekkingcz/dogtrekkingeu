﻿using System.Globalization;
using System.Xml;
using DogtrekkingCz.Storage.Entities.UserProfiles;
using Mapster;
using DogtrekkingCz.Shared.Extensions;

namespace DogtrekkingCzGRPCService.Services;

internal static class UserProfilesServiceMapping
{
    internal static TypeAdapterConfig AddUserProfilesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Shared.UserProfile, AddUserProfileRequest>()
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset())
            .Map(d => d.CompetitorId, s => Guid.Parse(s.CompetitorId));

        typeAdapterConfig.NewConfig<AddUserProfileResponse, Protos.UserProfiles.CreateUserProfileResponse>();

        typeAdapterConfig.NewConfig<Protos.Shared.UserProfile, UpdateUserProfileRequest>()
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset())
            .Map(d => d.CompetitorId, s => Guid.Parse(s.CompetitorId));

        typeAdapterConfig.NewConfig<UpdateUserProfileResponse, Protos.UserProfiles.UpdateUserProfileResponse>();
        
        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfileRequest, GetUserProfileRequest>();

        typeAdapterConfig.NewConfig<GetUserProfileResponse, Protos.Shared.UserProfile>()
            .Map(d => d.Birthday, s => s.Birthday.ToGoogleDateTime())
            .Map(d => d.CompetitorId, s => s.CompetitorId.ToString());
        
        return typeAdapterConfig;
    }
}