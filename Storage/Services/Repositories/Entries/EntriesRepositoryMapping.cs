using DogtrekkingCz.Storage.Entities.Entries;
using Mapster;
using Storage.Models;

namespace Storage.Services.Repositories
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