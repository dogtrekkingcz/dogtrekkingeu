using DogtrekkingCzShared.Entities;
using Mapster;

namespace DogtrekkingCzShared.Mapping
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
            
            return typeAdapterConfig;
        }
    }
}
