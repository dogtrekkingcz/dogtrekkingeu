using Mapster;
using SharedCode.Entities;
using SharedCode.Extensions;

namespace SharedCode.Mapping
{
    public static class SharedMappingRequestedPayments
    {
        public static TypeAdapterConfig AddSharedMappingRequestedPayments(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<RequestedPaymentsDto, RequestedPaymentsDto>();
            
            return typeAdapterConfig;
        }
    }
}
