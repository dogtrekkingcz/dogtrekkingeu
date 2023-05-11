using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using Mapster;
using Storage.Entities.Entries;

namespace DogsOnTrail.Actions.Services.EntriesManage;

internal static class EntriesServiceMapping
{
    public static TypeAdapterConfig AddEntriesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetEntriesByActionInternalStorageResponse, GetEntriesByActionResponse>();
        typeAdapterConfig.NewConfig<GetEntriesByActionRequest, GetEntriesByActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<CreateEntryRequest, CreateEntryInternalStorageRequest>();
        typeAdapterConfig.NewConfig<CreateEntryInternalStorageResponse, CreateEntryResponse>();

        typeAdapterConfig.NewConfig<GetAllEntriesRequest, GetAllEntriesInternalStorageRequest>();
        typeAdapterConfig.NewConfig<GetAllEntriesInternalStorageResponse, GetAllEntriesResponse>();
        
        return typeAdapterConfig;
    }
}