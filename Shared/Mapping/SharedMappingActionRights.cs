using Mapster;
using DogtrekkingCz.Shared.Entities;
using DogtrekkingCzShared.Entities;

namespace DogtrekkingCz.Shared.Mapping
{
    public static class SharedMappingActionRights
    {
        public static TypeAdapterConfig AddSharedMappingActionRights(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<ActionRightsDto, Protos.Shared.ActionRights>()
                .TwoWays();

            typeAdapterConfig.NewConfig<ActionRightsDto, ActionRightsDto>();

            return typeAdapterConfig;
        }
    }
}
