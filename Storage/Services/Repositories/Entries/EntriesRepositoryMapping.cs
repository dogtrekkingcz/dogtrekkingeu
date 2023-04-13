using Mapster;
using Storage.Entities.Entries;
using Storage.Models;

namespace Storage.Services.Repositories.Entries
{
    internal static class EntriesRepositoryMapping
    {
        internal static TypeAdapterConfig AddEntriesRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<CreateEntryStorageRequest, EntryRecord>()
                .Ignore(d => d.Id);

            return typeAdapterConfig;
        }
    }
}