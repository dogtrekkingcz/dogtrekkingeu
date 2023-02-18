using Google.Protobuf.Collections;
using Mapster;
using Storage.Entities.Actions;

namespace DogtrekkingCzGRPCService.Services;

internal static class ActionServiceMapping
{
    internal static TypeAdapterConfig AddActionServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<AddActionResponse.OwnerDto, Protos.OwnerDto>();

        typeAdapterConfig.NewConfig<Storage.Entities.Actions.GetAllActionsResponse.OwnerDto, Protos.OwnerDto>();
        typeAdapterConfig.NewConfig<Storage.Entities.Actions.GetAllActionsResponse.ActionDto, Protos.Action>();
        typeAdapterConfig.NewConfig<Storage.Entities.Actions.GetAllActionsResponse, RepeatedField<Protos.Action>>();

        typeAdapterConfig.NewConfig<AddActionResponse, Protos.CreateActionResponse>();

        return typeAdapterConfig;
    }
}