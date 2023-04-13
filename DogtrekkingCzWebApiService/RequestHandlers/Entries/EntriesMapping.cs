using Mapster;

namespace DogtrekkingCzWebApiService.RequestHandlers.Entries;

internal static class EntriesMapping
{
    internal static TypeAdapterConfig AddEntriesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<DogtrekkingCzWebApiService.Entities.CreateEntryRequest, DogtrekkingCz.Entries.Interface.Entities.CreateEntryRequest>();
        typeAdapterConfig.NewConfig<DogtrekkingCz.Entries.Interface.Entities.CreateEntryResponse, DogtrekkingCzWebApiService.Entities.CreateEntryResponse>();

        typeAdapterConfig.NewConfig<DogtrekkingCzWebApiService.Entities.GetEntriesByActionRequest, DogtrekkingCz.Entries.Interface.Entities.GetEntriesByActionRequest>();
        typeAdapterConfig.NewConfig<DogtrekkingCz.Entries.Interface.Entities.GetEntriesByActionResponse, DogtrekkingCzWebApiService.Entities.GetEntriesByActionResponse>();

        return typeAdapterConfig;
    }
}