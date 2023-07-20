using SharedCode.Extensions;
using Mapster;
using Protos.Shared;
using SharedCode.Entities;

namespace SharedCode.Mapping
{
    public static class 
        SharedMappingEntry
    {
        public static TypeAdapterConfig AddSharedMappingEntry(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<EntryDto, EntryDto>()
                .TwoWays();

            typeAdapterConfig.NewConfig<EntryDto.DogDto, EntryDto.DogDto>()
                .TwoWays();

            typeAdapterConfig.NewConfig<EntryDto, Protos.Shared.Entry>()
                .IgnoreNullValues(true)
                .Map(d => d.Created, s => s.Created.ToGoogleDateTime())
                .Map(d => d.Birthday, s => s.Birthday.Value.ToGoogleDateTime());

            typeAdapterConfig.NewConfig<Protos.Shared.Entry, EntryDto>()
                .IgnoreNullValues(true)
                .Map(d => d.Created, s => s.Created.ToDateTimeOffset())
                .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset());

            typeAdapterConfig.NewConfig<EntryDto.DogDto, Protos.Shared.EntryDog>()
                .IgnoreNullValues(true)
                .Map(d => d.Birthday, s => s.Birthday != null ? s.Birthday.Value.ToGoogleDateTime() : null);

            typeAdapterConfig.NewConfig<Protos.Shared.EntryDog, EntryDto.DogDto>()
                .IgnoreNullValues(true)
                .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset());

            typeAdapterConfig.NewConfig<Protos.Shared.MerchandizeItem, EntryDto.MerchandizeItemDto>()
                .IgnoreNullValues(true)
                .TwoWays();

            typeAdapterConfig.NewConfig<EntryDto.MerchandizeItemDto, EntryDto.MerchandizeItemDto>()
                .IgnoreNullValues(true)
                .TwoWays();
            
            return typeAdapterConfig;
        }
    }
}
