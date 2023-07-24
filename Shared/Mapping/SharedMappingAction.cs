using Mapster;
using SharedCode.Entities;

namespace SharedCode.Mapping
{
    public static class SharedMappingAction
    {
        public static TypeAdapterConfig AddSharedMappingAction(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<Action___Dto, Protos.Shared.ActionDetail>()
                .TwoWays();

            typeAdapterConfig.NewConfig<Action___Dto, Protos.Shared.ActionSimple>()
                .TwoWays();

            typeAdapterConfig.NewConfig<Action___Dto, Action___Dto>()
                .TwoWays();

            typeAdapterConfig.NewConfig<Action___Dto.ActionSaleDto, Action___Dto.ActionSaleDto>()
                .TwoWays();

            typeAdapterConfig.NewConfig<Action___Dto.ActionSaleItemDto, Action___Dto.ActionSaleItemDto>()
                .TwoWays();
            
            return typeAdapterConfig;
        }
    }
}
