using DogtrekkingCzShared.Entities;
using Mapster;

namespace DogtrekkingCzShared.Mapping
{
    public static class SharedMappingActionRights
    {
        public static TypeAdapterConfig AddSharedMappingActionRights(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<ActionRightsDto, Protos.Shared.ActionRights>()
                .TwoWays();

            typeAdapterConfig.NewConfig<ActionRightsDto, ActionRightsDto>()
                .TwoWays();

            return typeAdapterConfig;
        }
    }
}
