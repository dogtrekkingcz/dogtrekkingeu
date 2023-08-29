using Mapster;

namespace SharedLib.Models;

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

        typeAdapterConfig.NewConfig<Protos.Pets.GetPet.GetPetResponse, SharedLib.Models.PetModel>()
            .Ignore(d => d.Losts);
        typeAdapterConfig.NewConfig<Protos.Pets.GetPet.VaccinationType, SharedLib.Models.PetModel.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Pets.GetPet.Vaccination, SharedLib.Models.PetModel.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Pets.GetPet.PetType, SharedLib.Models.PetModel.PetType>();
        
        typeAdapterConfig.NewConfig<PetModel, Protos.Pets.UpdatePet.UpdatePetRequest>();
        typeAdapterConfig.NewConfig<PetModel.VaccinationType, Protos.Pets.UpdatePet.VaccinationType>();
        typeAdapterConfig.NewConfig<PetModel.VaccinationDto, Protos.Pets.UpdatePet.Vaccination>();
        typeAdapterConfig.NewConfig<PetModel.PetType, Protos.Pets.UpdatePet.PetType>();
        
        return typeAdapterConfig;
    }
}