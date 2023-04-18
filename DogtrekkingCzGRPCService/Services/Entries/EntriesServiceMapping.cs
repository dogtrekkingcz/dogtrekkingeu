using DogtrekkingCz.Interfaces.Actions.Entities.Entries;
using DogtrekkingCzShared.Extensions;
using Mapster;
using Protos.Shared;

namespace DogtrekkingCzGRPCService.Services.Entries;

internal static class EntriesServiceMapping
{
    internal static TypeAdapterConfig AddEntriesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest, CreateEntryRequest>()
            .Map(d => d, s => s.Entry)
            .Map(d => d.Created, s => s.Entry.Created.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<CreateEntryResponse, Protos.Entries.CreateEntryResponse>()
            .IgnoreNullValues(true)
            .Map(d => d.Entry, s => s);
        typeAdapterConfig.NewConfig<CreateEntryResponse, Protos.Shared.Entry>()
            .MapWith(s => new Entry { Id = s.Id });

        typeAdapterConfig.NewConfig<Protos.Entries.GetEntriesByActionRequest, GetEntriesByActionRequest>()
            .Map(d => d.ActionId, s => s.ActionId);
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse, Protos.Entries.GetEntriesByActionResponse>();

        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntriesRequest, GetAllEntriesRequest>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse, Protos.Entries.GetAllEntriesResponse>();

        typeAdapterConfig.NewConfig<Protos.Entries.DeleteEntryRequest, DeleteEntryRequest>();

        return typeAdapterConfig;
    }
}