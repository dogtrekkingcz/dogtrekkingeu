using DogtrekkingCzWebApiService.Entities;
using Mapster;

namespace DogtrekkingCzWebApiService.RequestHandlers.Actions;

internal static class ActionsMapping
{
    internal static TypeAdapterConfig AddActionsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<ActionDetailRequest, DogtrekkingCz.Interfaces.Actions.Entities.ActionDetailRequest>();

        return typeAdapterConfig;
    }
}