using Mapster;
using SharedCode.Entities;

namespace SharedCode.Mapping
{
    public static class SharedMappingAddress
    {
        public static TypeAdapterConfig AddSharedMappingAddress(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddressDto, Protos.Shared.Address>()
                .TwoWays();

            typeAdapterConfig.NewConfig<AddressDto, AddressDto>();

            return typeAdapterConfig;
        }
    }
}
