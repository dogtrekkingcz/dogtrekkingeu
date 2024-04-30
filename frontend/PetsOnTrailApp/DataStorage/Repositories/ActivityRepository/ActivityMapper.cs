using Mapster;
using PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;
using PetsOnTrailApp.Models;
using Protos.Activities.GetActivityByUserIdAndActivityId;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public static class ActivityMapper
{
    public static TypeAdapterConfig AddActivityMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponse, GetActivityByUserIdAndActivityIdResponseModel>();
        typeAdapterConfig.NewConfig<PositionDto, GetActivityByUserIdAndActivityIdResponseModel.PositionDto>();
        typeAdapterConfig.NewConfig<PetDto, GetActivityByUserIdAndActivityIdResponseModel.PetDto>();

        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponseModel, ActivityModel>()
            .Map(d => d.SynchronizedAt, s => DateTime.Now);
        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponseModel.PositionDto, ActivityModel.PositionDto>();
        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponseModel.PetDto, ActivityModel.PetDto>();

        return typeAdapterConfig;
    }
}
