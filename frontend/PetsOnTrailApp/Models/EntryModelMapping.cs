using Mapster;

namespace PetsOnTrailApp.Models;

internal static class EntryModelMapping
{
    internal static TypeAdapterConfig AddEntryModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.Entry, EntryModel>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.EntryState, EntryModel.EntryState>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.Vaccination, EntryModel.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.VaccinationType, EntryModel.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.Pet, EntryModel.PetDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.MerchandizeItem, EntryModel.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntries.Address, EntryModel.AddressDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, EntryModel.LatLngDto>();

        typeAdapterConfig.NewConfig<EntryModel, Protos.Entries.CreateEntry.CreateEntryRequest>();
        typeAdapterConfig.NewConfig<EntryModel.VaccinationDto, Protos.Entries.CreateEntry.Vaccination>();
        typeAdapterConfig.NewConfig<EntryModel.PetDto, Protos.Entries.CreateEntry.Pet>();
        typeAdapterConfig.NewConfig<EntryModel.VaccinationType, Protos.Entries.CreateEntry.VaccinationType>();
        typeAdapterConfig.NewConfig<EntryModel.MerchandizeItemDto, Protos.Entries.CreateEntry.MerchandizeItem>();
        typeAdapterConfig.NewConfig<EntryModel.AddressDto, Protos.Entries.CreateEntry.Address>();
        typeAdapterConfig.NewConfig<EntryModel.LatLngDto, Google.Type.LatLng>();

        typeAdapterConfig.NewConfig<Protos.Entries.GetEntriesByAction.Entry, EntryModel>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetEntriesByAction.EntryState, EntryModel.EntryState>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetEntriesByAction.Vaccination, EntryModel.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetEntriesByAction.VaccinationType, EntryModel.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetEntriesByAction.Pet, EntryModel.PetDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetEntriesByAction.MerchandizeItem, EntryModel.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.GetEntriesByAction.Address, EntryModel.AddressDto>();
        
        return typeAdapterConfig;
    }
}