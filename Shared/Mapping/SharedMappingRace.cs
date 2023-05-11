using SharedCode.Extensions;
using Mapster;
using SharedCode.Entities;

namespace SharedCode.Mapping
{
    public static class SharedMappingRace
    {
        public static TypeAdapterConfig AddSharedMappingRace(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<RaceDto, Protos.Shared.RaceDetail>()
                .IgnoreNullValues(true)
                .Map(d => d.EnteringFrom, s => s.EnteringFrom.ToGoogleDateTime())
                .Map(d => d.EnteringTo, s => s.EnteringTo.ToGoogleDateTime())
                .Map(d => d.Begin, s => s.Begin.ToGoogleDateTime());

            typeAdapterConfig.NewConfig<Protos.Shared.RaceDetail, RaceDto>()
                .IgnoreNullValues(true)
                .Map(d => d.EnteringFrom, s => s.EnteringFrom.ToDateTimeOffset())
                .Map(d => d.EnteringTo, s => s.EnteringTo.ToDateTimeOffset())
                .Map(d => d.Begin, s => s.Begin.ToDateTimeOffset());

            typeAdapterConfig.NewConfig<Protos.Shared.RaceSimple, RaceDto>()
                .IgnoreNullValues(true)
                .TwoWays();

            typeAdapterConfig.NewConfig<RaceDto.PaymentDefinitionDto, Protos.Shared.PaymentDefinition>()
                .IgnoreNullValues(true)
                .Map(d => d.From, s => s.From.ToGoogleDateTime())
                .Map(d => d.To, s => s.To.ToGoogleDateTime());

            typeAdapterConfig.NewConfig<Protos.Shared.PaymentDefinition, RaceDto.PaymentDefinitionDto>()
                .IgnoreNullValues(true)
                .Map(d => d.From, s => s.From.ToDateTimeOffset())
                .Map(d => d.To, s => s.To.ToDateTimeOffset());

            typeAdapterConfig.NewConfig<RaceDto, Protos.Shared.RaceSimple>()
                .IgnoreNullValues(true);
            typeAdapterConfig.NewConfig<Protos.Shared.RaceSimple, RaceDto>()
                .Ignore(d => d.Payments)
                .Ignore(d => d.EnteringTo)
                .Ignore(d => d.EnteringFrom)
                .Ignore(d => d.Begin)
                .Ignore(d => d.MaxNumberOfCompetitors);

            typeAdapterConfig.NewConfig<RaceDto, RaceDto>();

            typeAdapterConfig.NewConfig<RaceDto.PaymentDefinitionDto, RaceDto.PaymentDefinitionDto>();
            
            return typeAdapterConfig;
        }
    }
}
