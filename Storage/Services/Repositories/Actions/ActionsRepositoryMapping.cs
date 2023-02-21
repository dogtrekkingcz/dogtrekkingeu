using DogtrekkingCz.Storage.Models;
using Mapster;
using Storage.Entities.Actions;

namespace Storage.Services.Repositories
{
    internal static class ActionsRepositoryMapping
    {
        internal static TypeAdapterConfig AddActionRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddActionRequest, ActionRecord>();
            typeAdapterConfig.NewConfig<AddActionRequest.TermDto, ActionRecord.TermDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.OwnerDto, ActionRecord.OwnerDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.AddressDto, ActionRecord.AddressDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.RaceDto, ActionRecord.RaceDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.CategoryDto, ActionRecord.CategoryDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.CheckpointDto, ActionRecord.CheckpointDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.RacerDto, ActionRecord.RacerDto>();
            typeAdapterConfig.NewConfig<AddActionRequest.DogDto, ActionRecord.DogDto>();


            typeAdapterConfig.NewConfig<UpdateActionRequest, ActionRecord>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.TermDto, ActionRecord.TermDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.OwnerDto, ActionRecord.OwnerDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.AddressDto, ActionRecord.AddressDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.RaceDto, ActionRecord.RaceDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.CategoryDto, ActionRecord.CategoryDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.CheckpointDto, ActionRecord.CheckpointDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.RacerDto, ActionRecord.RacerDto>();
            typeAdapterConfig.NewConfig<UpdateActionRequest.DogDto, ActionRecord.DogDto>();

            typeAdapterConfig.NewConfig<ActionRecord, AddActionResponse>();

            typeAdapterConfig.NewConfig<DeleteActionRequest, ActionRecord>()
                .MapWith(s => new ActionRecord { Id = s.Id });

            typeAdapterConfig.NewConfig<ActionRecord, GetAllActionsResponse.ActionDto>();
            typeAdapterConfig.NewConfig<ActionRecord.OwnerDto, GetAllActionsResponse.OwnerDto>();
            typeAdapterConfig.NewConfig<ActionRecord.TermDto, GetAllActionsResponse.TermDto>();
            typeAdapterConfig.NewConfig<ActionRecord.AddressDto, GetAllActionsResponse.AddressDto>();
            typeAdapterConfig.NewConfig<ActionRecord.RaceDto, GetAllActionsResponse.RaceDto>();
            typeAdapterConfig.NewConfig<ActionRecord.CategoryDto, GetAllActionsResponse.CategoryDto>();
            typeAdapterConfig.NewConfig<ActionRecord.CheckpointDto, GetAllActionsResponse.CheckpointDto>();
            typeAdapterConfig.NewConfig<ActionRecord.RacerDto, GetAllActionsResponse.RaceDto>();
            typeAdapterConfig.NewConfig<ActionRecord.DogDto, GetAllActionsResponse.DogDto>();

            return typeAdapterConfig;
        }
    }
}
