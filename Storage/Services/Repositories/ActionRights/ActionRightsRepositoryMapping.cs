using DogtrekkingCz.Storage.Models;
using Mapster;
using DogtrekkingCz.Shared.Entities;
using Storage.Entities.Actions;
using Storage.Models;
using Storage.Entities.ActionRights;
using DogtrekkingCzShared.Entities;

namespace Storage.Services.Repositories
{
    internal static class ActionRightsRepositoryMapping
    {
        internal static TypeAdapterConfig AddActionRightsRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddActionRightsRequest, ActionRightsRecord>()
                .Ignore(d => d.Id);

            typeAdapterConfig.NewConfig<ActionRightsRecord, AddActionRightsResponse>();

            typeAdapterConfig.NewConfig<GetAllRightsRequest, ActionRightsRecord>()
                .MapWith(s => new ActionRightsRecord { UserId = s.UserId });

            typeAdapterConfig.NewConfig<ActionRightsRecord, ActionRightsDto>()
                .TwoWays();

            return typeAdapterConfig;
        }
    }
}
