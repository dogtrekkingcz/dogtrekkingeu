using Mapster;
using Storage.Entities.ActionRights;
using Storage.Models;

namespace Storage.Services.Repositories.ActionRights
{
    internal static class ActionRightsRepositoryMapping
    {
        internal static TypeAdapterConfig AddActionRightsRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddActionRightsInternalStorageRequest, ActionRightsRecord>()
                .Ignore(d => d.CorrelationId);

            typeAdapterConfig.NewConfig<ActionRightsRecord, AddActionRightsInternalStorageResponse>();

            typeAdapterConfig.NewConfig<GetAllRightsInternalStorageRequest, ActionRightsRecord>()
                .MapWith(s => new ActionRightsRecord { UserId = s.UserId })
                .Ignore(d => d.CorrelationId);
            typeAdapterConfig.NewConfig<ActionRightsRecord, GetAllRightsInternalStorageResponse.ActionRightsDto>();

            return typeAdapterConfig;
        }
    }
}
