using PetsOnTrail.Interfaces.Actions.Entities.Activities;
using Mapster;
using Storage.Entities.Activities;

namespace PetsOnTrail.Actions.Services.Checkpoints;

internal static class ActivitiesServiceMapping
{
    public static TypeAdapterConfig AddActivitiesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<CreateActivityRequest, CreateActivityInternalStorageRequest>()
            .Ignore(d => d.UserId);
        typeAdapterConfig.NewConfig<CreateActivityRequest.PositionDto, CreateActivityInternalStorageRequest.PositionDto>();
        typeAdapterConfig.NewConfig<CreateActivityRequest.PetDto, CreateActivityInternalStorageRequest.PetDto>();
        typeAdapterConfig.NewConfig<CreateActivityInternalStorageResponse, CreateActivityResponse>();

        typeAdapterConfig.NewConfig<AddPointRequest, AddPointInternalStorageRequest>()
            .Ignore(d => d.Id);
        typeAdapterConfig.NewConfig<AddPointInternalStorageResponse, AddPointResponse>();

        typeAdapterConfig.NewConfig<GetActivitiesByUserIdInternalStorageResponse, GetMyActivitiesResponse>();
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdInternalStorageResponse.ActivityDto, GetMyActivitiesResponse.ActivityDto>();

        typeAdapterConfig.NewConfig<UpdateActivityRequest, UpdateActivityInternalStorageRequest>();
        typeAdapterConfig.NewConfig<UpdateActivityRequest.PositionDto, UpdateActivityInternalStorageRequest.PositionDto>();
        
        return typeAdapterConfig;
    }
}