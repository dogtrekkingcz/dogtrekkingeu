using DogtrekkingCz.Interfaces.Actions.Entities.Actions;
using DogtrekkingCzWebApiService.Entities;
using Mapster;

namespace DogtrekkingCzWebApiService.RequestHandlers.Actions;

internal static class ActionsMapping
{
    internal static TypeAdapterConfig AddActionsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<ActionDetailRequest, GetActionDetailRequest>();

        return typeAdapterConfig;
    }
}