using DogsOnTrailApp.Extensions;
using Mapster;

namespace DogsOnTrailApp.Models;

internal static class DogModelMapping
{
    internal static TypeAdapterConfig AddDogModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Dogs.GetAllDogs.DogDto, DogModel>();
        typeAdapterConfig.NewConfig<Protos.Dogs.GetAllDogs.VaccinationType, DogModel.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Dogs.GetAllDogs.Vaccination, DogModel.VaccinationDto>();

        typeAdapterConfig.NewConfig<DogModel, Protos.Dogs.CreateDog.CreateDogRequest>();
        typeAdapterConfig.NewConfig<DogModel.VaccinationType, Protos.Dogs.CreateDog.VaccinationType>();
        typeAdapterConfig.NewConfig<DogModel.VaccinationDto, Protos.Dogs.CreateDog.Vaccination>();
        
        return typeAdapterConfig;
    }
}