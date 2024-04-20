using Google.Protobuf.Collections;
using Mapster;
using PetsOnTrailApp.Models;
using Protos.Actions.GetSelectedPublicActionsList;
using SharedLib.Extensions;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public static class PublicActionMapper
{
    public static TypeAdapterConfig AddPublicActionMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse, RacesModel>()
            .MapWith((src) => new RacesModel
            {
                SynchronizedAt = DateTime.Now,
                ActionId = Guid.Parse(src.Actions[0].Id),
                Races = MapFromProtoRaces(src.Actions[0].Races)
            });

        typeAdapterConfig.NewConfig<RaceDto, CategoriesModel>()
            .MapWith((src) => new CategoriesModel
            {
                SynchronizedAt = DateTime.Now,
                RaceId = Guid.Parse(src.Id),
                Categories = src.Categories.Select(category => new CategoriesModel.CategoryDto
                {
                    Id = Guid.Parse(category.Id),
                    Name = category.Name,
                    Description = category.Description
                }).ToList()
            });

        typeAdapterConfig.NewConfig<CategoryDto, ResultsModel>()
            .MapWith((category) => new ResultsModel
            {
                SynchronizedAt = DateTime.Now,
                CategoryId = Guid.Parse(category.Id),
                Results = MapFromProtoResults(category.Racers)
            });

        return typeAdapterConfig;
    }

    private static List<ResultsModel.ResultDto> MapFromProtoResults(RepeatedField<RacerDto> racers)
    {
        var result = new List<ResultsModel.ResultDto>();

        foreach (var racer in racers)
        {
            result.Add(new ResultsModel.ResultDto
            {
                Id = Guid.Parse(racer.Id),
                FirstName = racer.FirstName,
                LastName = racer.LastName,
                Start = racer.Start.ToDateTimeOffset()?.DateTime ?? DateTime.MinValue,
                Finish = racer.Finish.ToDateTimeOffset()?.DateTime ?? DateTime.MinValue,
                Pets = racer.Pets.Select(pet => pet.Name).ToList(),
                State = racer.State switch
                {
                    RaceState.NotStarted => ResultsModel.ResultState.NotStarted,
                    RaceState.Started => ResultsModel.ResultState.Started,
                    RaceState.Finished => ResultsModel.ResultState.Finished,
                    RaceState.DidNotFinished => ResultsModel.ResultState.DidNotFinished,
                    RaceState.Disqualified => ResultsModel.ResultState.Disqualified,
                    _ => ResultsModel.ResultState.NotValid
                }
            });
        }

        return result;
    }

    private static List<RacesModel.RaceDto> MapFromProtoRaces(RepeatedField<RaceDto> races)
    {
        var result = new List<RacesModel.RaceDto>();

        foreach (var race in races)
        {
            result.Add(new RacesModel.RaceDto
            {
                Id = Guid.Parse(race.Id),
                Name = race.Name,
                Begin = race.Begin.ToDateTimeOffset()?.DateTime ?? DateTime.MinValue,
                End = race.End.ToDateTimeOffset()?.DateTime ?? DateTime.MaxValue,
                Distance = race.Distance,
                Incline = race.Incline
            });
        }

        return result;
    }
}
