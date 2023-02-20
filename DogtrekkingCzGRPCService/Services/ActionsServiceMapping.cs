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
            .Map(d => d.From, s => DateTime.ParseExact(s.From, "yyyy-MM-dd", CultureInfo.InvariantCulture))
            .Map(d => d.To, s => DateTime.ParseExact(s.To, "yyyy-MM-dd", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.Actions.OwnerDto, AddActionRequest.OwnerDto>();
        
        typeAdapterConfig.NewConfig<AddActionResponse, Protos.Actions.CreateActionResponse>();
        
        typeAdapterConfig.NewConfig<Protos.Actions.ActionDto, Storage.Entities.Actions.UpdateActionRequest>();
        typeAdapterConfig.NewConfig<Protos.Actions.TermDto, UpdateActionRequest.TermDto>()
            .Map(d => d.From, s => DateTime.ParseExact(s.From, "yyyy-MM-dd", CultureInfo.InvariantCulture))
            .Map(d => d.To, s => DateTime.ParseExact(s.To, "yyyy-MM-dd", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.Actions.OwnerDto, UpdateActionRequest.OwnerDto>();

        typeAdapterConfig.NewConfig<UpdateActionResponse, Protos.Actions.UpdateActionResponse>();

        typeAdapterConfig.NewConfig<GetAllActionsResponse, RepeatedField<Protos.Actions.ActionDto>>()
            .Map(d => d, s => s.Actions)
            .Ignore(d => d.Capacity);
        typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionDto, Protos.Actions.ActionDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.OwnerDto, Protos.Actions.OwnerDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.TermDto, Protos.Actions.TermDto>()
            .Map(d => d.From, s => s.From.ToString("dd.MM."))
            .Map(d => d.To, s => s.To.ToString("dd.MM."));

        return typeAdapterConfig;
    }
}