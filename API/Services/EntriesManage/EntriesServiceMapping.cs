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

        typeAdapterConfig.NewConfig<GetEntryResponse, UpdateEntryInternalStorageRequest>();

        typeAdapterConfig.NewConfig<CreateEntryRequest, NewActionRegistrationEmailRequest>()
            .IgnoreNullValues(true)
            .Ignore(d => d.Action)
            .Ignore(d => d.Category)
            .Ignore(d => d.Race)
            .Ignore(d => d.Payments)
            .Map(d => d.Racer, s => new NewActionRegistrationEmailRequest.RacerDto
            {
                Name = s.Name,
                Surname = s.Surname,
                Email = s.Email,
                Dogs = s.Dogs
                    .Select(dog => new NewActionRegistrationEmailRequest.DogDto
                    {
                        Name = dog.Name,
                        Birthday = dog.Birthday,
                        Chip = dog.Chip,
                        Pedigree = dog.Pedigree,
                        Vaccinations = dog.Vaccinations
                            .Select(vacc => new NewActionRegistrationEmailRequest.VaccinationDto
                            {
                                Date = vacc.Date,
                                Type = vacc.Type.ToString()
                            })
                            .ToList()
                    })
                    .ToList()
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