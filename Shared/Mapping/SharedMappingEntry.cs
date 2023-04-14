using DogtrekkingCzShared.Entities;
using Mapster;

namespace DogtrekkingCzShared.Mapping
{
    public static class SharedMappingEntry
    {
        public static TypeAdapterConfig AddSharedMappingEntry(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<EntryDto, EntryDto>()
                .TwoWays();

            typeAdapterConfig.NewConfig<EntryDto.DogDto, EntryDto.DogDto>()
                .TwoWays();

            typeAdapterConfig.NewConfig<EntryDto, Protos.Shared.Entry>()
                .TwoWays();

            typeAdapterConfig.NewConfig<EntryDto.DogDto, Protos.Shared.EntryDog>()
                .TwoWays();

            return typeAdapterConfig;
        }
    }
}
