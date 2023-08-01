using Mapster;

namespace DogsOnTrailApp.Models;

internal static class CheckpointModelMapping
{
    internal static TypeAdapterConfig AddCheckpointModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<CheckpointModel, Protos.Checkpoints.AddCheckpoint.AddCheckpointRequest>();
        typeAdapterConfig.NewConfig<CheckpointModel.LatLngDto, Google.Type.LatLng>();

        return typeAdapterConfig;
    }
}