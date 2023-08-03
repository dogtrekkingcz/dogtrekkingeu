using Mapster;

namespace DogsOnTrailApp.Models;

internal static class PetModelMapping
{
    internal static TypeAdapterConfig AddPetModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Pets.GetAllPets.PetDto, PetModel>();
        typeAdapterConfig.NewConfig<Protos.Pets.GetAllPets.VaccinationType, PetModel.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Pets.GetAllPets.Vaccination, PetModel.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Pets.GetAllPets.PetType, PetModel.PetType>();
        typeAdapterConfig.NewConfig<Protos.Pets.GetAllPets.LostPetRecord, PetModel.LostPetRecordDto>();
        typeAdapterConfig.NewConfig<Protos.Pets.GetAllPets.PetWasSeen, PetModel.PetWasSeenDto>();

        typeAdapterConfig.NewConfig<PetModel, Protos.Pets.CreatePet.CreatePetRequest>();
        typeAdapterConfig.NewConfig<PetModel.VaccinationType, Protos.Pets.CreatePet.VaccinationType>();
        typeAdapterConfig.NewConfig<PetModel.VaccinationDto, Protos.Pets.CreatePet.Vaccination>();
        typeAdapterConfig.NewConfig<PetModel.PetType, Protos.Pets.CreatePet.PetType>();
        typeAdapterConfig.NewConfig<PetModel.LostPetRecordDto, Protos.Pets.CreatePet.LostPetRecord>();
        typeAdapterConfig.NewConfig<PetModel.PetWasSeenDto, Protos.Pets.CreatePet.PetWasSeen>();
        
        return typeAdapterConfig;
    }
}