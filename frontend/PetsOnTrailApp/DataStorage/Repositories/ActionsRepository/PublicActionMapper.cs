using Mapster;
using PetsOnTrailApp.Extensions;
using PetsOnTrailApp.Models;
using PetsOnTrailApp.Shared.ResourceFiles;
using Protos.Actions.GetSelectedPublicActionsList;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public static class PublicActionMapper
{
    public static TypeAdapterConfig AddPublicActionMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse, GetSelectedPublicActionsListResponseModel>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.ActionDto, GetSelectedPublicActionsListResponseModel.ActionDto>()
           .Ignore(d => d.Created);
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.RacerDto, GetSelectedPublicActionsListResponseModel.RacerDto>()
            .Ignore(d => d.Phone)
            .Ignore(d => d.Email)
            .Ignore(d => d.Accepted)
            .Ignore(d => d.Payed)
            .Ignore(d => d.Payments)
            .Ignore(d => d.Notes)
            .Ignore(d => d.RequestedPayments)
            .Ignore(d => d.Merchandize)
            .Ignore(d => d.Address)
            .Map(d => d.Start, s => s.Start.ToDateTimeOffset())
            .Map(d => d.Finish, s => s.Finish.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.AddressDto, GetSelectedPublicActionsListResponseModel.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.CategoryDto, GetSelectedPublicActionsListResponseModel.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.PetDto, GetSelectedPublicActionsListResponseModel.PetDto>()
            .Ignore(d => d.Decease)
            .Ignore(d => d.Contact)
            .Ignore(d => d.Vaccinations);
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.LimitsDto, GetSelectedPublicActionsListResponseModel.LimitsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.RaceDto, GetSelectedPublicActionsListResponseModel.RaceDto>()
            .Map(d => d.Begin, s => s.Begin.ToDateTimeOffset())
            .Map(d => d.EnteringFrom, s => s.EnteringFrom.ToDateTimeOffset())
            .Map(d => d.EnteringTo, s => s.EnteringTo.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.RaceState, GetSelectedPublicActionsListResponseModel.RaceState>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.TermDto, GetSelectedPublicActionsListResponseModel.TermDto>()
            .Map(d => d.From, s => s.From.ToDateTimeOffset())
            .Map(d => d.To, s => s.To.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.ActionSaleDto, GetSelectedPublicActionsListResponseModel.ActionSaleDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.PaymentDefinitionDto, GetSelectedPublicActionsListResponseModel.PaymentDefinitionDto>()
            .Map(d => d.From, s => s.From.ToDateTimeOffset())
            .Map(d => d.To, s => s.To.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.ActionSaleItemDto, GetSelectedPublicActionsListResponseModel.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.CheckpointDto, GetSelectedPublicActionsListResponseModel.CheckpointDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.PassedCheckpointDto, GetSelectedPublicActionsListResponseModel.PassedCheckpointDto>()
            .Map(d => d.Passed, s => s.Passed.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Google.Type.LatLng, GetSelectedPublicActionsListResponseModel.LatLngDto>()
            .MapWith((src) => new GetSelectedPublicActionsListResponseModel.LatLngDto
            {
                Latitude = src.Latitude,
                Longitude = src.Longitude,
            });

        typeAdapterConfig.NewConfig<DataStorageModel<GetSelectedPublicActionsListResponseModel>, SimpleActionModel>()
            .MapWith((src) => new SimpleActionModel
            {
                SynchronizedAt = src.Created,
                Id = src.Data.Actions[0].Id,
                Name = src.Data.Actions[0].Name,
                Description = src.Data.Actions[0].Description,
                Begin = src.Data.Actions[0].Term.From.DateTime,
                End = src.Data.Actions[0].Term.To.DateTime,
                TypeId = src.Data.Actions[0].TypeId,
                City = src.Data.Actions[0].Address.City,
                Races = src.Data.Actions[0].Races.Select(race => new SimpleActionModel.RaceDto
                { 
                    Id = race.Id,
                    Name = race.Name,
                }).ToList()
            });

        typeAdapterConfig.NewConfig<DataStorageModel<GetSelectedPublicActionsListResponseModel>, RacesModel>()
            .MapWith((src) => new RacesModel
            {
                SynchronizedAt = src.Created,
                ActionId = src.Data.Actions[0].Id,
                Races = MapFromProtoRaces(src.Data.Actions[0].Races)
            });

        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponseModel.RaceDto, CategoriesModel>()
            .MapWith((src) => new CategoriesModel
            {
                SynchronizedAt = DateTime.Now,
                RaceId = src.Id,
                Categories = src.Categories.Select(category => new CategoriesModel.CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                }).ToList()
            });

        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponseModel.CategoryDto, ResultsModel>()
            .MapWith((category) => new ResultsModel
            {
                SynchronizedAt = DateTime.Now,
                CategoryId = category.Id,
                Results = MapFromModelResults(category.Racers)
            });

        typeAdapterConfig.NewConfig<Protos.Actions.GetSimpleActionsList.GetSimpleActionsListResponse, GetSimpleActionsListResponseModel>()
            .MapWith((src) => new GetSimpleActionsListResponseModel
            {
                Actions = src.Actions.Select(action => new GetSimpleActionsListResponseModel.SimpleActionDto
                {
                    Id = Guid.Parse(action.Id),
                    Name = action.Name,
                    Description = action.Description,
                    TypeId = Guid.Parse(action.TypeId),
                    Begin = action.Begin.ToDateTimeOffset().Value.DateTime,
                    End = action.End.ToDateTimeOffset().Value.DateTime,
                    City = action.City,
                    Races = action.Races.Select(race => new GetSimpleActionsListResponseModel.RaceDto { Id = Guid.Parse(race.Id), Name = race.Name }).ToList()
                }).ToList()
            });

        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponseModel.RaceDto, RaceModel>()
            .MapWith((race) => new RaceModel
            {
                SynchronizedAt = DateTime.Now,
                Data = new RaceModel.RaceDto
                {
                    Id = race.Id,
                    Name = race.Name,
                    Begin = race.Begin,
                    End = race.End,
                    Distance = race.Distance,
                    Incline = race.Incline,
                    EnteringFrom = race.EnteringFrom,
                    EnteringTo = race.EnteringTo,
                    MaxNumberOfCompetitors = race.MaxNumberOfCompetitors,
                    Categories = race.Categories
                                        .Select(ctg => new RaceModel.CategoryDto 
                                                        { 
                                                            Id = ctg.Id, 
                                                            Description = ctg.Description, 
                                                            Name = ctg.Name 
                                                        })
                                        .ToList(),
                    Checkpoints = race.Checkpoints
                                        .Select(cp => new RaceModel.CheckpointDto 
                                                        { 
                                                            Id = cp.Id, 
                                                            Name = cp.Name, 
                                                            Position = new RaceModel.LatLngDto 
                                                                        { 
                                                                            Latitude = cp.Position.Latitude, 
                                                                            Longitude = cp.Position.Longitude 
                                                                        } 
                                                        })
                                        .ToList()
                }
            });


        return typeAdapterConfig;
    }

    private static List<ResultsModel.ResultDto> MapFromModelResults(IList<GetSelectedPublicActionsListResponseModel.RacerDto> racers)
    {
        var result = new List<ResultsModel.ResultDto>();

        foreach (var racer in racers)
        {
            var start = racer.Start;
            result.Add(new ResultsModel.ResultDto
            {
                Id = racer.Id,
                FirstName = racer.FirstName,
                LastName = racer.LastName,
                Start = racer.Start?.DateTime,
                Finish = racer.Finish?.DateTime,
                Pets = racer.Pets.Select(pet => pet.Name).ToList(),
                State = racer.State switch
                {
                    GetSelectedPublicActionsListResponseModel.RaceState.NotStarted => ResultsModel.ResultState.NotStarted,
                    GetSelectedPublicActionsListResponseModel.RaceState.Started => ResultsModel.ResultState.Started,
                    GetSelectedPublicActionsListResponseModel.RaceState.Finished => ResultsModel.ResultState.Finished,
                    GetSelectedPublicActionsListResponseModel.RaceState.DidNotFinished => ResultsModel.ResultState.DidNotFinished,
                    GetSelectedPublicActionsListResponseModel.RaceState.Disqualified => ResultsModel.ResultState.Disqualified,
                    _ => ResultsModel.ResultState.NotValid
                },
                Checkpoints = racer.PassedCheckpoints.Select(cp => new ResultsModel.CheckpointDto
                {
                    Id = cp.Id,
                    Time = cp.Passed.DateTime,
                    IsCheckpointPassed = true
                }).ToList()
            });
        }

        return result;
    }

    private static List<RacesModel.RaceDto> MapFromProtoRaces(List<GetSelectedPublicActionsListResponseModel.RaceDto> races)
    {
        var result = new List<RacesModel.RaceDto>();

        foreach (var race in races)
        {
            result.Add(new RacesModel.RaceDto
            {
                Id = race.Id,
                Name = race.Name,
                Begin = race.Begin.DateTime,
                End = race.End.DateTime,
                Distance = race.Distance ?? 0,
                Incline = race.Incline ?? 0
            });
        }

        return result;
    }
}
