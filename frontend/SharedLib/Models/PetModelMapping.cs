using Mapster;

namespace SharedLib.Models;

internal static class PetModelMapping
{
    internal static TypeAdapterConfig AddPetModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Pets.GetAllPets.PetDto, PetModel>();
        typeAdapterConfig.NewConfig<Protos.Pets.GetAllPets.Vaccination, PetModel.VaccinationDto>();

        typeAdapterConfig.NewConfig<PetModel, Protos.Pets.CreatePet.CreatePetRequest>();
        typeAdapterConfig.NewConfig<PetModel.VaccinationDto, Protos.Pets.CreatePet.Vaccination>();

        typeAdapterConfig.NewConfig<Protos.Pets.GetPet.GetPetResponse, SharedLib.Models.PetModel>();
        typeAdapterConfig.NewConfig<Protos.Pets.GetPet.Vaccination, SharedLib.Models.PetModel.VaccinationDto>();
        
        typeAdapterConfig.NewConfig<PetModel, Protos.Pets.UpdatePet.UpdatePetRequest>();
        typeAdapterConfig.NewConfig<PetModel.VaccinationDto, Protos.Pets.UpdatePet.Vaccination>();
        
        return typeAdapterConfig;
    }
}