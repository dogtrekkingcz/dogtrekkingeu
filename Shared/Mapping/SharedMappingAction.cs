using Mapster;
using SharedCode.Entities;

namespace SharedCode.Mapping
{
    public static class SharedMappingAction
    {
        public static TypeAdapterConfig AddSharedMappingAction(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<ActionDto, Protos.Shared.ActionDetail>()
                .TwoWays();

            typeAdapterConfig.NewConfig<ActionDto, Protos.Shared.ActionSimple>()
                .TwoWays();

            typeAdapterConfig.NewConfig<ActionDto, ActionDto>()
                .TwoWays();

            typeAdapterConfig.NewConfig<ActionDto.ActionSaleDto, ActionDto.ActionSaleDto>()
                .TwoWays();

            typeAdapterConfig.NewConfig<ActionDto.ActionSaleItemDto, ActionDto.ActionSaleItemDto>()
                .TwoWays();
            
            return typeAdapterConfig;
        }
    }
}
