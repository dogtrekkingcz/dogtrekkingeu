using API.GRPCService.Extensions;
using DogsOnTrail.Interfaces.Actions.Entities.UserProfile;
using Mapster;

namespace API.GRPCService.Services.UserProfiles;

internal static class UserProfilesServiceMapping
{
    internal static TypeAdapterConfig AddUserProfilesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        return typeAdapterConfig;
    }
}