using DogtrekkingCz.Storage.Models;
using Mapster;
using Storage.Entities.Actions;

namespace Storage.Services.Repositories
{
    internal static class ActionsRepositoryMapping
    {
        internal static TypeAdapterConfig AddActionRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddActionRequest, ActionRecord>();

            typeAdapterConfig.NewConfig<ActionRecord, AddActionResponse>();

            typeAdapterConfig.NewConfig<GetAllActionsResponse, IReadOnlyList<ActionRecord>>();
            typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionDto, ActionRecord>();
            typeAdapterConfig.NewConfig<GetAllActionsResponse.OwnerDto, ActionRecord.OwnerDto>();

            return typeAdapterConfig;
        }
    }
}
