using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using SharedCode.Extensions;
using Mapster;
using Protos.Shared;
using SharedCode.Entities;

namespace DogsOnTrailGRPCService.Services.Entries;

internal static class EntriesServiceMapping
{
    private static SharedCode.Entities.DogDto.VaccinationType ConvertFromProto(Protos.Shared.Vaccination.Types.VaccinationType src)
    {
        switch (src)
        {
            case Vaccination.Types.VaccinationType.Babesioza: return DogDto.VaccinationType.Babesioza;
            case Vaccination.Types.VaccinationType.Leishmanioza: return DogDto.VaccinationType.Leishmanioza;
            case Vaccination.Types.VaccinationType.Leptospiroza: return DogDto.VaccinationType.Leptospiroza;
            case Vaccination.Types.VaccinationType.Parainfluenza: return DogDto.VaccinationType.Parainfluenza;
            case Vaccination.Types.VaccinationType.Parvoviroza: return DogDto.VaccinationType.Parvoviroza;
            case Vaccination.Types.VaccinationType.Psinka: return DogDto.VaccinationType.Psinka;
            case Vaccination.Types.VaccinationType.Rabies: return DogDto.VaccinationType.Rabies;
            case Vaccination.Types.VaccinationType.LymskaBorelioza: return DogDto.VaccinationType.LymskaBorelioza;
            case Vaccination.Types.VaccinationType.PlisnoveInfekce: return DogDto.VaccinationType.PlisnoveInfekce;
            case Vaccination.Types.VaccinationType.HepatitidaContagiosaCanis: return DogDto.VaccinationType.HepatitidaContagiosaCanis;
            case Vaccination.Types.VaccinationType.Unspecified: return DogDto.VaccinationType.NotValid;
            
            default: return DogDto.VaccinationType.NotValid;
        }
    }
    
    internal static TypeAdapterConfig AddEntriesServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Entries.CreateEntryRequest, CreateEntryRequest>()
            .Map(d => d.Accepted, s => false)
            .Map(d => d.AcceptedDate, s => (DateTimeOffset?) null)
            .Map(d => d, s => s.Entry)
            .Map(d => d.Created, s => s.Entry.Created.ToDateTimeOffset())
            .Map(d => d.Birthday, s => s.Entry.Birthday.ToDateTimeOffset())
            .Map(d => d.ActionId, s => Guid.Parse(s.Entry.ActionId))
            .Map(d => d.RaceId, s => Guid.Parse(s.Entry.RaceId))
            .Map(d => d.CategoryId, s => Guid.Parse(s.Entry.CategoryId))
            .Map(d => d.Dogs, s => s.Entry.Dogs.Select(dog => new CreateEntryRequest.DogDto
            {
                Birthday = dog.Birthday != null ? dog.Birthday.ToDateTimeOffset() : null,
                Id = dog.Id,
                Name = dog.Name,
                Chip = dog.Chip,
                Pedigree = dog.Pedigree,
                Vaccinations = dog.Vaccinations.Select(vacc => new DogDto.VaccinationDto
                {
                    Date = vacc.Date != null ? vacc.Date.ToDateTimeOffset() : null,
                    Note = vacc.Note,
                    Type = ConvertFromProto(vacc.Type),
                    ValidUntil = vacc.ValidUntil != null ? vacc.ValidUntil.ToDateTimeOffset() : null,
                    UriToPhoto = vacc.UriToPhoto
                }).ToList()
            }).ToList())
            .Map(d => d.Merchandize, s => s.Entry.Merchandize.Select(merchandizeItem =>
                new CreateEntryRequest.MerchandizeItemDto
                {
                    Id = merchandizeItem.Id,
                    Name = merchandizeItem.Name,
                    Color = merchandizeItem.Color,
                    Note = merchandizeItem.Note,
                    Count = merchandizeItem.Count,
                    Description = merchandizeItem.Description,
                    Currency = merchandizeItem.Currency,
                    Price = merchandizeItem.Price,
                    Size = merchandizeItem.Size,
                    Variant = merchandizeItem.Variant
                }).ToList());
        
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