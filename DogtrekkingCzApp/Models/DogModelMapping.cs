using System.Security.Authentication.ExtendedProtection;
using DogtrekkingCzShared.Entities;
using DogtrekkingCzShared.Extensions;
using Mapster;
using Protos.UserProfiles;

namespace DogtrekkingCzApp.Models;

internal static class DogModelMapping
{
    internal static TypeAdapterConfig AddDogModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Shared.Dog, DogModel>()
            .IgnoreNullValues(true)
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset())
            .Map(d => d.Decease, s => s.Decease.ToDateTimeOffset());

        typeAdapterConfig.NewConfig<DogModel, Protos.Shared.Dog>()
            .Map(d => d.Birthday, s => s.Birthday.ToGoogleDateTime())
            .Map(d => d.Decease, s => s.Decease.Value.ToGoogleDateTime());

        
        typeAdapterConfig.NewConfig<Protos.Shared.Vaccination, DogModel.VaccinationDto>()
            .IgnoreNullValues(true)
            .Map(d => d.Date, s => s.Date.ToDateTimeOffset())
            .Map(d => d.ValidUntil, s => s.ValidUntil.ToDateTimeOffset());

        typeAdapterConfig.NewConfig<DogModel.VaccinationDto, Protos.Shared.Vaccination>()
            .IgnoreNullValues(true)
            .Map(d => d.Date, s => s.Date.ToGoogleDateTime())
            .Map(d => d.ValidUntil, s => s.ValidUntil.ToGoogleDateTime());

        
        return typeAdapterConfig;
    }
}