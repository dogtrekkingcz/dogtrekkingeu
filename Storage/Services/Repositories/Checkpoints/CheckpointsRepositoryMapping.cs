using Mapster;
using Storage.Entities.Checkpoints;
using Storage.Extensions;
using Storage.Models;

namespace Storage.Services.Repositories.Checkpoints
{
    internal static class CheckpointsRepositoryMapping
    {
        internal static TypeAdapterConfig AddCheckpointsRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddCheckpointItemInternalStorageRequest, CheckpointRecord>()
                .Ignore(d => d.CorrelationId);
            typeAdapterConfig.NewConfig<AddCheckpointItemInternalStorageRequest.LatLngDto, CheckpointRecord.LatLngDto>();
            typeAdapterConfig.NewConfig<CheckpointRecord, AddCheckpointItemInternalStorageResponse>();

            typeAdapterConfig.NewConfig<CheckpointRecord, GetCheckpointItemsInternalStorageResponse.CheckpointItemDto>()
                .IgnoreNullValues(true);
            typeAdapterConfig.NewConfig<CheckpointRecord.LatLngDto, GetCheckpointItemsInternalStorageResponse.LatLngDto>();

            typeAdapterConfig.NewConfig<CheckpointRecord, GetCheckpointItemInternalStorageResponse>()
                .IgnoreNullValues(true);
            typeAdapterConfig.NewConfig<CheckpointRecord.LatLngDto, GetCheckpointItemInternalStorageResponse.LatLngDto>();
            
            return typeAdapterConfig;
        }
    }
}