using DogtrekkingCz.Storage.Models;
using Mapster;
using Storage.Entities.Actions;

namespace Storage.Services.Repositories
{
    internal static class ActionsRepositoryMapping
    {
        internal static TypeAdapterConfig AddActionRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddActionRequest, ActionRecord>()
                .Ignore(d => d.Id);
            typeAdapterConfig.NewConfig<AddActionRequest.TermDto, ActionRecord.TermDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.OwnerDto, ActionRecord.OwnerDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.AddressDto, ActionRecord.AddressDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.FlagsDto, ActionRecord.FlagsDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.RaceDto, ActionRecord.RaceDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.CategoryDto, ActionRecord.CategoryDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.CheckpointDto, ActionRecord.CheckpointDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.RacerDto, ActionRecord.RacerDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.NoteDto, ActionRecord.NoteDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.DogDto, ActionRecord.DogDto>();


            typeAdapterConfig.NewConfig<UpdateActionRequest, ActionRecord>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.TermDto, ActionRecord.TermDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.OwnerDto, ActionRecord.OwnerDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.AddressDto, ActionRecord.AddressDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.FlagsDto, ActionRecord.FlagsDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.RaceDto, ActionRecord.RaceDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.CategoryDto, ActionRecord.CategoryDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.CheckpointDto, ActionRecord.CheckpointDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.RacerDto, ActionRecord.RacerDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.NoteDto, ActionRecord.NoteDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.DogDto, ActionRecord.DogDto>();

            typeAdapterConfig.NewConfig<ActionRecord, AddActionResponse>();

            typeAdapterConfig.NewConfig<DeleteActionRequest, ActionRecord>()
                .MapWith(s => new ActionRecord { Id = s.Id });

            typeAdapterConfig.NewConfig<GetActionRequest, ActionRecord>()
                .Map(d => d.Id, s => s.Id)
                .Ignore(d => d.Name)
                .Ignore(d => d.Owner)
                .Ignore(d => d.Description)
                .Ignore(d => d.Term)
                .Ignore(d => d.Address)
                .Ignore(d => d.Races)
                .Ignore(d => d.Flags);

            typeAdapterConfig.NewConfig<ActionRecord, GetActionResponse>();
            typeAdapterConfig.NewConfig<ActionRecord.OwnerDto, GetActionResponse.OwnerDto>();
            typeAdapterConfig.NewConfig<ActionRecord.TermDto, GetActionResponse.TermDto>();
            typeAdapterConfig.NewConfig<ActionRecord.AddressDto, GetActionResponse.AddressDto>();
            typeAdapterConfig.NewConfig<ActionRecord.FlagsDto, GetActionResponse.FlagsDto>();
            typeAdapterConfig.NewConfig<ActionRecord.RaceDto, GetActionResponse.RaceDto>();
            typeAdapterConfig.NewConfig<ActionRecord.CategoryDto, GetActionResponse.CategoryDto>();
            typeAdapterConfig.NewConfig<ActionRecord.CheckpointDto, GetActionResponse.CheckpointDto>();
            typeAdapterConfig.NewConfig<ActionRecord.RacerDto, GetActionResponse.RacerDto>();
            typeAdapterConfig.NewConfig<ActionRecord.NoteDto, GetActionResponse.NoteDto>();
            typeAdapterConfig.NewConfig<ActionRecord.DogDto, GetActionResponse.DogDto>();

            typeAdapterConfig.NewConfig<ActionRecord, GetAllActionsResponse.ActionDto>();
            typeAdapterConfig.NewConfig<ActionRecord.OwnerDto, GetAllActionsResponse.OwnerDto>();
            typeAdapterConfig.NewConfig<ActionRecord.TermDto, GetAllActionsResponse.TermDto>();
            typeAdapterConfig.NewConfig<ActionRecord.AddressDto, GetAllActionsResponse.AddressDto>();
            typeAdapterConfig.NewConfig<ActionRecord.FlagsDto, GetAllActionsResponse.FlagsDto>();
            typeAdapterConfig.NewConfig<ActionRecord.RaceDto, GetAllActionsResponse.RaceDto>();
            
            typeAdapterConfig.NewConfig<ActionRecord, GetAllActionsWithDetailsResponse.ActionDto>();
            typeAdapterConfig.NewConfig<ActionRecord.OwnerDto, GetAllActionsWithDetailsResponse.OwnerDto>();
            typeAdapterConfig.NewConfig<ActionRecord.TermDto, GetAllActionsWithDetailsResponse.TermDto>();
            typeAdapterConfig.NewConfig<ActionRecord.AddressDto, GetAllActionsWithDetailsResponse.AddressDto>();
            typeAdapterConfig.NewConfig<ActionRecord.FlagsDto, GetAllActionsWithDetailsResponse.FlagsDto>();
            typeAdapterConfig.NewConfig<ActionRecord.RaceDto, GetAllActionsWithDetailsResponse.RaceDto>();
            typeAdapterConfig.NewConfig<ActionRecord.CategoryDto, GetAllActionsWithDetailsResponse.CategoryDto>();
            typeAdapterConfig.NewConfig<ActionRecord.CheckpointDto, GetAllActionsWithDetailsResponse.CheckpointDto>();
            typeAdapterConfig.NewConfig<ActionRecord.RacerDto, GetAllActionsWithDetailsResponse.RacerDto>();
            typeAdapterConfig.NewConfig<ActionRecord.NoteDto, GetAllActionsWithDetailsResponse.NoteDto>();
            typeAdapterConfig.NewConfig<ActionRecord.DogDto, GetAllActionsWithDetailsResponse.DogDto>();

            return typeAdapterConfig;
        }
    }
}
