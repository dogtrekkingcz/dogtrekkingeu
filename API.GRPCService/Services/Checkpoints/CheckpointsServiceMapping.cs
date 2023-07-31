using DogsOnTrail.Interfaces.Actions.Entities.Checkpoints;
using Mapster;

namespace API.GRPCService.Services.Checkpoints;

internal static class CheckpointsServiceMapping
{
    internal static TypeAdapterConfig AddCheckpointsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Checkpoints.AddCheckpoint.AddCheckpointRequest, AddCheckpointItemRequest>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, AddCheckpointItemRequest.LatLngDto>();
        typeAdapterConfig.NewConfig<AddCheckpointItemResponse, Protos.Checkpoints.AddCheckpoint.AddCheckpointResponse>();
        
        typeAdapterConfig.NewConfig<Protos.Checkpoints.GetCheckpoints.GetCheckpointsRequest, GetCheckpointItemsRequest>();
        typeAdapterConfig.NewConfig<GetCheckpointItemsResponse, Protos.Checkpoints.GetCheckpoints.GetCheckpointsResponse>();
        typeAdapterConfig.NewConfig<GetCheckpointItemsResponse.CheckpointItemDto, Protos.Checkpoints.GetCheckpoints.CheckpointItem>();
        typeAdapterConfig.NewConfig<GetCheckpointItemsResponse.LatLngDto, Google.Type.LatLng>();
            
        return typeAdapterConfig;
    }
}