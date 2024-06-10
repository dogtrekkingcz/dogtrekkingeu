using PetsOnTrail.Interfaces.Actions.Entities.Activities;
using Mapster;
using Storage.Entities.Activities;
using Storage.Entities.ActivityTypes;
using Amazon.Auth.AccessControlPolicy;

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
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdInternalStorageResponse.PositionDto, GetMyActivitiesResponse.PositionDto>();
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdInternalStorageResponse.PetDto, GetMyActivitiesResponse.PetDto>();

        typeAdapterConfig.NewConfig<GetActivitiesInternalStorageResponse, GetActivitiesResponse>();
        typeAdapterConfig.NewConfig<GetActivitiesInternalStorageResponse.ActivityDto, GetActivitiesResponse.ActivityDto>();
        typeAdapterConfig.NewConfig<GetActivitiesInternalStorageResponse.PositionDto, GetActivitiesResponse.PositionDto>();
        typeAdapterConfig.NewConfig<GetActivitiesInternalStorageResponse.PetDto, GetActivitiesResponse.PetDto>();

        typeAdapterConfig.NewConfig<UpdateActivityRequest, UpdateActivityInternalStorageRequest>();
        typeAdapterConfig.NewConfig<UpdateActivityRequest.PositionDto, UpdateActivityInternalStorageRequest.PositionDto>();
        typeAdapterConfig.NewConfig<UpdateActivityRequest.PetDto, UpdateActivityInternalStorageRequest.PetDto>();

        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdInternalStorageResponse, GetActivityByUserIdAndActivityIdResponse>();
        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdInternalStorageResponse.PositionDto, GetActivityByUserIdAndActivityIdResponse.PositionDto>();
        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdInternalStorageResponse.PetDto, GetActivityByUserIdAndActivityIdResponse.PetDto>();

        typeAdapterConfig.NewConfig<GetAllActivityTypesInternalStorageResponse, GetActivityTypesResponse>();
        typeAdapterConfig.NewConfig<GetAllActivityTypesInternalStorageResponse.ActivityTypeDto, GetActivityTypesResponse.ActivityTypeDto>();

        typeAdapterConfig.NewConfig<GetActivitiesByUserIdInternalStorageResponse, GetActivitiesByUserIdResponse>();
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdInternalStorageResponse.ActivityDto, GetActivitiesByUserIdResponse.ActivityDto>();
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdInternalStorageResponse.PositionDto, GetActivitiesByUserIdResponse.PositionDto>();
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdInternalStorageResponse.PetDto, GetActivitiesByUserIdResponse.PetDto>();

        typeAdapterConfig.NewConfig<AddPointsRequest.PointDto, UpdateActivityInternalStorageRequest.PositionDto>()
            .Map(d => d.PhotoUris, s => new List<string> { s.PhotoUris });
        typeAdapterConfig.NewConfig<UpdateActivityInternalStorageResponse, AddPointsResponse>();

        typeAdapterConfig.NewConfig<AddPointsRequest.PointDto, CreateActivityInternalStorageRequest.PositionDto>()
            .Map(d => d.PhotoUris, s => new List<string> { s.PhotoUris });
        typeAdapterConfig.NewConfig<CreateActivityInternalStorageResponse, AddPointsResponse>();


        return typeAdapterConfig;
    }
}