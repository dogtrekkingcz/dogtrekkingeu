using API.WebApiService.Entities;
using Mapster;

namespace API.WebApiService.RequestHandlers.Activities;

internal static class ActivitiesMapping
{
    internal static TypeAdapterConfig AddActivitiesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<CreateActivityRequest, PetsOnTrail.Interfaces.Actions.Entities.Activities.CreateActivityRequest>();
        typeAdapterConfig.NewConfig<CreateActivityRequest.ActivityPointDto, PetsOnTrail.Interfaces.Actions.Entities.Activities.CreateActivityRequest.PositionDto>();
        typeAdapterConfig.NewConfig<CreateActivityRequest.ActivityPetDto, PetsOnTrail.Interfaces.Actions.Entities.Activities.CreateActivityRequest.PetDto>();
        typeAdapterConfig.NewConfig<PetsOnTrail.Interfaces.Actions.Entities.Activities.CreateActivityResponse, CreateActivityResponse>();

        typeAdapterConfig.NewConfig<UpdateActivityRequest, PetsOnTrail.Interfaces.Actions.Entities.Activities.UpdateActivityRequest>();
        typeAdapterConfig.NewConfig<UpdateActivityRequest.ActivityPointDto, PetsOnTrail.Interfaces.Actions.Entities.Activities.UpdateActivityRequest.PositionDto>();
        typeAdapterConfig.NewConfig<PetsOnTrail.Interfaces.Actions.Entities.Activities.UpdateActivityResponse, UpdateActivityResponse>();

        return typeAdapterConfig;
    }
}