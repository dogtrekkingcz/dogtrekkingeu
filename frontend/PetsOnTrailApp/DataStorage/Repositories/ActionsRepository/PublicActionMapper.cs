﻿using Google.Protobuf.Collections;
using Mapster;
using PetsOnTrailApp.Extensions;
using PetsOnTrailApp.Models;
using Protos.Actions.GetSelectedPublicActionsList;
using SharedLib.Extensions;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public static class PublicActionMapper
{
    public static TypeAdapterConfig AddPublicActionMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse, GetSelectedPublicActionsListResponseModel>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.ActionDto, GetSelectedPublicActionsListResponseModel.ActionDto>()
            .Ignore(d => d.Created);
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.ActionType, GetSelectedPublicActionsListResponseModel.ActionType>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedPublicActionsList.RacerDto, GetSelectedPublicActionsListResponseModel.RacerDto>()
            .Ignore(d => d.Phone)
            .Ignore(d => d.Email)
            .Ignore(d => d.Accepted)
            .Ignore(d => d.Payed)
            .Ignore(d => d.Payments)
            .Ignore(d => d.Notes)
            .Ignore(d => d.RequestedPayments)
            .Ignore(d => d.Merchandize)
            .Ignore(d => d.Address);
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



        typeAdapterConfig.NewConfig<DataStorageModel<GetSelectedPublicActionsListResponseModel>, RacesModel>()
            .MapWith((src) => new RacesModel
            {
                SynchronizedAt = src.Created,
                ActionId = src.Data.Actions[0].Id,
                Races = MapFromProtoRaces(src.Data.Actions[0].Races)
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

    private static List<RacesModel.RaceDto> MapFromProtoRaces(List<GetSelectedPublicActionsListResponseModel.RaceDto> races)
    {
        var result = new List<RacesModel.RaceDto>();

        foreach (var race in races)
        {
            Console.WriteLine($"Mapping from race to racemodel: {race.Dump()}");

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
