using Mapster;
using PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;
using PetsOnTrailApp.Extensions;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public static class ActivityMapper
{
    public static TypeAdapterConfig AddActivityMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Activities.GetActivityByUserIdAndActivityId.GetActivityByUserIdAndActivityIdResponse, GetActivityByUserIdAndActivityIdResponseModel>()
            .Map(d => d.Start, s => s.Start.ToDateTimeOffset())
            .Map(d => d.End, s => s.End.ToDateTimeOffset())
            .IgnoreNullValues(true);
        typeAdapterConfig.NewConfig<Protos.Activities.GetActivityByUserIdAndActivityId.PositionDto, GetActivityByUserIdAndActivityIdResponseModel.PositionDto>()
            .Map(d => d.Time, s => s.Time.ToDateTimeOffset())
            .IgnoreNullValues(true);
        typeAdapterConfig.NewConfig<Protos.Activities.GetActivityByUserIdAndActivityId.PetDto, GetActivityByUserIdAndActivityIdResponseModel.PetDto>()
            .Map(d => d.BirthDate, s => s.BirthDate.ToDateTimeOffset())
            .IgnoreNullValues(true);

        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponseModel, ActivityModel>()
            .Map(d => d.SynchronizedAt, s => DateTime.Now)
            .IgnoreNullValues(true);
        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponseModel.PositionDto, ActivityModel.PositionDto>()
            .Ignore(d => d.Course)
            .IgnoreNullValues(true);
        typeAdapterConfig.NewConfig<GetActivityByUserIdAndActivityIdResponseModel.PetDto, ActivityModel.PetDto>()
            .IgnoreNullValues(true);

        typeAdapterConfig.NewConfig<GetActivitiesByUserIdResponseModel, UserActivitiesModel>()
            .Map(d => d.SynchronizedAt, s => DateTime.Now);
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdResponseModel.ActivityDto, UserActivitiesModel.ActivityDto>();
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdResponseModel.PositionDto, UserActivitiesModel.PositionDto>();
        typeAdapterConfig.NewConfig<GetActivitiesByUserIdResponseModel.PetDto, UserActivitiesModel.PetDto>();

        typeAdapterConfig.NewConfig<Protos.Activities.GetActivitiesByUserId.GetActivitiesByUserIdResponse, GetActivitiesByUserIdResponseModel>()
            .Map(d => d.SynchronizedAt, s => DateTime.Now);
        typeAdapterConfig.NewConfig<Protos.Activities.GetActivitiesByUserId.ActivityDto, GetActivitiesByUserIdResponseModel.ActivityDto>()
            .Map(d => d.Start, s => s.Start.ToDateTimeOffset())
            .Map(d => d.End, s => s.End.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Activities.GetActivitiesByUserId.PositionDto, GetActivitiesByUserIdResponseModel.PositionDto>()
            .Map(d => d.Time, s => s.Time.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Activities.GetActivitiesByUserId.PetDto, GetActivitiesByUserIdResponseModel.PetDto>()
            .Map(d => d.BirthDate, s => s.BirthDate.ToDateTimeOffset());

        return typeAdapterConfig;
    }
}
