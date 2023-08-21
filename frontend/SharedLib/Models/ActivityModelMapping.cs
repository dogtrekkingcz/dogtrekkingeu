using Mapster;
using SharedLib.Extensions;

namespace SharedLib.Models;

 internal static class ActivityModelMapping
{
    internal static TypeAdapterConfig AddActivityModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Activities.GetMyActivities.ActivityDto, ActivityModel>();
        
        
        return typeAdapterConfig;
    }
}