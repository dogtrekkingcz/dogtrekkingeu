using DogtrekkingCzShared.Entities;
using Mapster;
using Storage.Entities.Actions;
using Storage.Models;

namespace Storage.Services.Repositories.Actions
{
    internal static class ActionRepositoryMapping
    {
        internal static TypeAdapterConfig AddActionRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<CreateActionInternalStorageRequest, ActionRecord>();

            typeAdapterConfig.NewConfig<UpdateActionInternalStorageRequest, ActionRecord>();

            typeAdapterConfig.NewConfig<ActionRecord, CreateActionInternalStorageResponse>();

            typeAdapterConfig.NewConfig<DeleteActionInternalStorageRequest, ActionRecord>()
                .MapWith(s => new ActionRecord { Id = s.Id });

            typeAdapterConfig.NewConfig<GetActionInternalStorageRequest, ActionRecord>()
                .MapWith(s => new ActionRecord { Id = s.Id.ToString() });

            typeAdapterConfig.NewConfig<ActionRecord, ActionDto>()
                .TwoWays();

            return typeAdapterConfig;
        }
    }
}
