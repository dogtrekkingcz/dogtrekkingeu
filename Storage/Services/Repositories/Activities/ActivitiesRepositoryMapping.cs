using Mapster;
using Storage.Entities.Activities;
using Storage.Models;

namespace Storage.Services.Repositories.Activities
{
    internal static class ActivitiesRepositoryMapping
    {
        internal static TypeAdapterConfig AddActivitiesRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<CreateActivityInternalStorageRequest, ActivityRecord>();
            typeAdapterConfig.NewConfig<CreateActivityInternalStorageRequest.PositionDto, ActivityRecord.PositionDto>();
            typeAdapterConfig.NewConfig<ActivityRecord, CreateActivityInternalStorageResponse>();
            
            typeAdapterConfig.NewConfig<AddPointInternalStorageRequest, ActivityRecord.PositionDto>();
            typeAdapterConfig.NewConfig<ActivityRecord.PositionDto, AddPointInternalStorageResponse>();

            typeAdapterConfig.NewConfig<List<ActivityRecord>, GetActivitiesByUserIdInternalStorageResponse>()
                .Map(d => d.Activities, s => s);
            typeAdapterConfig.NewConfig<ActivityRecord, GetActivitiesByUserIdInternalStorageResponse.ActivityDto>();

            return typeAdapterConfig;
        }
    }
}