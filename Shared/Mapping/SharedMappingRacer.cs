using Mapster;
using DogtrekkingCz.Shared.Entities;
using DogtrekkingCz.Shared.Extensions;

namespace DogtrekkingCz.Shared.Mapping
{
    public static class SharedMappingRacer
    {
        public static TypeAdapterConfig AddSharedMappingRacer(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<RacerDto, Protos.Shared.Racer>()
                .IgnoreNullValues(true)
                .Map(d => d.Start, s => s.Start.Value.ToGoogleDateTime())
                .Map(d => d.Finish, s => s.Finish.Value.ToGoogleDateTime());

            typeAdapterConfig.NewConfig<Protos.Shared.Racer, RacerDto>()
                .IgnoreNullValues(true)
                .Map(d => d.Start, s => s.Start.ToDateTimeOffset())
                .Map(d => d.Finish, s => s.Finish.ToDateTimeOffset());

            return typeAdapterConfig;
        }
    }
}
