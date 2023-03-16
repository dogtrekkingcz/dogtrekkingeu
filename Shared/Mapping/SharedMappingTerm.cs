using Mapster;
using DogtrekkingCz.Shared.Entities;
using DogtrekkingCz.Shared.Extensions;

namespace DogtrekkingCz.Shared.Mapping
{
    public static class SharedMappingTerm
    {
        public static TypeAdapterConfig AddSharedMappingTerm(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<TermDto, Google.Type.Interval>()
                .MapWith(s => new Google.Type.Interval { StartTime = s.From.ToGoogleTimestamp(), EndTime = s.To.ToGoogleTimestamp() });

            typeAdapterConfig.NewConfig<Google.Type.Interval, TermDto>()
                .MapWith(s => new TermDto { From = s.StartTime.ToDateTimeOffset(), To = s.EndTime.ToDateTimeOffset() });

            typeAdapterConfig.NewConfig<TermDto, TermDto>();

            return typeAdapterConfig;
        }
    }
}
