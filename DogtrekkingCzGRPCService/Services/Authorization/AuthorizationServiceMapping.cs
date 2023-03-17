using System.Globalization;
using DogtrekkingCz.Shared.Entities;
using DogtrekkingCz.Shared.Extensions;
using Google.Protobuf.Collections;
using Mapster;
using Storage.Entities.Actions;
using DeleteActionRequest = Storage.Entities.Actions.DeleteActionRequest;
using GetActionRequest = Storage.Entities.Actions.GetActionRequest;
using GetActionResponse = Storage.Entities.Actions.GetActionResponse;
using GetAllActionsResponse = Storage.Entities.Actions.GetAllActionsResponse;
using UpdateActionRequest = Storage.Entities.Actions.UpdateActionRequest;
using UpdateActionResponse = Storage.Entities.Actions.UpdateActionResponse;

namespace DogtrekkingCzGRPCService.Services;

internal static class AuthorizationServiceMapping
{
    internal static TypeAdapterConfig AddActionsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Shared.ActionDetail, AddActionRequest>();

        typeAdapterConfig.NewConfig<AddActionResponse, Protos.Actions.CreateActionResponse>();

        typeAdapterConfig.NewConfig<Protos.Shared.ActionDetail, Storage.Entities.Actions.UpdateActionRequest>();

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