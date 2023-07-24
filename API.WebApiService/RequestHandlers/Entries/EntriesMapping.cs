using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using Mapster;

namespace DogsOnTrailWebApiService.RequestHandlers.Entries;

internal static class EntriesMapping
{
    internal static TypeAdapterConfig AddEntriesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<DogsOnTrailWebApiService.Entities.CreateEntryRequest, CreateEntryRequest>();
        typeAdapterConfig.NewConfig<CreateEntryResponse, DogsOnTrailWebApiService.Entities.CreateEntryResponse>();

        typeAdapterConfig.NewConfig<DogsOnTrailWebApiService.Entities.GetEntriesByActionRequest, GetEntriesByActionRequest>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse, DogsOnTrailWebApiService.Entities.GetEntriesByActionResponse>();
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse.EntryDto, DogsOnTrailWebApiService.Entities.GetEntriesByActionResponse.EntryDto>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.VaccinationDto, DogsOnTrailWebApiService.Entities.GetEntriesByActionResponse.VaccinationDto>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.VaccinationType, DogsOnTrailWebApiService.Entities.GetEntriesByActionResponse.VaccinationType>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.DogDto, DogsOnTrailWebApiService.Entities.GetEntriesByActionResponse.DogDto>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.MerchandizeItemDto, DogsOnTrailWebApiService.Entities.GetEntriesByActionResponse.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<CreateEntryRequest.AddressDto, DogsOnTrailWebApiService.Entities.GetEntriesByActionResponse.AddressDto>();

        return typeAdapterConfig;
    }
}