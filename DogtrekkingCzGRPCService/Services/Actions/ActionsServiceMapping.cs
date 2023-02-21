using System.Globalization;
using Google.Protobuf.Collections;
using Mapster;
using Protos;
using Storage.Entities.Actions;
using GetAllActionsResponse = Storage.Entities.Actions.GetAllActionsResponse;

namespace DogtrekkingCzGRPCService.Services;

internal static class ActionsServiceMapping
{
    internal static TypeAdapterConfig AddActionsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Actions.ActionDto, AddActionRequest>();
        typeAdapterConfig.NewConfig<Protos.Actions.TermDto, AddActionRequest.TermDto>()
            .Map(d => d.From, s => DateTime.ParseExact(s.From, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.To, s => DateTime.ParseExact(s.To, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.Actions.OwnerDto, AddActionRequest.OwnerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.AddressDto, AddActionRequest.AddressDto>();
        
        typeAdapterConfig.NewConfig<AddActionResponse, Protos.Actions.CreateActionResponse>();
        
        typeAdapterConfig.NewConfig<Protos.Actions.ActionDto, Storage.Entities.Actions.UpdateActionRequest>();
        typeAdapterConfig.NewConfig<Protos.Actions.TermDto, UpdateActionRequest.TermDto>()
            .Map(d => d.From, s => DateTime.ParseExact(s.From, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.To, s => DateTime.ParseExact(s.To, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.Actions.OwnerDto, UpdateActionRequest.OwnerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.AddressDto, UpdateActionRequest.AddressDto>();

        typeAdapterConfig.NewConfig<UpdateActionResponse, Protos.Actions.UpdateActionResponse>();

        typeAdapterConfig.NewConfig<Protos.Actions.DeleteActionRequest, DeleteActionRequest>();

        typeAdapterConfig.NewConfig<GetAllActionsResponse, RepeatedField<Protos.Actions.ActionDto>>()
            .Map(d => d, s => s.Actions)
            .Ignore(d => d.Capacity);
        typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionDto, Protos.Actions.ActionDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.OwnerDto, Protos.Actions.OwnerDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.TermDto, Protos.Actions.TermDto>()
            .Map(d => d.From, s => s.From.ToString("yyyy-MM-dd HH:mm:ss"))
            .Map(d => d.To, s => s.To.ToString("yyyy-MM-dd HH:mm:ss"));
        typeAdapterConfig.NewConfig<GetAllActionsResponse.AddressDto, Protos.Actions.AddressDto>();
        
        return typeAdapterConfig;
    }
}