using DogtrekkingCz.Interfaces.Actions.Entities.Results;
using DogtrekkingCzShared.Entities;
using DogtrekkingCzShared.Extensions;
using Mapster;

namespace DogtrekkingCzGRPCService.Services.Results;

internal static class ResultsServiceMapping
{
    internal static TypeAdapterConfig AddResultsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Results.AddResultRequest, AddResultRequest>()
            .MapWith(s => new AddResultRequest
            {
                ActionId = s.ActionId,
                RaceId = s.RaceId,
                Accepted = s.Racer.Accepted,
                Id = s.Racer.Id,
                Start = (s.Racer.Start != null) ? s.Racer.Start.ToDateTimeOffset() : null,
                Finish = (s.Racer.Finish != null) ? s.Racer.Finish.ToDateTimeOffset() : null,
                FirstName = s.Racer.FirstName,
                LastName = s.Racer.LastName,
                State = (RaceState) s.Racer.State,
                CategoryId = s.CategoryId,
                CompetitorId = s.Racer.CompetitorId,
                Notes = s.Racer.Notes
                    .Select(note => new NoteDto
                        {
                            Time = note.Time.ToDateTimeOffset(),
                            Text = note.Text
                        })
                    .ToList(),
                Dogs = s.Racer.Dogs
                    .Select(dog => new DogDto
                        {
                            Id = dog.Id,
                            Birthday = dog.Birthday.ToDateTimeOffset(),
                            Chip = dog.Chip,
                            Contact = dog.Contact,
                            Kennel = dog.Kennel,
                            Name = dog.Name,
                            Pedigree = dog.Pedigree,
                            UserId = dog.UserId,
                            UriToPhoto = dog.UriToPhoto,
                            Vaccinations = dog.Vaccinations
                                .Select(vaccination => new DogDto.VaccinationDto
                                {
                                    Date = vaccination.Date.ToDateTimeOffset(),
                                    UriToPhoto = vaccination.UriToPhoto,
                                    Note = vaccination.Note,
                                    Type = (DogDto.VaccinationType) vaccination.Type,
                                    ValidUntil = vaccination.ValidUntil.ToDateTimeOffset()
                                })
                                .ToList()
                        })
                    .ToList(),
            });

        return typeAdapterConfig;
    }
}