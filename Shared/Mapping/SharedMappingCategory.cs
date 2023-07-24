using Mapster;
using SharedCode.Entities;

namespace SharedCode.Mapping
{
    public static class SharedMappingCategory
    {
        public static TypeAdapterConfig AddSharedMappingCategory(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<Category___Dto, Protos.Shared.Category>()
                .Map(d => d.Id, s => s.Id.ToString());

            typeAdapterConfig.NewConfig<Protos.Shared.Category, Category___Dto>()
                .Map(d => d.Id, s => Guid.Parse(s.Id));

            typeAdapterConfig.NewConfig<Category___Dto, Category___Dto>()
                .TwoWays();

            return typeAdapterConfig;
        }
    }
}
