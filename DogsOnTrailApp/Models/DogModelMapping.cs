using System.Security.Authentication.ExtendedProtection;
using SharedCode.Entities;
using SharedCode.Extensions;
using Mapster;
using Protos.UserProfiles;

namespace DogsOnTrailApp.Models;

internal static class DogModelMapping
{
    internal static TypeAdapterConfig AddDogModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Shared.Dog, DogModel>()
            .IgnoreNullValues(true)
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset())
            .Map(d => d.Decease, s => s.Decease.ToDateTimeOffset());

        typeAdapterConfig.NewConfig<DogModel, Protos.Shared.Dog>()
            .IgnoreNullValues(true)
            .Map(d => d.Birthday, s => s.Birthday != null ? s.Birthday.ToGoogleDateTime() : null)
            .Map(d => d.Decease, s => s.Decease != null ? s.Decease.ToGoogleDateTime() : null);

        typeAdapterConfig.NewConfig<Protos.Shared.Vaccination, DogModel.VaccinationDto>()
            .IgnoreNullValues(true)
            .Map(d => d.Date, s => s.Date.ToDateTimeOffset())
            .Map(d => d.ValidUntil, s => s.ValidUntil.ToDateTimeOffset());

        typeAdapterConfig.NewConfig<DogModel.VaccinationDto, Protos.Shared.Vaccination>()
            .IgnoreNullValues(true)
            .Map(d => d.Date, s => s.Date != null ? s.Date.ToGoogleDateTime() : null)
            .Map(d => d.ValidUntil, s => s.ValidUntil != null ? s.ValidUntil.ToGoogleDateTime() : null);

        
        return typeAdapterConfig;
    }
}