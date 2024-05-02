using Mapster;
using PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;
using PetsOnTrailApp.Models;
using Protos.Activities.GetActivityByUserIdAndActivityId;
using SharedLib.Extensions;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public static class ActivityMapper
{
    public static TypeAdapterConfig AddActivityMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponse, GetActivityByUserIdAndActivityIdResponseModel>()
            .Map(d => d.Start, s => s.Start.ToDateTimeOffset().Value.DateTime)
            .Map(d => d.End, s => s.End.ToDateTimeOffset().Value.DateTime);
        typeAdapterConfig.NewConfig<PositionDto, GetActivityByUserIdAndActivityIdResponseModel.PositionDto>()
            .Map(d => d.Time, s => s.Time.ToDateTimeOffset().Value.DateTime);
        typeAdapterConfig.NewConfig<PetDto, GetActivityByUserIdAndActivityIdResponseModel.PetDto>()
            .Map(d => d.BirthDate, s => s.BirthDate.ToDateTimeOffset().Value.DateTime);

        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponseModel, ActivityModel>()
            .Map(d => d.SynchronizedAt, s => DateTime.Now);
        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponseModel.PositionDto, ActivityModel.PositionDto>()
            .Ignore(d => d.Course);
        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponseModel.PetDto, ActivityModel.PetDto>();

        return typeAdapterConfig;
    }
}
