using DogsOnTrail.Interfaces.Actions.Entities.Actions;
using SharedCode.Entities;
using SharedCode.Extensions;
using Google.Protobuf.Collections;
using Mapster;

namespace DogsOnTrailGRPCService.Services.Actions;

internal static class ActionsServiceMapping
{
    internal static TypeAdapterConfig AddActionsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Shared.ActionDetail, CreateActionRequest>();

        typeAdapterConfig.NewConfig<CreateActionResponse, Protos.Actions.CreateActionResponse>();

        typeAdapterConfig.NewConfig<Protos.Shared.ActionDetail, UpdateActionRequest>();

        typeAdapterConfig.NewConfig<UpdateActionResponse, Protos.Actions.UpdateActionResponse>();

        typeAdapterConfig.NewConfig<Protos.Actions.DeleteActionRequest, DeleteActionRequest>();

        typeAdapterConfig.NewConfig<Protos.Actions.GetActionRequest, GetActionRequest>();

        typeAdapterConfig.NewConfig<GetActionResponse, Protos.Shared.ActionDetail>();
        
        
        typeAdapterConfig.NewConfig<GetAllActionsWithDetailsResponse, RepeatedField<Protos.Shared.ActionDetail>>()
            .Map(d => d, s => s.Actions)
            .Ignore(d => d.Capacity);

        typeAdapterConfig.NewConfig<ActionDto, Protos.Shared.ActionDetail>()
            .TwoWays();
        
        typeAdapterConfig.NewConfig<GetAllActionsResponse, RepeatedField<Protos.Shared.ActionSimple>>()
            .Map(d => d, s => s.Actions)
            .Ignore(d => d.Capacity);
        
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActionsRequest, GetAllActionsRequest>();

        typeAdapterConfig.NewConfig<RepeatedField<Protos.Shared.ActionRights>, IReadOnlyList<ActionRightsDto>>();

        typeAdapterConfig.NewConfig<Protos.Shared.ActionRights, ActionRightsDto>();

        typeAdapterConfig.NewConfig<Protos.Actions.CreateActionRequest, CreateActionRequest>()
            .MapWith(s => new CreateActionRequest
            {
                Id = s.Action.Id,
                Description = s.Action.Description,
                Name = s.Action.Name,
                Address = new AddressDto
                {
                    City = s.Action.Address.City,
                    Country = s.Action.Address.Country,
                    Region = s.Action.Address.Region,
                    Street = s.Action.Address.Street,
                    Position = new LatLngDto
                    {
                        GpsLatitude = s.Action.Address.Position.Latitude,
                        GpsLongitude = s.Action.Address.Position.Longitude
                    }
                },
                Term = new TermDto
                {
                    From = s.Action.Term.StartTime.ToDateTimeOffset(),
                    To = s.Action.Term.EndTime.ToDateTimeOffset()
                },
                Races = s.Action.Races
                    .Select(race => new RaceDto
                    {
                        Id = Guid.Parse(race.Id),
                        Name = race.Name,
                        Distance = race.Distance,
                        Incline = race.Incline,
                        EnteringFrom = race.EnteringFrom.ToDateTimeOffset(),
                        EnteringTo = race.EnteringTo.ToDateTimeOffset(),
                        MaxNumberOfCompetitors = (int) race.MaxNumberOfCompetitors,
                        Categories = race.Categories
                            .Select(category => new CategoryDto
                            {
                                Id = Guid.Parse(category.Id),
                                Name = category.Name,
                                Description = category.Description,
                                Racers = category.Racers
                                    .Select(racer => new RacerDto
                                    {
                                        State = (RaceState) racer.State,
                                        FirstName = racer.FirstName,
                                        LastName = racer.LastName,
                                        CompetitorId = racer.CompetitorId,
                                        Finish = racer.Finish.ToDateTimeOffset(),
                                        Start = racer.Start.ToDateTimeOffset(),
                                        Notes = racer.Notes
                                            .Select(note => new NoteDto
                                            {
                                                Time = note.Time.ToDateTimeOffset(),
                                                Text = note.Text
                                            })
                                            .ToList(),
                                        Dogs = racer.Dogs
                                            .Select(dog => new DogDto
                                            {
                                                Id = dog.Id,
                                                Name = dog.Name,
                                                Birthday = dog.Birthday.ToDateTimeOffset(),
                                                Chip = dog.Chip,
                                                Decease = dog.Decease.ToDateTimeOffset(),
                                                Pedigree = dog.Pedigree,
                                                UriToPhoto = dog.UriToPhoto,
                                                Vaccinations = dog.Vaccinations
                                                    .Select(vacc => new DogDto.VaccinationDto
                                                    {
                                                        UriToPhoto = vacc.UriToPhoto,
                                                        Date = vacc.Date.ToDateTimeOffset(),
                                                        Note = vacc.Note,
                                                        ValidUntil = vacc.ValidUntil.ToDateTimeOffset(),
                                                        Type = (DogDto.VaccinationType) vacc.Type
                                                    })
                                                    .ToList()
                                            })
                                            .ToList()
                                    })
                                    .ToList()
                            })
                            .ToList()
                    })
                    .ToList()
            });

        typeAdapterConfig.NewConfig<CreateActionResponse, Protos.Actions.CreateActionResponse>()
            .MapWith(s => new Protos.Actions.CreateActionResponse
            {
                Id = s.Id
            });

        typeAdapterConfig.NewConfig<GetActionEntrySettingsResponse, Protos.Actions.GetActionEntrySettingsResponse>();
        typeAdapterConfig.NewConfig<GetActionEntrySettingsResponse.CategoryDto, Protos.Actions.CategoryDto>();
        typeAdapterConfig.NewConfig<GetActionEntrySettingsResponse.RaceDto, Protos.Actions.RaceDto>();

        return typeAdapterConfig;
    }
}