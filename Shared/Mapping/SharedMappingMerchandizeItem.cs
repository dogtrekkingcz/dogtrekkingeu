using Mapster;
using SharedCode.Entities;

namespace SharedCode.Mapping
{
    public static class SharedMappingMerchandizeItem
    {
        public static TypeAdapterConfig AddSharedMappingMerchandizeItem(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<MerchandizeItemDto, Protos.Shared.MerchandizeItem>()
                .TwoWays();
            
            typeAdapterConfig.NewConfig<MerchandizeItemDto, MerchandizeItemDto>();
            
            return typeAdapterConfig;
        }
    }
}
