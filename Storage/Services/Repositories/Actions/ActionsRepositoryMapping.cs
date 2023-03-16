using DogtrekkingCz.Storage.Models;
using Mapster;
using DogtrekkingCz.Shared.Entities;
using Storage.Entities.Actions;

namespace Storage.Services.Repositories
{
    internal static class ActionsRepositoryMapping
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
                .MapWith(s => new ActionRecord { Id = s.Id });

            typeAdapterConfig.NewConfig<ActionRecord, ActionDto>()
                .TwoWays();

            return typeAdapterConfig;
        }
    }
}
