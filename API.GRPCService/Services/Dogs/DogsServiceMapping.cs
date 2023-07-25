using API.GRPCService.Extensions;
using DogsOnTrail.Interfaces.Actions.Entities.Dogs;
using Mapster;

namespace API.GRPCService.Services.Dogs;

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
        
        typeAdapterConfig.NewConfig<CreateDogResponse, Protos.Dogs.CreateDogResponse>();

        typeAdapterConfig.NewConfig<Protos.Dogs.GetAllDogsRequest, GetAllDogsRequest>();
        
        typeAdapterConfig.NewConfig<GetAllDogsResponse, Protos.Dogs.GetAllDogsResponse>();
        
        return typeAdapterConfig;
    }
}