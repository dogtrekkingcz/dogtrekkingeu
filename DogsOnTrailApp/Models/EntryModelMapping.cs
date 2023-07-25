using SharedCode.Extensions;
using Mapster;
using SharedCode.Entities;

namespace DogsOnTrailApp.Models;

internal static class EntryModelMapping
{
    internal static TypeAdapterConfig AddEntryModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.Entry, EntryModel>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.Vaccination, EntryModel.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.VaccinationType, EntryModel.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.Dog, EntryModel.DogDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.MerchandizeItem, EntryModel.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.Address, EntryModel.AddressDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, EntryModel.LatLngDto>()
            .Map(d => d.GpsLatitude, s => s.Latitude)
            .Map(d => d.GpsLongitude, s => s.Longitude);

        typeAdapterConfig.NewConfig<EntryModel, Protos.Entries.CreateEntryRequest>();
        typeAdapterConfig.NewConfig<EntryModel.VaccinationDto, Protos.Entries.CreateEntryRequest_Vaccination>();
        typeAdapterConfig.NewConfig<EntryModel.DogDto, Protos.Entries.CreateEntryRequest_Dog>();
        typeAdapterConfig.NewConfig<EntryModel.VaccinationType, Protos.Entries.CreateEntryRequest_VaccinationType>();
        
        return typeAdapterConfig;
    }
}