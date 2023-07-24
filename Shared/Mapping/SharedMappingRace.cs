using SharedCode.Extensions;
using Mapster;
using SharedCode.Entities;

namespace SharedCode.Mapping
{
    public static class SharedMappingRace
    {
        public static TypeAdapterConfig AddSharedMappingRace(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<Race___Dto, Protos.Shared.RaceDetail>()
                .IgnoreNullValues(true)
                .Map(d => d.EnteringFrom, s => s.EnteringFrom.ToGoogleDateTime())
                .Map(d => d.EnteringTo, s => s.EnteringTo.ToGoogleDateTime())
                .Map(d => d.Begin, s => s.Begin.ToGoogleDateTime());

            typeAdapterConfig.NewConfig<Protos.Shared.RaceDetail, Race___Dto>()
                .IgnoreNullValues(true)
                .Map(d => d.EnteringFrom, s => s.EnteringFrom.ToDateTimeOffset())
                .Map(d => d.EnteringTo, s => s.EnteringTo.ToDateTimeOffset())
                .Map(d => d.Begin, s => s.Begin.ToDateTimeOffset());

            typeAdapterConfig.NewConfig<Protos.Shared.RaceSimple, Race___Dto>()
                .IgnoreNullValues(true)
                .TwoWays();

            typeAdapterConfig.NewConfig<Race___Dto.PaymentDefinitionDto, Protos.Shared.PaymentDefinition>()
                .IgnoreNullValues(true)
                .Map(d => d.From, s => s.From.ToGoogleDateTime())
                .Map(d => d.To, s => s.To.ToGoogleDateTime());

            typeAdapterConfig.NewConfig<Protos.Shared.PaymentDefinition, Race___Dto.PaymentDefinitionDto>()
                .IgnoreNullValues(true)
                .Map(d => d.From, s => s.From.ToDateTimeOffset())
                .Map(d => d.To, s => s.To.ToDateTimeOffset());

            typeAdapterConfig.NewConfig<Race___Dto.LimitsDto, Protos.Shared.RaceLimits>()
                .IgnoreNullValues(true);
            typeAdapterConfig.NewConfig<Protos.Shared.RaceLimits, Race___Dto.LimitsDto>()
                .IgnoreNullValues(true);

            typeAdapterConfig.NewConfig<Race___Dto, Protos.Shared.RaceSimple>()
                .IgnoreNullValues(true);
            typeAdapterConfig.NewConfig<Protos.Shared.RaceSimple, Race___Dto>()
                .Ignore(d => d.Payments)
                .Ignore(d => d.EnteringTo)
                .Ignore(d => d.EnteringFrom)
                .Ignore(d => d.Begin)
                .Ignore(d => d.MaxNumberOfCompetitors);

            typeAdapterConfig.NewConfig<Race___Dto, Race___Dto>();

            typeAdapterConfig.NewConfig<Race___Dto.PaymentDefinitionDto, Race___Dto.PaymentDefinitionDto>();
            typeAdapterConfig.NewConfig<Race___Dto.LimitsDto, Race___Dto.LimitsDto>();
            
            return typeAdapterConfig;
        }
    }
}
