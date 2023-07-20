using Mapster;
using SharedCode.Entities;
using SharedCode.Extensions;

namespace SharedCode.Mapping
{
    public static class SharedMappingRequestedPayments
    {
        public static TypeAdapterConfig AddSharedMappingRequestedPayments(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<RequestedPaymentsDto, Protos.Shared.RequestedPaymentsDto>()
                .TwoWays();

            typeAdapterConfig.NewConfig<RequestedPaymentItem, Protos.Shared.RequestedPaymentItem>()
                .TwoWays();

            typeAdapterConfig.NewConfig<RequestedPaymentsDto, RequestedPaymentsDto>()
                .TwoWays();

            typeAdapterConfig.NewConfig<RequestedPaymentItem, RequestedPaymentItem>()
                .TwoWays();
            
            return typeAdapterConfig;
        }
    }
}
