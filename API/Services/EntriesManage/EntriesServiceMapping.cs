using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using Mails.Entities;
using Mapster;
using Storage.Entities.Entries;

namespace DogsOnTrail.Actions.Services.EntriesManage;

internal static class EntriesServiceMapping
{
    public static TypeAdapterConfig AddEntriesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetEntriesByActionInternalStorageResponse, GetEntriesByActionResponse>();
        typeAdapterConfig.NewConfig<GetEntriesByActionRequest, GetEntriesByActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<CreateEntryRequest, CreateEntryInternalStorageRequest>();
        typeAdapterConfig.NewConfig<CreateEntryInternalStorageResponse, CreateEntryResponse>();

        typeAdapterConfig.NewConfig<GetAllEntriesRequest, GetAllEntriesInternalStorageRequest>();
        typeAdapterConfig.NewConfig<GetAllEntriesInternalStorageResponse, GetAllEntriesResponse>();

        typeAdapterConfig.NewConfig<CreateEntryRequest, NewActionRegistrationEmailRequest>()
            .Map(d => d.Race.Name, s => s.RaceId)
            .Map(d => d.Category.Name, s => s.CategoryId)
            .Map(d => d.Racer.Name, s => s.Name)
            .Map(d => d.Racer.Surname, s => s.Surname)
            .Map(d => d.Racer.Dogs, s => s.Dogs)
            .Map(d => d.Action, s => new NewActionRegistrationEmailRequest.ActionDto
            {
                Name = s.ActionId,
                Term = null
            });
        
        typeAdapterConfig.NewConfig<CreateEntryRequest.DogDto, NewActionRegistrationEmailRequest.DogDto>()
            .Map(d => d.Name, s => s.Name)
            .Map(d => d.Birthday, s => s.Birthday)
            .Map(d => d.Pedigree, s => s.Pedigree)
            .Map(d => d.Chip, s => s.Chip)
            .Map(d => d.Vaccinations, s => s.Vaccinations);

        typeAdapterConfig
            .NewConfig<SharedCode.Entities.DogDto.VaccinationDto, NewActionRegistrationEmailRequest.VaccinationDto>()
            .Map(d => d.Type, s => s.Type.ToString())
            .Map(d => d.Date, s => s.Date);
        
        return typeAdapterConfig;
    }
}