using DogtrekkingCz.Entries.Interface.Entities;
using Mapster;

namespace DogtrekkingCzGRPCService.Services.Entries;

internal static class EntriesServiceMapping
{
    internal static TypeAdapterConfig AddEntriesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest, CreateEntryRequest>();

        typeAdapterConfig.NewConfig<CreateEntryResponse, Protos.Entries.CreateEntryResponse>();

        return typeAdapterConfig;
    }
}