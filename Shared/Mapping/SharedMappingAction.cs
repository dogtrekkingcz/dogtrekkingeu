using Mapster;
using DogtrekkingCz.Shared.Entities;

namespace DogtrekkingCz.Shared.Mapping
{
    public static class SharedMappingAction
    {
        public static TypeAdapterConfig AddSharedMappingAction(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<ActionDto, Protos.Shared.ActionDetail>()
                .TwoWays();

            typeAdapterConfig.NewConfig<ActionDto, Protos.Shared.ActionSimple>()
                .TwoWays();

            return typeAdapterConfig;
        }
    }
}
