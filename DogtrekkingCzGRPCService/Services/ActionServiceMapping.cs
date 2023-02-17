using Google.Protobuf.Collections;
using Mapster;
using Microsoft.AspNetCore.SignalR;
using Protos;
using Storage.Interfaces.Entities;

namespace DogtrekkingCzGRPCService.Services;

internal static class ActionServiceMapping
{
    internal static TypeAdapterConfig AddActionServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<DogtrekkingCz.Storage.Models.ActionRecord.OwnerDto, Protos.OwnerDto>();
        typeAdapterConfig.NewConfig<Protos.OwnerDto, DogtrekkingCz.Storage.Models.ActionRecord.OwnerDto>();
        
        typeAdapterConfig.NewConfig<DogtrekkingCz.Storage.Models.ActionRecord, Protos.ActionRecord>();
        typeAdapterConfig.NewConfig<Protos.ActionRecord, DogtrekkingCz.Storage.Models.ActionRecord>();
        
        typeAdapterConfig.NewConfig<IList<DogtrekkingCz.Storage.Models.ActionRecord>, RepeatedField<Protos.ActionRecord>>();

        typeAdapterConfig.NewConfig<AddActionResponse, CreateActionResponse>();

        return typeAdapterConfig;
    }
}