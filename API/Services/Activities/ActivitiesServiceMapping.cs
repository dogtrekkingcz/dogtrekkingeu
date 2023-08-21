using DogsOnTrail.Interfaces.Actions.Entities.Activities;
using DogsOnTrail.Interfaces.Actions.Entities.Checkpoints;
using Mapster;
using Storage.Entities.Activities;
using Storage.Entities.Checkpoints;

namespace DogsOnTrail.Actions.Services.Checkpoints;

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
        
        return typeAdapterConfig;
    }
}