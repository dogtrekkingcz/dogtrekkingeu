using API.WebApiService.Entities;
using DogsOnTrail.Interfaces.Actions.Entities.Actions;
using Mapster;

namespace API.WebApiService.RequestHandlers.Actions;

internal static class ActionsMapping
{
    internal static TypeAdapterConfig AddActionsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<ActionDetailRequest, GetActionDetailRequest>();

        return typeAdapterConfig;
    }
}