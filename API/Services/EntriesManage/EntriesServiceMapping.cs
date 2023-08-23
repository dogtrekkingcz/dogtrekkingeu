using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using Mails.Entities;
using Mails.Entities.RegistrationToActionReceived;
using Mapster;
using Storage.Entities.Entries;

namespace DogsOnTrail.Actions.Services.EntriesManage;

internal static class EntriesServiceMapping
{
    public static TypeAdapterConfig AddEntriesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetEntriesByActionRequest, GetEntriesByActionInternalStorageRequest>();
        
        typeAdapterConfig.NewConfig<GetEntriesByActionInternalStorageResponse, GetEntriesByActionResponse>();
        typeAdapterConfig.NewConfig<GetEntriesByActionInternalStorageResponse.EntryDto, GetEntriesByActionResponse.EntryDto>();
        typeAdapterConfig.NewConfig<GetEntriesByActionInternalStorageResponse.VaccinationType, GetEntriesByActionResponse.VaccinationType>();
        typeAdapterConfig.NewConfig<GetEntriesByActionInternalStorageResponse.VaccinationDto, GetEntriesByActionResponse.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetEntriesByActionInternalStorageResponse.PetDto, GetEntriesByActionResponse.PetDto>();
        typeAdapterConfig.NewConfig<GetEntriesByActionInternalStorageResponse.MerchandizeItemDto, GetEntriesByActionResponse.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetEntriesByActionInternalStorageResponse.AddressDto, GetEntriesByActionResponse.AddressDto>();
        typeAdapterConfig.NewConfig<GetEntriesByActionInternalStorageResponse.LatLngDto, GetEntriesByActionResponse.LatLngDto>();

        typeAdapterConfig.NewConfig<CreateEntryRequest, CreateEntryInternalStorageRequest>()
            .Ignore(d => d.Id)
            .Ignore(d => d.Created)
            .Ignore(d => d.UserId)
            .Ignore(d => d.State);
        typeAdapterConfig.NewConfig<CreateEntryRequest.VaccinationType, CreateEntryInternalStorageRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.VaccinationDto, CreateEntryInternalStorageRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.PetDto, CreateEntryInternalStorageRequest.PetDto>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.MerchandizeItemDto, CreateEntryInternalStorageRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.AddressDto, CreateEntryInternalStorageRequest.AddressDto>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.LatLngDto, CreateEntryInternalStorageRequest.LatLngDto>();
        
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse, UpdateEntryInternalStorageRequest>();
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.EntryState, UpdateEntryInternalStorageRequest.EntryState>();
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.VaccinationType, UpdateEntryInternalStorageRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.VaccinationDto, UpdateEntryInternalStorageRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.PetDto, UpdateEntryInternalStorageRequest.PetDto>();
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.MerchandizeItemDto, UpdateEntryInternalStorageRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.AddressDto, UpdateEntryInternalStorageRequest.AddressDto>();
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.LatLngDto, UpdateEntryInternalStorageRequest.LatLngDto>();        
        
        typeAdapterConfig.NewConfig<CreateEntryInternalStorageResponse, CreateEntryResponse>();

        typeAdapterConfig.NewConfig<GetAllEntriesRequest, GetAllEntriesInternalStorageRequest>();
        typeAdapterConfig.NewConfig<GetAllEntriesInternalStorageResponse, GetAllEntriesResponse>();
        typeAdapterConfig.NewConfig<GetAllEntriesInternalStorageResponse.EntryState, GetAllEntriesResponse.EntryState>();
        typeAdapterConfig.NewConfig<GetAllEntriesInternalStorageResponse.EntryDto, GetAllEntriesResponse.EntryDto>();
        typeAdapterConfig.NewConfig<GetAllEntriesInternalStorageResponse.VaccinationType, GetAllEntriesResponse.VaccinationType>();
        typeAdapterConfig.NewConfig<GetAllEntriesInternalStorageResponse.VaccinationDto, GetAllEntriesResponse.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetAllEntriesInternalStorageResponse.PetDto, GetAllEntriesResponse.PetDto>();
        typeAdapterConfig.NewConfig<GetAllEntriesInternalStorageResponse.MerchandizeItemDto, GetAllEntriesResponse.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetAllEntriesInternalStorageResponse.AddressDto, GetAllEntriesResponse.AddressDto>();
        typeAdapterConfig.NewConfig<GetAllEntriesInternalStorageResponse.LatLngDto, GetAllEntriesResponse.LatLngDto>();

        typeAdapterConfig.NewConfig<CreateEntryRequest, NewActionRegistrationEmailRequest>()
            .IgnoreNullValues(true)
            .Ignore(d => d.Action)
            .Ignore(d => d.Category)
            .Ignore(d => d.Race)
            .Ignore(d => d.Payments)
            .Ignore(d => d.Racer);
        typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest.VaccinationType, NewActionRegistrationEmailRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest.VaccinationDto, NewActionRegistrationEmailRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest.PetDto, NewActionRegistrationEmailRequest.PetDto>();
        typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest.MerchandizeItemDto, NewActionRegistrationEmailRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest.AddressDto, NewActionRegistrationEmailRequest.AddressDto>();
        typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest.LatLngDto, NewActionRegistrationEmailRequest.LatLngDto>();

        typeAdapterConfig.NewConfig<CreateEntryInternalStorageRequest, NewActionRegistrationEmailRequest.RacerDto>()
            .Ignore(d => d.Id)
            .Ignore(d => d.Created);
        
        return typeAdapterConfig;
    }
}