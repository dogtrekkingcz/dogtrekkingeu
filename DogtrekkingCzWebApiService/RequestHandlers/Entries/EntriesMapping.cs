using DogtrekkingCz.Interfaces.Actions.Entities.Entries;
using Mapster;

namespace DogtrekkingCzWebApiService.RequestHandlers.Entries;

internal static class EntriesMapping
{
    internal static TypeAdapterConfig AddEntriesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<DogtrekkingCzWebApiService.Entities.CreateEntryRequest, CreateEntryRequest>();
        typeAdapterConfig.NewConfig<CreateEntryResponse, DogtrekkingCzWebApiService.Entities.CreateEntryResponse>();

        typeAdapterConfig.NewConfig<DogtrekkingCzWebApiService.Entities.GetEntriesByActionRequest, GetEntriesByActionRequest>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse, DogtrekkingCzWebApiService.Entities.GetEntriesByActionResponse>();

        return typeAdapterConfig;
    }
}