using Mapster;
using Storage.Entities.Entries;
using Storage.Models;

namespace Storage.Services.Repositories.Entries
{
    internal static class EntriesRepositoryMapping
    {
        internal static TypeAdapterConfig AddEntriesRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest, EntryRecord>();
            typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest.EntryState, EntryRecord.EntryState>();
            typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest.VaccinationDto, EntryRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest.DogDto, EntryRecord.DogDto>();
            typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest.MerchandizeItemDto, EntryRecord.MerchandizeItemDto>();
            typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest.AddressDto, EntryRecord.AddressDto>();
            typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest.LatLngDto, EntryRecord.LatLngDto>();
            
            typeAdapterConfig.NewConfig<UpdateEntryInternalStorageRequest, EntryRecord>();
            typeAdapterConfig.NewConfig<UpdateEntryInternalStorageRequest.EntryState, EntryRecord.EntryState>();
            typeAdapterConfig.NewConfig<UpdateEntryInternalStorageRequest.VaccinationDto, EntryRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<UpdateEntryInternalStorageRequest.DogDto, EntryRecord.DogDto>();
            typeAdapterConfig.NewConfig<UpdateEntryInternalStorageRequest.MerchandizeItemDto, EntryRecord.MerchandizeItemDto>();
            typeAdapterConfig.NewConfig<UpdateEntryInternalStorageRequest.AddressDto, EntryRecord.AddressDto>();
            typeAdapterConfig.NewConfig<UpdateEntryInternalStorageRequest.LatLngDto, EntryRecord.LatLngDto>();
            
            typeAdapterConfig.NewConfig<EntryRecord, GetEntryInternalStorageResponse>();
            typeAdapterConfig.NewConfig<EntryRecord.EntryState, GetEntryInternalStorageResponse.EntryState>();
            typeAdapterConfig.NewConfig<EntryRecord.VaccinationDto, GetEntryInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<EntryRecord.DogDto, GetEntryInternalStorageResponse.DogDto>();
            typeAdapterConfig.NewConfig<EntryRecord.MerchandizeItemDto, GetEntryInternalStorageResponse.MerchandizeItemDto>();
            typeAdapterConfig.NewConfig<EntryRecord.AddressDto, GetEntryInternalStorageResponse.AddressDto>();
            typeAdapterConfig.NewConfig<EntryRecord.LatLngDto, GetEntryInternalStorageResponse.LatLngDto>();

            typeAdapterConfig.NewConfig<EntryRecord, GetEntriesByActionInternalStorageResponse.EntryDto>();
            typeAdapterConfig.NewConfig<EntryRecord.EntryState, GetEntriesByActionInternalStorageResponse.EntryState>();
            typeAdapterConfig.NewConfig<EntryRecord.VaccinationDto, GetEntriesByActionInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<EntryRecord.DogDto, GetEntriesByActionInternalStorageResponse.DogDto>();
            typeAdapterConfig.NewConfig<EntryRecord.MerchandizeItemDto, GetEntriesByActionInternalStorageResponse.MerchandizeItemDto>();
            typeAdapterConfig.NewConfig<EntryRecord.AddressDto, GetEntriesByActionInternalStorageResponse.AddressDto>();
            typeAdapterConfig.NewConfig<EntryRecord.LatLngDto, GetEntriesByActionInternalStorageResponse.LatLngDto>();
            
            typeAdapterConfig.NewConfig<EntryRecord, GetAllEntriesInternalStorageResponse.EntryDto>();
            typeAdapterConfig.NewConfig<EntryRecord.EntryState, GetAllEntriesInternalStorageResponse.EntryState>();
            typeAdapterConfig.NewConfig<EntryRecord.VaccinationDto, GetAllEntriesInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<EntryRecord.DogDto, GetAllEntriesInternalStorageResponse.DogDto>();
            typeAdapterConfig.NewConfig<EntryRecord.MerchandizeItemDto, GetAllEntriesInternalStorageResponse.MerchandizeItemDto>();
            typeAdapterConfig.NewConfig<EntryRecord.AddressDto, GetAllEntriesInternalStorageResponse.AddressDto>();
            typeAdapterConfig.NewConfig<EntryRecord.LatLngDto, GetAllEntriesInternalStorageResponse.LatLngDto>();
            
            return typeAdapterConfig;
        }
    }
}