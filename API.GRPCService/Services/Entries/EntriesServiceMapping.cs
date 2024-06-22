using PetsOnTrail.Interfaces.Actions.Entities.Entries;
using Mapster;

namespace API.GRPCService.Services.Entries;

internal static class EntriesServiceMapping
{
    internal static TypeAdapterConfig AddEntriesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntry.CreateEntryRequest, CreateEntryRequest>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntry.Pet, CreateEntryRequest.PetDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntry.MerchandizeItem, CreateEntryRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntry.Address, CreateEntryRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, CreateEntryRequest.LatLngDto>();
        
        typeAdapterConfig.NewConfig<CreateEntryResponse, Protos.Entries.CreateEntry.CreateEntryResponse>();

        typeAdapterConfig.NewConfig<Protos.Entries.GetEntriesByActionRequest, GetEntriesByActionRequest>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse, Protos.Entries.GetEntriesByAction.GetEntriesByActionResponse>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.EntryState, Protos.Entries.GetEntriesByAction.EntryState>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.EntryDto, Protos.Entries.GetEntriesByAction.Entry>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.PetDto, Protos.Entries.GetEntriesByAction.Pet>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.MerchandizeItemDto, Protos.Entries.GetEntriesByAction.MerchandizeItem>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.AddressDto, Protos.Entries.GetEntriesByAction.Address>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.LatLngDto, Google.Type.LatLng>();

        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntriesRequest, GetAllEntriesRequest>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse, Protos.Entries.GetAllEntries.GetAllEntriesResponse>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.EntryState, Protos.Entries.GetAllEntries.EntryState>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.EntryDto, Protos.Entries.GetAllEntries.Entry>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.PetDto, Protos.Entries.GetAllEntries.Pet>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.MerchandizeItemDto, Protos.Entries.GetAllEntries.MerchandizeItem>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.AddressDto, Protos.Entries.GetAllEntries.Address>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.LatLngDto, Google.Type.LatLng>();

        typeAdapterConfig.NewConfig<Protos.Entries.DeleteEntryRequest, DeleteEntryRequest>();

        return typeAdapterConfig;
    }
}