using Mapster;
using Storage.Entities.Checkpoints;
using Storage.Entities.Dogs;
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
                .Map(d => d.Id, s => s.Id.ToGuid())
                .Map(d => d.ActionId, s => s.ActionId.ToGuid())
                .Map(d => d.CheckpointId, s => s.CheckpointId.ToGuid());
            typeAdapterConfig.NewConfig<CheckpointRecord.LatLngDto, GetCheckpointItemsInternalStorageResponse.LatLngDto>();
            
            return typeAdapterConfig;
        }
    }
}