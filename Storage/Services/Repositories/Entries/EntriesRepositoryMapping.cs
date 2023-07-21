using SharedCode.Entities;
using Mapster;
using Storage.Entities.Entries;
using Storage.Extensions;
using Storage.Models;

namespace Storage.Services.Repositories.Entries
{
    internal static class EntriesRepositoryMapping
    {
        internal static TypeAdapterConfig AddEntriesRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest, EntryRecord>()
                .Ignore(d => d.Id)
                .Map(d => d.ActionId, s => s.ActionId.ToString())
                .Map(d => d.RaceId, s => s.RaceId.ToString())
                .Map(d => d.CategoryId, s => s.CategoryId.ToString());

            typeAdapterConfig.NewConfig<EntryRecord, EntryDto>()
                .Map(d => d.ActionId, s => s.ActionId.ToGuid())
                .Map(d => d.RaceId, s => s.RaceId.ToGuid())
                .Map(d => d.CategoryId, s => s.CategoryId.ToGuid());

            typeAdapterConfig.NewConfig<EntryDto, EntryRecord>()
                .Map(d => d.ActionId, s => s.ActionId.ToString())
                .Map(d => d.RaceId, s => s.RaceId.ToString())
                .Map(d => d.CategoryId, s => s.CategoryId.ToString());

            typeAdapterConfig.NewConfig<EntryRecord, GetEntryResponse>()
                .IgnoreNullValues(true);
            
            return typeAdapterConfig;
        }
    }
}