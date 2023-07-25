using Mapster;
using SharedCode.Entities;
using SharedCode.Extensions;

namespace SharedCode.Mapping
{
    public static class SharedMappingPayment
    {
        public static TypeAdapterConfig AddSharedMappingPayment(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<PaymentDto, Protos.Shared.Payment>()
                .IgnoreNullValues(true)
                .Map(d => d.Date, s => s.Date.ToGoogleDateTime());

            // typeAdapterConfig.NewConfig<Protos.Shared.Payment, PaymentDto>()
            //     .IgnoreNullValues(true)
            //     .Map(d => d.Date, s => (DateTimeOffset?) (s.Date != null ? s.Date.ToDateTimeOffset() : null));

            typeAdapterConfig.NewConfig<PaymentDto, PaymentDto>();
            
            return typeAdapterConfig;
        }
    }
}
