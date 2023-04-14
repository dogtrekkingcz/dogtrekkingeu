using DogtrekkingCz.Interfaces.Actions.Entities;
using DogtrekkingCzShared.Entities;
using Google.Protobuf.Collections;
using Mapster;
using Storage.Entities.Actions;
using DeleteActionRequest = DogtrekkingCz.Interfaces.Actions.Entities.DeleteActionRequest;
using UpdateActionResponse = DogtrekkingCz.Interfaces.Actions.Entities.UpdateActionResponse;

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

        return typeAdapterConfig;
    }
}