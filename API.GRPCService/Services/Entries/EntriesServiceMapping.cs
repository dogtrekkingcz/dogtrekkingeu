using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using Mapster;

namespace API.GRPCService.Services.Entries;

internal static class EntriesServiceMapping
{
    internal static TypeAdapterConfig AddEntriesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntry.CreateEntryRequest, CreateEntryRequest>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntry.Vaccination, CreateEntryRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntry.VaccinationType, CreateEntryRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntry.Dog, CreateEntryRequest.DogDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntry.MerchandizeItem, CreateEntryRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntry.Address, CreateEntryRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, CreateEntryRequest.LatLngDto>()
            .Map(d => d.GpsLatitude, s => s.Latitude)
            .Map(d => d.GpsLongitude, s => s.Longitude);
        
        typeAdapterConfig.NewConfig<CreateEntryResponse, Protos.Entries.CreateEntry.CreateEntryResponse>();

        typeAdapterConfig.NewConfig<Protos.Entries.GetEntriesByActionRequest, GetEntriesByActionRequest>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse, Protos.Entries.GetEntriesByAction.GetEntriesByActionResponse>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.EntryState, Protos.Entries.GetEntriesByAction.EntryState>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.EntryDto, Protos.Entries.GetEntriesByAction.Entry>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.VaccinationDto, Protos.Entries.GetEntriesByAction.Vaccination>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.VaccinationType, Protos.Entries.GetEntriesByAction.VaccinationType>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.DogDto, Protos.Entries.GetEntriesByAction.Dog>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.MerchandizeItemDto, Protos.Entries.GetEntriesByAction.MerchandizeItem>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.AddressDto, Protos.Entries.GetEntriesByAction.Address>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.LatLngDto, Google.Type.LatLng>()
            .Map(d => d.Latitude, s => s.GpsLatitude)
            .Map(d => d.Longitude, s => s.GpsLongitude);

        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntriesRequest, GetAllEntriesRequest>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse, Protos.Entries.GetAllEntries.GetAllEntriesResponse>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.EntryState, Protos.Entries.GetAllEntries.EntryState>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.EntryDto, Protos.Entries.GetAllEntries.Entry>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.VaccinationDto, Protos.Entries.GetAllEntries.Vaccination>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.VaccinationType, Protos.Entries.GetAllEntries.VaccinationType>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.DogDto, Protos.Entries.GetAllEntries.Dog>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.MerchandizeItemDto, Protos.Entries.GetAllEntries.MerchandizeItem>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.AddressDto, Protos.Entries.GetAllEntries.Address>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse.LatLngDto, Google.Type.LatLng>()
            .Map(d => d.Latitude, s => s.GpsLatitude)
            .Map(d => d.Longitude, s => s.GpsLongitude);

        typeAdapterConfig.NewConfig<Protos.Entries.DeleteEntryRequest, DeleteEntryRequest>();

        return typeAdapterConfig;
    }
}