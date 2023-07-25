using Mapster;
using Storage.Entities.ActionRights;
using Storage.Models;

namespace Storage.Services.Repositories.ActionRights
{
    internal static class ActionRightsRepositoryMapping
    {
        internal static TypeAdapterConfig AddActionRightsRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddActionRightsRequest, ActionRightsRecord>();

            typeAdapterConfig.NewConfig<ActionRightsRecord, AddActionRightsResponse>();

            typeAdapterConfig.NewConfig<GetAllRightsRequest, ActionRightsRecord>()
                .MapWith(s => new ActionRightsRecord { UserId = s.UserId });

            return typeAdapterConfig;
        }
    }
}
