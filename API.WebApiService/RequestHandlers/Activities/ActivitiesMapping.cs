using Amazon.Auth.AccessControlPolicy;
using API.WebApiService.Entities;
using Mapster;

namespace API.WebApiService.RequestHandlers.Activities;

internal static class ActivitiesMapping
{
    internal static TypeAdapterConfig AddActivitiesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<CreateActivityRequest, PetsOnTrail.Interfaces.Actions.Entities.Activities.CreateActivityRequest>()
            .Map(dst => dst.UserId, src => Guid.Parse(src.UserId));
        typeAdapterConfig.NewConfig<CreateActivityRequest.PositionDto, PetsOnTrail.Interfaces.Actions.Entities.Activities.CreateActivityRequest.PositionDto>();
        typeAdapterConfig.NewConfig<CreateActivityRequest.PetDto, PetsOnTrail.Interfaces.Actions.Entities.Activities.CreateActivityRequest.PetDto>();
        typeAdapterConfig.NewConfig<PetsOnTrail.Interfaces.Actions.Entities.Activities.CreateActivityResponse, CreateActivityResponse>();

        typeAdapterConfig.NewConfig<UpdateActivityRequest, PetsOnTrail.Interfaces.Actions.Entities.Activities.UpdateActivityRequest>();
        typeAdapterConfig.NewConfig<UpdateActivityRequest.PositionDto, PetsOnTrail.Interfaces.Actions.Entities.Activities.UpdateActivityRequest.PositionDto>();
        typeAdapterConfig.NewConfig<UpdateActivityRequest.PetDto, PetsOnTrail.Interfaces.Actions.Entities.Activities.UpdateActivityRequest.PetDto>();
        typeAdapterConfig.NewConfig<PetsOnTrail.Interfaces.Actions.Entities.Activities.UpdateActivityResponse, UpdateActivityResponse>();

        return typeAdapterConfig;
    }
}