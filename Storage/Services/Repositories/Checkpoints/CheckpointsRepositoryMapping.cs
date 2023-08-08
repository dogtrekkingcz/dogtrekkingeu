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
                .Map(d => d.Id, s => s.Id.ToString())
                .Map(d => d.ActionId, s => s.ActionId.ToString())
                .Map(d => d.CheckpointId, s => s.CheckpointId.ToString());
            typeAdapterConfig.NewConfig<AddCheckpointItemInternalStorageRequest.LatLngDto, CheckpointRecord.LatLngDto>();

            typeAdapterConfig.NewConfig<CheckpointRecord, AddCheckpointItemInternalStorageResponse>()
                .Map(d => d.Id, s => s.Id.ToGuid());

            typeAdapterConfig.NewConfig<CheckpointRecord, GetCheckpointItemsInternalStorageResponse.CheckpointItemDto>()
                .IgnoreNullValues(true)
                .Map(d => d.Id, s => s.Id.ToGuid())
                .Map(d => d.ActionId, s => s.ActionId.ToGuid())
                .Map(d => d.CheckpointId, s => s.CheckpointId.ToGuid())
                .Map(d => d.UserId, s => s.UserId.ToGuid());
            typeAdapterConfig.NewConfig<CheckpointRecord.LatLngDto, GetCheckpointItemsInternalStorageResponse.LatLngDto>();

            typeAdapterConfig.NewConfig<CheckpointRecord, GetCheckpointItemInternalStorageResponse>()
                .IgnoreNullValues(true)
                .Map(d => d.Id, s => s.Id.ToGuid())
                .Map(d => d.ActionId, s => s.ActionId.ToGuid())
                .Map(d => d.CheckpointId, s => s.CheckpointId.ToGuid())
                .Map(d => d.UserId, s => s.UserId.ToGuid());
            typeAdapterConfig.NewConfig<CheckpointRecord.LatLngDto, GetCheckpointItemInternalStorageResponse.LatLngDto>();
            
            return typeAdapterConfig;
        }
    }
}