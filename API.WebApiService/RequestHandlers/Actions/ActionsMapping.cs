using DogsOnTrail.Interfaces.Actions.Entities.Actions;
using DogsOnTrailWebApiService.Entities;
using Mapster;

namespace DogsOnTrailWebApiService.RequestHandlers.Actions;

internal static class ActionsMapping
{
    internal static TypeAdapterConfig AddActionsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<ActionDetailRequest, GetActionDetailRequest>();

        return typeAdapterConfig;
    }
}