using PetsOnTrail.Interfaces.Actions.Entities.Checkpoints;
using Mapster;

namespace API.GRPCService.Services.Checkpoints;

internal static class CheckpointsServiceMapping
{
    internal static TypeAdapterConfig AddCheckpointsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Checkpoints.AddCheckpoint.AddCheckpointRequest, AddCheckpointItemRequest>()
            .IgnoreNullValues(true);
        typeAdapterConfig.NewConfig<Google.Type.LatLng, AddCheckpointItemRequest.LatLngDto>();
        typeAdapterConfig.NewConfig<AddCheckpointItemResponse, Protos.Checkpoints.AddCheckpoint.AddCheckpointResponse>();

        typeAdapterConfig.NewConfig<Protos.Checkpoints.GetCheckpoints.GetCheckpointsRequest, GetCheckpointItemsRequest>()
            .IgnoreNullValues(true);
        typeAdapterConfig.NewConfig<Google.Type.LatLng, GetCheckpointItemsRequest.LatLngDto>()
            .Map(d => d.Longitude, s => s.Longitude)
            .Map(d => d.Latitude, s => s.Latitude);
        typeAdapterConfig.NewConfig<GetCheckpointItemsResponse, Protos.Checkpoints.GetCheckpoints.GetCheckpointsResponse>()
            .IgnoreNullValues(true);
        typeAdapterConfig.NewConfig<GetCheckpointItemsResponse.CheckpointItemDto, Protos.Checkpoints.GetCheckpoints.CheckpointItem>()
            .IgnoreNullValues(true);
        typeAdapterConfig.NewConfig<GetCheckpointItemsResponse.LatLngDto, Google.Type.LatLng>();
            
        return typeAdapterConfig;
    }
}