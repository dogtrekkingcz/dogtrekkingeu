using Mapster;
using Storage.Entities.ActivityTypes;
using Storage.Models;

namespace Storage.Services.Repositories.Actions
{
    internal static class ActivityTypeRepositoryMapping
    {
        internal static TypeAdapterConfig AddActivityTypeRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddActivityTypeInternalStorageRequest, ActivityTypeRecord>();
            typeAdapterConfig.NewConfig<ActivityTypeRecord, AddActivityTypeInternalStorageResponse>();

            typeAdapterConfig.NewConfig<ActivityTypeRecord, GetAllActivityTypesInternalStorageResponse.ActivityTypeDto>();
 
            return typeAdapterConfig;
        }
    }
}
