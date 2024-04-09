using PetsOnTrail.Interfaces.Actions.Entities.Activities;
using PetsOnTrail.Interfaces.Actions.Entities.Checkpoints;
using Mapster;

namespace API.GRPCService.Services.Checkpoints;

internal static class ActivitiesServiceMapping
{
    internal static TypeAdapterConfig AddCActivitiesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Activities.CreateActivity.CreateActivityRequest, CreateActivityRequest>();
        typeAdapterConfig.NewConfig<Protos.Activities.CreateActivity.PositionDto, CreateActivityRequest.PositionDto>();
        typeAdapterConfig.NewConfig<CreateActivityResponse, Protos.Activities.CreateActivity.CreateActivityResponse>();

        typeAdapterConfig.NewConfig<Protos.Activities.AddPoint.AddPointRequest, AddPointRequest>();
        typeAdapterConfig.NewConfig<AddPointResponse, Protos.Activities.AddPoint.AddPointResponse>();

        typeAdapterConfig.NewConfig<Protos.Activities.GetMyActivities.GetMyActivitiesRequest, GetMyActivitiesRequest>();
        typeAdapterConfig.NewConfig<GetMyActivitiesResponse, Protos.Activities.GetMyActivities.GetMyActivitiesResponse>();
        typeAdapterConfig.NewConfig<GetMyActivitiesResponse.ActivityDto, Protos.Activities.GetMyActivities.ActivityDto>();

        return typeAdapterConfig;
    }
}