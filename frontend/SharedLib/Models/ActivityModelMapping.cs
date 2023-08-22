using Google.Protobuf.Collections;
using Mapster;
using Protos.Activities.GetMyActivities;
using SharedLib.Extensions;

namespace SharedLib.Models;

 internal static class ActivityModelMapping
{
    internal static TypeAdapterConfig AddActivityModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Activities.GetMyActivities.GetMyActivitiesResponse, List<ActivityModel>>()
            .Map(d => d, s => s.Activities.ToList());
        typeAdapterConfig.NewConfig<Protos.Activities.GetMyActivities.ActivityDto, ActivityModel>();

        return typeAdapterConfig;
    }
}