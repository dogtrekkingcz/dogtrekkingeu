using Mapster;
using DogtrekkingCz.Shared.Entities;
using DogtrekkingCz.Shared.Extensions;

namespace DogtrekkingCz.Shared.Mapping
{
    public static class SharedMappingCategory
    {
        public static TypeAdapterConfig AddSharedMappingCategory(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<CategoryDto, Protos.Shared.Category>()
                .TwoWays();

            return typeAdapterConfig;
        }
    }
}
