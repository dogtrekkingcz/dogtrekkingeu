using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using Mapster;

namespace DogsOnTrailGRPCService.Services.Entries;

internal static class EntriesServiceMapping
{
    internal static TypeAdapterConfig AddEntriesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest, CreateEntryRequest>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest_Vaccination, CreateEntryRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest_VaccinationType, CreateEntryRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest_Dog, CreateEntryRequest.DogDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest_MerchandizeItem, CreateEntryRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest_Address, CreateEntryRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, CreateEntryRequest.LatLngDto>()
            .Map(d => d.GpsLatitude, s => s.Latitude)
            .Map(d => d.GpsLongitude, s => s.Longitude);
        
        typeAdapterConfig.NewConfig<CreateEntryResponse, Protos.Entries.CreateEntryResponse>();

        typeAdapterConfig.NewConfig<Protos.Entries.GetEntriesByActionRequest, GetEntriesByActionRequest>()
            .Map(d => d.ActionId, s => s.ActionId);
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse, Protos.Entries.GetEntriesByActionResponse>();

        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntriesRequest, GetAllEntriesRequest>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse, Protos.Entries.GetAllEntriesResponse>();

        typeAdapterConfig.NewConfig<Protos.Entries.DeleteEntryRequest, DeleteEntryRequest>();

        return typeAdapterConfig;
    }
}