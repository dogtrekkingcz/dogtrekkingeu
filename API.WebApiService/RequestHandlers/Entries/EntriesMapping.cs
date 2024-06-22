using PetsOnTrail.Interfaces.Actions.Entities.Entries;
using Mapster;
using CreateEntryRequest = API.WebApiService.Entities.CreateEntryRequest;
using GetEntriesByActionRequest = API.WebApiService.Entities.GetEntriesByActionRequest;

namespace API.WebApiService.RequestHandlers.Entries;

internal static class EntriesMapping
{
    internal static TypeAdapterConfig AddEntriesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<CreateEntryRequest, PetsOnTrail.Interfaces.Actions.Entities.Entries.CreateEntryRequest>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.MerchandizeItemDto, PetsOnTrail.Interfaces.Actions.Entities.Entries.CreateEntryRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.PetDto, PetsOnTrail.Interfaces.Actions.Entities.Entries.CreateEntryRequest.PetDto>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.AddressDto, PetsOnTrail.Interfaces.Actions.Entities.Entries.CreateEntryRequest.AddressDto>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.LatLngDto, PetsOnTrail.Interfaces.Actions.Entities.Entries.CreateEntryRequest.LatLngDto>();
        typeAdapterConfig.NewConfig<CreateEntryResponse, Entities.CreateEntryResponse>();

        typeAdapterConfig.NewConfig<GetEntriesByActionRequest, PetsOnTrail.Interfaces.Actions.Entities.Entries.GetEntriesByActionRequest>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse, Entities.GetEntriesByActionResponse>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.EntryDto, Entities.GetEntriesByActionResponse.EntryDto>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.PetDto, Entities.GetEntriesByActionResponse.PetDto>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.MerchandizeItemDto, Entities.GetEntriesByActionResponse.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.AddressDto, Entities.GetEntriesByActionResponse.AddressDto>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.LatLngDto, Entities.GetEntriesByActionResponse.LatLngDto>();

        typeAdapterConfig.NewConfig<PetsOnTrail.Interfaces.Actions.Entities.Entries.CreateEntryRequest.PetDto, Entities.GetEntriesByActionResponse.PetDto>();
        typeAdapterConfig.NewConfig<PetsOnTrail.Interfaces.Actions.Entities.Entries.CreateEntryRequest.MerchandizeItemDto, Entities.GetEntriesByActionResponse.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<PetsOnTrail.Interfaces.Actions.Entities.Entries.CreateEntryRequest.AddressDto, Entities.GetEntriesByActionResponse.AddressDto>();
        typeAdapterConfig.NewConfig<PetsOnTrail.Interfaces.Actions.Entities.Entries.CreateEntryRequest.LatLngDto, Entities.GetEntriesByActionResponse.LatLngDto>();

        return typeAdapterConfig;
    }
}