using DogsOnTrailApp.Extensions;
using Mapster;

namespace DogsOnTrailApp.Models;

internal static class CheckpointModelMapping
{
    internal static TypeAdapterConfig AddCheckpointModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<CheckpointModel, Protos.Checkpoints.AddCheckpoint.AddCheckpointRequest>()
            .IgnoreNullValues(true);
        typeAdapterConfig.NewConfig<CheckpointModel.LatLngDto, Google.Type.LatLng>();

        typeAdapterConfig.NewConfig<Protos.Checkpoints.GetCheckpoints.CheckpointItem, CheckpointModel>()
            .Map(d => d.Created, s => s.Created.ToDateTimeOffset())
            .Map(d => d.CheckpointTime, s => s.CheckpointTime.ToDateTimeOffset())
            .Map(d => d.ServerTime, s => s.ServerTime.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Google.Type.LatLng, CheckpointModel.LatLngDto>();

        return typeAdapterConfig;
    }
}