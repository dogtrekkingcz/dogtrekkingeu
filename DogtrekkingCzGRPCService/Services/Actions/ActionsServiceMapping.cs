using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using Google.Protobuf.Collections;
using Mapster;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
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
        typeAdapterConfig.NewConfig<Protos.Actions.RacerDto, AddActionRequest.RacerDto>()
            .Map(d => d.Birthday, s => DateTime.ParseExact(s.Birthday, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Received, s => DateTime.ParseExact(s.Received, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Payed, s => DateTime.ParseExact(s.Payed, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Start, s => DateTime.ParseExact(s.Start, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Finish, s => DateTime.ParseExact(s.Finish, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.State, s => (AddActionRequest.RaceState) ((int) s.State));
        typeAdapterConfig.NewConfig<Protos.Actions.NoteDto, AddActionRequest.NoteDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.DogDto, AddActionRequest.DogDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.FlagsDto, AddActionRequest.FlagsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CheckpointDto, AddActionRequest.CheckpointDto>()
            .Map(d => d.Passed, s => DateTime.ParseExact(s.Passed, "yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo))
            .Map(d => d.Id, s => Guid.Parse(s.Id));

        typeAdapterConfig.NewConfig<AddActionResponse, Protos.Actions.CreateActionResponse>();
        
        typeAdapterConfig.NewConfig<Protos.Actions.ActionDto, Storage.Entities.Actions.UpdateActionRequest>();
        typeAdapterConfig.NewConfig<Protos.Actions.TermDto, UpdateActionRequest.TermDto>()
            .Map(d => d.From, s => DateTime.ParseExact(s.From, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.To, s => DateTime.ParseExact(s.To, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.Actions.OwnerDto, UpdateActionRequest.OwnerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.AddressDto, UpdateActionRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.RaceDto, UpdateActionRequest.RaceDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CategoryDto, UpdateActionRequest.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.RacerDto, UpdateActionRequest.RacerDto>()
            .Map(d => d.Birthday, s => DateTime.ParseExact(s.Birthday, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Received, s => DateTime.ParseExact(s.Received, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Payed, s => DateTime.ParseExact(s.Payed, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Start, s => DateTime.ParseExact(s.Start, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Finish, s => DateTime.ParseExact(s.Finish, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.State, s => (UpdateActionRequest.RaceState) ((int) s.State));
        typeAdapterConfig.NewConfig<Protos.Actions.CheckpointDto, UpdateActionRequest.CheckpointDto>()
            .Map(d => d.Passed, s => DateTime.ParseExact(s.Passed, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Id, s => Guid.Parse(s.Id));
        typeAdapterConfig.NewConfig<Protos.Actions.NoteDto, UpdateActionRequest.NoteDto>()
            .Map(d => d.Date, s => DateTime.ParseExact(s.Date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.Actions.DogDto, UpdateActionRequest.DogDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.FlagsDto, UpdateActionRequest.FlagsDto>();

        typeAdapterConfig.NewConfig<UpdateActionResponse, Protos.Actions.UpdateActionResponse>();

        typeAdapterConfig.NewConfig<Protos.Actions.DeleteActionRequest, DeleteActionRequest>();

        typeAdapterConfig.NewConfig<GetAllActionsResponse, RepeatedField<Protos.Actions.ActionDto>>()
            .Map(d => d, s => s.Actions)
            .Ignore(d => d.Capacity);
        typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionDto, Protos.Actions.ActionDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.OwnerDto, Protos.Actions.OwnerDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.TermDto, Protos.Actions.TermDto>()
            .Map(d => d.From, s => s.From.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.To, s => s.To.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<GetAllActionsResponse.AddressDto, Protos.Actions.AddressDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RaceDto, Protos.Actions.RaceDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.CategoryDto, Protos.Actions.CategoryDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RacerDto, Protos.Actions.RacerDto>()
            .Map(d => d.Birthday, s => s.Birthday.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Received, s => s.Received.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Payed, s => s.Payed.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Start, s => s.Start.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Finish, s => s.Finish.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.State, s => (int)s.State);
        typeAdapterConfig.NewConfig<GetAllActionsResponse.CheckpointDto, Protos.Actions.CheckpointDto>()
            .Map(d => d.Passed, s => s.Passed.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Id, s => s.Id.ToString());
        typeAdapterConfig.NewConfig<GetAllActionsResponse.NoteDto, Protos.Actions.NoteDto>()
            .Map(d => d.Date, s => s.Date.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<GetAllActionsResponse.DogDto, Protos.Actions.DogDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.FlagsDto, Protos.Actions.FlagsDto>();
        
        return typeAdapterConfig;
    }
}