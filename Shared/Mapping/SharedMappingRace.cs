using DogtrekkingCzShared.Entities;
using Mapster;

namespace DogtrekkingCzShared.Mapping
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

            typeAdapterConfig.NewConfig<RaceDto.PaymentDefinitionDto, RaceDto.PaymentDefinitionDto>();

            return typeAdapterConfig;
        }
    }
}
