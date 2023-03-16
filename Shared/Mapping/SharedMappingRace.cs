using Mapster;
using DogtrekkingCz.Shared.Entities;
using DogtrekkingCz.Shared.Extensions;

namespace DogtrekkingCz.Shared.Mapping
{
    public static class SharedMappingRace
    {
        public static TypeAdapterConfig AddSharedMappingRace(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<RaceDto, Protos.Shared.RaceDetail>()
                .IgnoreNullValues(true)
                .TwoWays();

            typeAdapterConfig.NewConfig<RaceDto, Protos.Shared.RaceSimple>();

            typeAdapterConfig.NewConfig<RaceDto, RaceDto>();

            return typeAdapterConfig;
        }
    }
}
