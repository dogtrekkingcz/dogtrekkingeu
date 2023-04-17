using DogtrekkingCzShared.Entities;
using DogtrekkingCzShared.Extensions;
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
                .IgnoreNullValues(true)
                .Map(d => d.Created, s => s.Created.ToGoogleDateTime());

            typeAdapterConfig.NewConfig<Protos.Shared.Entry, EntryDto>()
                .IgnoreNullValues(true)
                .Map(d => d.Created, s => s.Created.ToDateTimeOffset());

            typeAdapterConfig.NewConfig<EntryDto.DogDto, Protos.Shared.EntryDog>()
                .IgnoreNullValues(true)
                .Map(d => d.Birthday, s => s.Birthday.ToGoogleDateTime());

            typeAdapterConfig.NewConfig<Protos.Shared.EntryDog, EntryDto.DogDto>()
                .IgnoreNullValues(true)
                .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset());

            return typeAdapterConfig;
        }
    }
}
