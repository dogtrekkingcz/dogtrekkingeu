using PetsOnTrail.Interfaces.Actions.Entities.Activities;
using Mapster;
using Storage.Entities.Activities;

namespace PetsOnTrail.Actions.Services.Checkpoints;

internal static class ActivitiesServiceMapping
{
    public static TypeAdapterConfig AddActivitiesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<CreateActivityRequest, CreateActivityInternalStorageRequest>()
            .Ignore(d => d.Id)
            .Ignore(d => d.UserId);
        typeAdapterConfig.NewConfig<CreateActivityRequest.PositionDto, CreateActivityInternalStorageRequest.PositionDto>()
            .Ignore(d => d.Id);
        typeAdapterConfig.NewConfig<CreateActivityInternalStorageResponse, CreateActivityResponse>();

        typeAdapterConfig.NewConfig<AddPointRequest, AddPointInternalStorageRequest>()
            .Ignore(d => d.Id);
        typeAdapterConfig.NewConfig<AddPointInternalStorageResponse, AddPointResponse>();

        typeAdapterConfig.NewConfig<GetActivitiesByUserIdInternalStorageResponse, GetMyActivitiesResponse>();
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdInternalStorageResponse.ActivityDto, GetMyActivitiesResponse.ActivityDto>();

        typeAdapterConfig.NewConfig<UpdateActivityRequest, UpdateActivityInternalStorageRequest>();
        typeAdapterConfig.NewConfig<UpdateActivityRequest.PositionDto, UpdateActivityInternalStorageRequest.ActivityPointDto>();
        
        return typeAdapterConfig;
    }
}