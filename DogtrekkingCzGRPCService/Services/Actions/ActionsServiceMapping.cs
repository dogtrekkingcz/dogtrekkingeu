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
        typeAdapterConfig.NewConfig<Protos.Actions.RaceDto, AddActionRequest.RaceDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CategoryDto, AddActionRequest.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.RacerDto, AddActionRequest.RacerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.DogDto, AddActionRequest.DogDto>();

        typeAdapterConfig.NewConfig<AddActionResponse, Protos.Actions.CreateActionResponse>();
        
        typeAdapterConfig.NewConfig<Protos.Actions.ActionDto, Storage.Entities.Actions.UpdateActionRequest>();
        typeAdapterConfig.NewConfig<Protos.Actions.TermDto, UpdateActionRequest.TermDto>()
            .Map(d => d.From, s => DateTime.ParseExact(s.From, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.To, s => DateTime.ParseExact(s.To, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.Actions.OwnerDto, UpdateActionRequest.OwnerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.AddressDto, UpdateActionRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.RaceDto, UpdateActionRequest.RaceDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CategoryDto, UpdateActionRequest.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.RacerDto, UpdateActionRequest.RacerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.DogDto, UpdateActionRequest.DogDto>();

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
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RaceDto, Protos.Actions.RaceDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.CategoryDto, Protos.Actions.CategoryDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RacerDto, Protos.Actions.RacerDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.DogDto, Protos.Actions.DogDto>();
        
        return typeAdapterConfig;
    }
}