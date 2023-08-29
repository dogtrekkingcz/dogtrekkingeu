using DogsOnTrail.Interfaces.Actions.Entities.Pets;
using Mapster;

namespace API.GRPCService.Services.Pets;

internal static class PetsServiceMapping
{
    internal static TypeAdapterConfig AddPetsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Pets.CreatePet.CreatePetRequest, CreatePetRequest>();
        typeAdapterConfig.NewConfig<Protos.Pets.CreatePet.Vaccination, CreatePetRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Pets.CreatePet.VaccinationType, CreatePetRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Pets.CreatePet.PetType, CreatePetRequest.PetType>();
        typeAdapterConfig.NewConfig<Protos.Pets.CreatePet.LostPetRecord, CreatePetRequest.LostPetRecordDto>();
        typeAdapterConfig.NewConfig<Protos.Pets.CreatePet.PetWasSeen, CreatePetRequest.PetWasSeenDto>();
        typeAdapterConfig.NewConfig<CreatePetResponse, Protos.Pets.CreatePet.CreatePetResponse>();

        typeAdapterConfig.NewConfig<Protos.Pets.GetAllPets.GetAllPetsRequest, GetAllPetsRequest>();
        typeAdapterConfig.NewConfig<GetAllPetsResponse, Protos.Pets.GetAllPets.GetAllPetsResponse>();
        typeAdapterConfig.NewConfig<GetAllPetsResponse.PetDto, Protos.Pets.GetAllPets.PetDto>();
        typeAdapterConfig.NewConfig<GetAllPetsResponse.VaccinationDto, Protos.Pets.GetAllPets.Vaccination>();
        typeAdapterConfig.NewConfig<GetAllPetsResponse.VaccinationType, Protos.Pets.GetAllPets.VaccinationType>();
        typeAdapterConfig.NewConfig<GetAllPetsResponse.PetType, Protos.Pets.GetAllPets.PetType>();
        typeAdapterConfig.NewConfig<GetAllPetsResponse.LostPetRecordDto,  Protos.Pets.GetAllPets.LostPetRecord>();
        typeAdapterConfig.NewConfig<GetAllPetsResponse.PetWasSeenDto,  Protos.Pets.GetAllPets.PetWasSeen>();
        
        typeAdapterConfig.NewConfig<Protos.Pets.GetPetsFilteredByChip.GetPetsFilteredByChipRequest, GetPetsFilteredByChipRequest>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse, Protos.Pets.GetPetsFilteredByChip.GetPetsFilteredByChipResponse>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.PetDto, Protos.Pets.GetPetsFilteredByChip.PetDto>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.VaccinationDto, Protos.Pets.GetPetsFilteredByChip.Vaccination>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.VaccinationType, Protos.Pets.GetPetsFilteredByChip.VaccinationType>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.PetType, Protos.Pets.GetPetsFilteredByChip.PetType>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.LostPetRecordDto,  Protos.Pets.GetPetsFilteredByChip.LostPetRecord>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.PetWasSeenDto,  Protos.Pets.GetPetsFilteredByChip.PetWasSeen>();

        typeAdapterConfig.NewConfig<Protos.Pets.DeletePet.DeletePetRequest, DeletePetRequest>();
        typeAdapterConfig.NewConfig<DeletePetResponse, Protos.Pets.DeletePet.DeletePetResponse>();
        
        typeAdapterConfig.NewConfig<GetPetResponse, Protos.Pets.GetPet.GetPetResponse>();
        typeAdapterConfig.NewConfig<GetPetResponse.VaccinationDto, Protos.Pets.GetPet.Vaccination>();
        typeAdapterConfig.NewConfig<GetPetResponse.VaccinationType, Protos.Pets.GetPet.VaccinationType>();
        typeAdapterConfig.NewConfig<GetPetResponse.PetType, Protos.Pets.GetPet.PetType>();

        typeAdapterConfig.NewConfig<Protos.Pets.UpdatePet.UpdatePetRequest, UpdatePetRequest>()
            .Ignore(d => d.Losts);
        typeAdapterConfig.NewConfig<Protos.Pets.UpdatePet.Vaccination, UpdatePetRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Pets.UpdatePet.VaccinationType, UpdatePetRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Pets.UpdatePet.PetType, UpdatePetRequest.PetType>();
        typeAdapterConfig.NewConfig<UpdatePetResponse, Protos.Pets.UpdatePet.UpdatePetResponse>();
        
        return typeAdapterConfig;
    }
}
