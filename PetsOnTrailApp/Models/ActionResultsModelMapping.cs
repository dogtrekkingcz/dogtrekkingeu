using Mapster;
using PetsOnTrailApp.Extensions;

namespace PetsOnTrailApp.Models;

internal static class ActionResultsModelMapping
{
    internal static TypeAdapterConfig AddActionResultsModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Actions.GetResultsForAction.GetResultsForActionResponse, ActionResultsModel>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetResultsForAction.RaceResultsDto, ActionResultsModel.RaceResultsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetResultsForAction.CategoryResultsDto, ActionResultsModel.CategoryResultsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetResultsForAction.RaceState, ActionResultsModel.RaceState>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetResultsForAction.RacerResultsDto, ActionResultsModel.RacerResultDto>()
            .IgnoreNullValues(true)
            .Map(d => d.Start, s => s.Start.ToDateTimeOffset())
            .Map(d => d.Finish, s => s.Finish.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetResultsForAction.PassedCheckpointDto, ActionResultsModel.PassedCheckpointDto>()
            .Map(d => d.Passed, s => s.Passed.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetResultsForAction.PetDto, ActionResultsModel.PetDto>()
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Google.Type.LatLng, ActionResultsModel.LatLngDto>();
            
        return typeAdapterConfig;
    }
}