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
            typeAdapterConfig.NewConfig<AddActionRequest, ActionRecord>()
                .Ignore(d => d.Id);

            typeAdapterConfig.NewConfig<UpdateActionRequest, ActionRecord>();

            typeAdapterConfig.NewConfig<ActionRecord, AddActionResponse>();

            typeAdapterConfig.NewConfig<DeleteActionRequest, ActionRecord>()
                .MapWith(s => new ActionRecord { Id = s.Id });

            typeAdapterConfig.NewConfig<GetActionRequest, ActionRecord>()
                .MapWith(s => new ActionRecord { Id = s.Id.ToString() });

            typeAdapterConfig.NewConfig<ActionRecord, ActionDto>()
                .TwoWays();

            return typeAdapterConfig;
        }
    }
}
