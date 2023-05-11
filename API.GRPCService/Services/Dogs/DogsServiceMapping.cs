using DogsOnTrail.Interfaces.Actions.Entities.Dogs;
using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using SharedCode.Entities;
using SharedCode.Extensions;
using Mapster;
using Protos.Shared;

namespace DogsOnTrailGRPCService.Services.Dogs;

internal static class DogsServiceMapping
{
    internal static TypeAdapterConfig AddDogsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Shared.Dog, CreateDogRequest>()
            .IgnoreNullValues(true)
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset())
            .Map(d => d.Decease, s => s.Decease.ToDateTimeOffset());

        typeAdapterConfig.NewConfig<Protos.Shared.Vaccination, CreateDogRequest.VaccinationDto>()
            .IgnoreNullValues(true)
            .Map(d => d.Date, s => s.Date.ToDateTimeOffset())
            .Map(d => d.ValidUntil, s => s.ValidUntil.ToDateTimeOffset());
        
        typeAdapterConfig.NewConfig<Protos.Shared.Dog, DogDto>()
            .IgnoreNullValues(true)
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset())
            .Map(d => d.Decease, s => s.Decease.ToDateTimeOffset());

        typeAdapterConfig.NewConfig<Protos.Shared.Vaccination, DogDto.VaccinationDto>()
            .IgnoreNullValues(true)
            .Map(d => d.Date, s => s.Date.ToDateTimeOffset())
            .Map(d => d.ValidUntil, s => s.ValidUntil.ToDateTimeOffset());

        typeAdapterConfig.NewConfig<DogDto, Protos.Shared.Dog>()
            .IgnoreNullValues(true)
            .Map(d => d.Birthday, s => s.Birthday != null ? s.Birthday.Value.ToGoogleDateTime() : null)
            .Map(d => d.Decease, s => s.Decease != null ? s.Decease.Value.ToGoogleDateTime() : null);

        typeAdapterConfig.NewConfig<DogDto.VaccinationDto, Protos.Shared.Vaccination>()
            .IgnoreNullValues(true)
            .Map(d => d.Date, s => s.Date != null ? s.Date.Value.ToGoogleDateTime() : null)
            .Map(d => d.ValidUntil, s => s.ValidUntil != null ? s.ValidUntil.Value.ToGoogleDateTime() : null);

        typeAdapterConfig.NewConfig<CreateDogResponse, Protos.Dogs.CreateDogResponse>();

        typeAdapterConfig.NewConfig<Protos.Dogs.GetAllDogsRequest, GetAllDogsRequest>();
        
        typeAdapterConfig.NewConfig<GetAllDogsResponse, Protos.Dogs.GetAllDogsResponse>();
        
        return typeAdapterConfig;
    }
}