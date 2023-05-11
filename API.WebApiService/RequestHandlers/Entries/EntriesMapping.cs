using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using Mapster;

namespace DogsOnTrailWebApiService.RequestHandlers.Entries;

internal static class EntriesMapping
{
    internal static TypeAdapterConfig AddEntriesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<DogsOnTrailWebApiService.Entities.CreateEntryRequest, CreateEntryRequest>();
        typeAdapterConfig.NewConfig<CreateEntryResponse, DogsOnTrailWebApiService.Entities.CreateEntryResponse>();

        typeAdapterConfig.NewConfig<DogsOnTrailWebApiService.Entities.GetEntriesByActionRequest, GetEntriesByActionRequest>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse, DogsOnTrailWebApiService.Entities.GetEntriesByActionResponse>();

        return typeAdapterConfig;
    }
}