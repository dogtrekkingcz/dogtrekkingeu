using SharedCode.Entities;
using Mapster;
using Storage.Entities.Entries;
using Storage.Models;

namespace Storage.Services.Repositories.Entries
{
    internal static class EntriesRepositoryMapping
    {
        internal static TypeAdapterConfig AddEntriesRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest, EntryRecord>()
                .Ignore(d => d.Id);

            typeAdapterConfig.NewConfig<EntryRecord, EntryDto>()
                .TwoWays();

            typeAdapterConfig.NewConfig<EntryRecord, GetEntryResponse>()
                .IgnoreNullValues(true);
            
            return typeAdapterConfig;
        }
    }
}