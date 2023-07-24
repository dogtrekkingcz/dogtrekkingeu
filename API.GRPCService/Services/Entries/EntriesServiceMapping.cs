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
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.EntryDto, Protos.Entries.GetEntriesByActionResponse_Entry>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.VaccinationDto, Protos.Entries.GetEntriesByActionResponse_Vaccination>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.VaccinationType, Protos.Entries.GetEntriesByActionResponse_VaccinationType>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.DogDto, Protos.Entries.GetEntriesByActionResponse_Dog>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.MerchandizeItemDto, Protos.Entries.GetEntriesByActionResponse_MerchandizeItem>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.AddressDto, Protos.Entries.GetEntriesByActionResponse_Address>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.LatLngDto, Google.Type.LatLng>()
            .Map(d => d.Latitude, s => s.GpsLatitude)
            .Map(d => d.Longitude, s => s.GpsLongitude);

        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntriesRequest, GetAllEntriesRequest>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse, Protos.Entries.GetAllEntries.GetAllEntriesResponse>();
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