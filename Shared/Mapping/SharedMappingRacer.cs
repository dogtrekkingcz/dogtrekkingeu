using DogtrekkingCzShared.Entities;
using DogtrekkingCzShared.Extensions;
using Mapster;

namespace DogtrekkingCzShared.Mapping
{
    public static class SharedMappingRacer
    {
        public static TypeAdapterConfig AddSharedMappingRacer(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<RacerDto, Protos.Shared.Racer>()
                .IgnoreNullValues(true)
                .Map(d => d.Start, s => (Google.Type.DateTime) s.Start.Value.ToGoogleDateTime())
                .Map(d => d.Finish, s => (Google.Type.DateTime) s.Finish.Value.ToGoogleDateTime());

            typeAdapterConfig.NewConfig<Protos.Shared.Racer, RacerDto>()
                .IgnoreNullValues(true)
                .Map(d => d.Start, s => s.Start.ToDateTimeOffset())
                .Map(d => d.Finish, s => s.Finish.ToDateTimeOffset());

            typeAdapterConfig.NewConfig<RacerDto, RacerDto>();

            return typeAdapterConfig;
        }
    }
}
