using PetsOnTrail.Interfaces.Actions.Entities.Activities;
using PetsOnTrail.Interfaces.Actions.Entities.Checkpoints;
using Mapster;

namespace API.GRPCService.Services.Checkpoints;

internal static class ActivitiesServiceMapping
{
    internal static TypeAdapterConfig AddCActivitiesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Activities.CreateActivity.CreateActivityRequest, CreateActivityRequest>()
            .Map(d => d.Id, s => Guid.Parse(s.Id))
            .Map(d => d.ActionId, s => Guid.Parse(s.ActionId))
            .Map(d => d.RaceId, s => Guid.Parse(s.RaceId))
            .Map(d => d.CategoryId, s => Guid.Parse(s.CategoryId))
            .Map(d => d.TypeId, s => Guid.Parse(s.Type))
            .Ignore(d => d.UserId);
        typeAdapterConfig.NewConfig<Protos.Activities.CreateActivity.PositionDto, CreateActivityRequest.PositionDto>()
            .Map(d => d.Id, s => Guid.Parse(s.Id));
        typeAdapterConfig.NewConfig<Protos.Activities.CreateActivity.PetDto, CreateActivityRequest.PetDto>()
            .Map(d => d.Id, s => Guid.Parse(s.Id));

        typeAdapterConfig.NewConfig<CreateActivityResponse, Protos.Activities.CreateActivity.CreateActivityResponse>();

        typeAdapterConfig.NewConfig<Protos.Activities.AddPoint.AddPointRequest, AddPointRequest>();
        typeAdapterConfig.NewConfig<AddPointResponse, Protos.Activities.AddPoint.AddPointResponse>();

        typeAdapterConfig.NewConfig<Protos.Activities.GetMyActivities.GetMyActivitiesRequest, GetMyActivitiesRequest>();
        typeAdapterConfig.NewConfig<GetMyActivitiesResponse, Protos.Activities.GetMyActivities.GetMyActivitiesResponse>();
        typeAdapterConfig.NewConfig<GetMyActivitiesResponse.ActivityDto, Protos.Activities.GetMyActivities.ActivityDto>();
        typeAdapterConfig.NewConfig<GetMyActivitiesResponse.PetDto, Protos.Activities.GetMyActivities.PetDto>();
        typeAdapterConfig.NewConfig<GetMyActivitiesResponse.PositionDto, Protos.Activities.GetMyActivities.PositionDto>();

        typeAdapterConfig.NewConfig<GetActivitiesResponse, Protos.Activities.GetActivities.GetActivitiesResponse>();
        typeAdapterConfig.NewConfig<GetActivitiesResponse.ActivityDto, Protos.Activities.GetActivities.ActivityDto>();
        typeAdapterConfig.NewConfig<GetActivitiesResponse.PetDto, Protos.Activities.GetActivities.PetDto>();
        typeAdapterConfig.NewConfig<GetActivitiesResponse.PositionDto, Protos.Activities.GetActivities.PositionDto>();

        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponse, Protos.Activities.GetActivityByUserIdAndActivityId.GetActivityByUserIdAndActivityIdResponse>();
        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponse.PetDto, Protos.Activities.GetActivityByUserIdAndActivityId.PetDto>();
        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponse.PositionDto, Protos.Activities.GetActivityByUserIdAndActivityId.PositionDto>();

        typeAdapterConfig.NewConfig<GetActivityTypesResponse, Protos.Activities.GetActivityTypes.GetActivityTypesResponse>();
        typeAdapterConfig.NewConfig<GetActivityTypesResponse.ActivityTypeDto, Protos.Activities.GetActivityTypes.ActivityTypeDto>();

        typeAdapterConfig.NewConfig<GetActivitiesByUserIdResponse, Protos.Activities.GetActivitiesByUserId.GetActivitiesByUserIdResponse>();
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdResponse.ActivityDto, Protos.Activities.GetActivitiesByUserId.ActivityDto>();
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdResponse.PetDto, Protos.Activities.GetActivitiesByUserId.PetDto>();
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdResponse.PositionDto, Protos.Activities.GetActivitiesByUserId.PositionDto>();

        typeAdapterConfig.NewConfig<Protos.Activities.AddPoints.AddPointsRequest, AddPointsRequest>();
        typeAdapterConfig.NewConfig<AddPointsResponse, Protos.Activities.AddPoints.AddPointsResponse>();

        return typeAdapterConfig;
    }
}