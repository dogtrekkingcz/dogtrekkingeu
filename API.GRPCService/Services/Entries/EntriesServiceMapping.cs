using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using Mapster;

namespace DogsOnTrailGRPCService.Services.Entries;

internal static class EntriesServiceMapping
{
    internal static TypeAdapterConfig AddEntriesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest, CreateEntryRequest>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest_VaccinationDto, CreateEntryRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest_DogDto, CreateEntryRequest.DogDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest_MerchandizeItemDto, CreateEntryRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest_AddressDto, CreateEntryRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest_LatLngDto, CreateEntryRequest.LatLngDto>();
        
        
        typeAdapterConfig.NewConfig<CreateEntryResponse, Protos.Entries.CreateEntryResponse>()
            .IgnoreNullValues(true)
            .Map(d => d.Entry, s => s);
        typeAdapterConfig.NewConfig<CreateEntryResponse, Protos.Shared.Entry>()
            .MapWith(s => new Entry { Id = s.Id });

        typeAdapterConfig.NewConfig<Protos.Entries.GetEntriesByActionRequest, GetEntriesByActionRequest>()
            .Map(d => d.ActionId, s => s.ActionId);
        typeAdapterConfig.NewConfig<GetEntriesByActionResponse, Protos.Entries.GetEntriesByActionResponse>();

        typeAdapterConfig.NewConfig<Protos.Entries.GetAllEntriesRequest, GetAllEntriesRequest>();
        typeAdapterConfig.NewConfig<GetAllEntriesResponse, Protos.Entries.GetAllEntriesResponse>();

        typeAdapterConfig.NewConfig<Protos.Entries.DeleteEntryRequest, DeleteEntryRequest>();

        return typeAdapterConfig;
    }
}