using DogsOnTrail.Interfaces.Actions.Entities.Checkpoints;
using Mapster;
using Storage.Entities.Checkpoints;

namespace DogsOnTrail.Actions.Services.Checkpoints;

internal static class CheckpointsServiceMapping
{
    public static TypeAdapterConfig AddCheckpointsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<AddCheckpointItemRequest, AddCheckpointItemInternalStorageRequest>()
            .Ignore(d => d.Id)
            .Ignore(d => d.UserId)
            .Ignore(d => d.Created)
            .Ignore(d => d.ServerTime);
        typeAdapterConfig.NewConfig<AddCheckpointItemRequest.LatLngDto, AddCheckpointItemInternalStorageRequest.LatLngDto>();
        typeAdapterConfig.NewConfig<AddCheckpointItemInternalStorageResponse, AddCheckpointItemResponse>();

        typeAdapterConfig.NewConfig<GetCheckpointItemsRequest, GetCheckpointItemsInternalStorageRequest>();
        typeAdapterConfig.NewConfig<GetCheckpointItemsInternalStorageResponse, GetCheckpointItemsResponse>();
        typeAdapterConfig.NewConfig<GetCheckpointItemsInternalStorageResponse.CheckpointItemDto, GetCheckpointItemsResponse.CheckpointItemDto>();
        typeAdapterConfig.NewConfig<GetCheckpointItemsInternalStorageResponse.LatLngDto, GetCheckpointItemsResponse.LatLngDto>();
        
        return typeAdapterConfig;
    }
}