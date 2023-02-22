using System.Globalization;
using Google.Protobuf.Collections;
using Mapster;
using Storage.Entities.Actions;

namespace DogtrekkingCzApp.Models;

 internal static class ActionModelMapping
{
    internal static TypeAdapterConfig AddActionModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<RepeatedField<Protos.Actions.ActionDto>, IList<ActionModel>>();
        typeAdapterConfig.NewConfig<Protos.Actions.ActionDto, ActionModel>();
        typeAdapterConfig.NewConfig<Protos.Actions.OwnerDto, ActionModel.OwnerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.TermDto, ActionModel.TermDto>()
            .Map(d => d.From, s => DateTime.ParseExact(s.From, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.To, s => DateTime.ParseExact(s.To, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.Actions.AddressDto, ActionModel.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.RaceDto, ActionModel.RaceDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CategoryDto, ActionModel.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.RacerDto, ActionModel.RacerDto>()
            .Map(d => d.Birthday, s => DateTime.ParseExact(s.Birthday, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Received, s => DateTime.ParseExact(s.Received, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Payed, s => DateTime.ParseExact(s.Payed, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Start, s => DateTime.ParseExact(s.Start, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.Finish, s => DateTime.ParseExact(s.Finish, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.State, s => (ActionModel.RaceState) ((int) s.State));
        typeAdapterConfig.NewConfig<Protos.Actions.CheckpointDto, ActionModel.CheckpointDto>()
            .Map(d => d.Passed, s => DateTime.ParseExact(s.Passed, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.Actions.NoteDto, ActionModel.NoteDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.DogDto, ActionModel.DogDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.FlagsDto, ActionModel.FlagsDto>();
        
        typeAdapterConfig.NewConfig<ActionModel, Protos.Actions.ActionDto>();
        typeAdapterConfig.NewConfig<ActionModel.OwnerDto, Protos.Actions.OwnerDto>();
        typeAdapterConfig.NewConfig<ActionModel.TermDto, Protos.Actions.TermDto>()
            .Map(d => d.From, s => s.From.ToString("yyyy-MM-dd HH:mm:ss"))
            .Map(d => d.To, s => s.To.ToString("yyyy-MM-dd HH:mm:ss"));
        typeAdapterConfig.NewConfig<ActionModel.AddressDto, Protos.Actions.AddressDto>();
        typeAdapterConfig.NewConfig<ActionModel.RaceDto, Protos.Actions.RaceDto>();
        typeAdapterConfig.NewConfig<ActionModel.CategoryDto, Protos.Actions.CategoryDto>();
        typeAdapterConfig.NewConfig<ActionModel.RacerDto, Protos.Actions.RacerDto>()
            .Map(d => d.Birthday, s => s.Birthday.ToString("yyyy-MM-dd HH:mm:ss"))
            .Map(d => d.Received, s => s.Received.ToString("yyyy-MM-dd HH:mm:ss"))
            .Map(d => d.Payed, s => s.Payed.ToString("yyyy-MM-dd HH:mm:ss"))
            .Map(d => d.Start, s => s.Start.ToString("yyyy-MM-dd HH:mm:ss"))
            .Map(d => d.Finish, s => s.Finish.ToString("yyyy-MM-dd HH:mm:ss"))
            .Map(d => d.State, s => (int)s.State);
        typeAdapterConfig.NewConfig<ActionModel.CheckpointDto, Protos.Actions.CheckpointDto>()
            .Map(d => d.Passed, s => s.Passed.ToString("yyyy-MM-dd HH:mm:ss"));
        typeAdapterConfig.NewConfig<ActionModel.NoteDto, Protos.Actions.NoteDto>()
            .Map(d => d.Date, s => s.Date.ToString("yyyy-MM-dd HH:mm:ss"));
        typeAdapterConfig.NewConfig<ActionModel.DogDto, Protos.Actions.DogDto>();
        typeAdapterConfig.NewConfig<ActionModel.FlagsDto, Protos.Actions.FlagsDto>();

        return typeAdapterConfig;
    }
}