using DogtrekkingCz.Interfaces.Actions.Entities;
using DogtrekkingCz.Interfaces.Actions.Entities.Actions;
using DogtrekkingCz.Interfaces.Actions.Entities.Rights;
using DogtrekkingCzShared.Entities;
using Google.Protobuf.Collections;
using Mapster;
using Protos.Shared;
using Storage.Entities.Actions;
using DeleteActionRequest = DogtrekkingCz.Interfaces.Actions.Entities.Actions.DeleteActionRequest;
using UpdateActionResponse = DogtrekkingCz.Interfaces.Actions.Entities.Actions.UpdateActionResponse;

namespace DogtrekkingCzGRPCService.Services.Authorization;

internal static class AuthorizationServiceMapping
{
    internal static TypeAdapterConfig AddActionsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Shared.ActionDetail, CreateActionRequest>();

        typeAdapterConfig.NewConfig<CreateActionResponse, Protos.Actions.CreateActionResponse>();

        typeAdapterConfig.NewConfig<Protos.Shared.ActionDetail, UpdateActionRequest>();

        typeAdapterConfig.NewConfig<UpdateActionResponse, Protos.Actions.UpdateActionResponse>();

        typeAdapterConfig.NewConfig<Protos.Actions.DeleteActionRequest, DeleteActionRequest>();

        typeAdapterConfig.NewConfig<Protos.Actions.GetActionRequest, GetActionRequest>();

        typeAdapterConfig.NewConfig<GetActionResponse, Protos.Shared.ActionDetail>();
        
        
        typeAdapterConfig.NewConfig<GetAllActionsWithDetailsResponse, RepeatedField<Protos.Shared.ActionDetail>>()
            .Map(d => d, s => s.Actions)
            .Ignore(d => d.Capacity);

        typeAdapterConfig.NewConfig<ActionDto, Protos.Shared.ActionDetail>()
            .TwoWays();
        
        typeAdapterConfig.NewConfig<GetAllActionsResponse, RepeatedField<Protos.Shared.ActionSimple>>()
            .Map(d => d, s => s.Actions)
            .Ignore(d => d.Capacity);

        typeAdapterConfig.NewConfig<GetAllRightsResponse, RepeatedField<Protos.Shared.ActionRights>>()
            .MapWith(s => new RepeatedField<ActionRights>
            {
                s.Rights
                    .Select(r => new ActionRights
                    {
                        Id = r.Id,
                        Rights = (ActionRights.Types.RightsType) r.Rights,
                        ActionId = r.ActionId,
                        UserId = r.UserId,
                        Roles = { r.Roles }
                    })
                    .ToList()
            });
        
        return typeAdapterConfig;
    }
}