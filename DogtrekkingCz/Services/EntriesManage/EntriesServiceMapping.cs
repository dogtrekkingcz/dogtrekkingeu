using DogtrekkingCz.Interfaces.Actions.Entities.Entries;
using Mapster;
using Storage.Entities.Entries;

namespace DogtrekkingCz.Actions.Services.EntriesManage;

internal static class EntriesServiceMapping
{
    public static TypeAdapterConfig AddActionsMapping(this TypeAdapterConfig typeAdapterConfig)
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