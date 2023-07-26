using API.GRPCService.Extensions;
using DogsOnTrail.Interfaces.Actions.Entities.Dogs;
using Mapster;

namespace API.GRPCService.Services.Dogs;

internal static class DogsServiceMapping
{
    internal static TypeAdapterConfig AddDogsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Dogs.CreateDog.CreateDogRequest, CreateDogRequest>();
        typeAdapterConfig.NewConfig<Protos.Dogs.CreateDog.Vaccination, CreateDogRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Dogs.CreateDog.VaccinationType, CreateDogRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<CreateDogResponse, Protos.Dogs.CreateDog.CreateDogResponse>();

        typeAdapterConfig.NewConfig<Protos.Dogs.GetAllDogs.GetAllDogsRequest, GetAllDogsRequest>();
        typeAdapterConfig.NewConfig<GetAllDogsResponse, Protos.Dogs.GetAllDogs.GetAllDogsResponse>();
        typeAdapterConfig.NewConfig<GetAllDogsResponse.DogDto, Protos.Dogs.GetAllDogs.DogDto>();
        typeAdapterConfig.NewConfig<GetAllDogsResponse.VaccinationDto, Protos.Dogs.GetAllDogs.Vaccination>();
        typeAdapterConfig.NewConfig<GetAllDogsResponse.VaccinationType, Protos.Dogs.GetAllDogs.VaccinationType>();
        
        typeAdapterConfig.NewConfig<Protos.Dogs.GetDogsFilteredByChip.GetDogsFilteredByChipRequest, GetDogsFilteredByChipRequest>();
        typeAdapterConfig.NewConfig<GetDogsFilteredByChipResponse, Protos.Dogs.GetDogsFilteredByChip.GetDogsFilteredByChipResponse>();
        typeAdapterConfig.NewConfig<GetDogsFilteredByChipResponse.VaccinationDto, Protos.Dogs.GetDogsFilteredByChip.Vaccination>();
        typeAdapterConfig.NewConfig<GetDogsFilteredByChipResponse.VaccinationType, Protos.Dogs.GetDogsFilteredByChip.VaccinationType>();

        typeAdapterConfig.NewConfig<Protos.Dogs.DeleteDog.DeleteDogRequest, DeleteDogRequest>();
        typeAdapterConfig.NewConfig<DeleteDogResponse, Protos.Dogs.DeleteDog.DeleteDogResponse>();
        
        return typeAdapterConfig;
    }
}