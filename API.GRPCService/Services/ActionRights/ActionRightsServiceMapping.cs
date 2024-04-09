using Mapster;

namespace API.GRPCService.Services.ActionRights;

internal static class ActionRightsServiceMapping
{
    internal static TypeAdapterConfig AddActionRightsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<PetsOnTrail.Interfaces.Actions.Entities.Rights.GetAllRightsResponse, Protos.ActionRights.GetActionRights.GetActionRightsResponse>();
        typeAdapterConfig.NewConfig<PetsOnTrail.Interfaces.Actions.Entities.Rights.GetAllRightsResponse.ActionRightsDto, Protos.ActionRights.GetActionRights.ActionRight>();
        
        return typeAdapterConfig;
    }
}