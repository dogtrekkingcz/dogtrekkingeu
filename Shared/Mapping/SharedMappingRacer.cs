using Mapster;
using SharedCode.Entities;
using SharedCode.Extensions;

namespace SharedCode.Mapping
{
    public static class SharedMappingRacer
    {
        public static TypeAdapterConfig AddSharedMappingRacer(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<Racer___Dto, Protos.Shared.Racer>()
                .IgnoreNullValues(true)
                .Map(d => d.Start, s => s.Start != null ? s.Start.Value.ToGoogleDateTime() : null)
                .Map(d => d.Finish, s => s.Finish != null ? s.Finish.Value.ToGoogleDateTime() : null);

            typeAdapterConfig.NewConfig<Protos.Shared.Racer, Racer___Dto>()
                .IgnoreNullValues(true)
                .Map(d => d.Start, s => (DateTimeOffset?)(s.Start != null ? s.Start.ToDateTimeOffset() : null))
                .Map(d => d.Finish, s => (DateTimeOffset?)(s.Finish != null ? s.Finish.ToDateTimeOffset() : null));

            typeAdapterConfig.NewConfig<Protos.Shared.RequestedPaymentsDto, RequestedPaymentsDto>();

            typeAdapterConfig.NewConfig<Protos.Shared.RequestedPaymentItem, RequestedPaymentItem>();

            typeAdapterConfig.NewConfig<Racer___Dto, Racer___Dto>();
            
            return typeAdapterConfig;
        }
    }
}
