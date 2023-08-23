using DogsOnTrail.Interfaces.Actions.Entities.Pets;
using Mapster;
using Storage.Entities.Pets;

namespace DogsOnTrail.Actions.Services.PetsManage;

internal static class PetsServiceMapping
{
    public static TypeAdapterConfig AddPetsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<CreatePetRequest, CreatePetInternalStorageRequest>()
            .Ignore(d => d.Id)
            .Ignore(d => d.UserId);
        typeAdapterConfig.NewConfig<CreatePetRequest.VaccinationDto, CreatePetInternalStorageRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<CreatePetRequest.VaccinationType, CreatePetInternalStorageRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<CreatePetRequest.PetType, CreatePetInternalStorageRequest.PetType>();
        typeAdapterConfig.NewConfig<CreatePetRequest.LostPetRecordDto, CreatePetInternalStorageRequest.LostPetRecordDto>();
        typeAdapterConfig.NewConfig<CreatePetRequest.PetWasSeenDto, CreatePetInternalStorageRequest.PetWasSeenDto>();
        typeAdapterConfig.NewConfig<AddPetInternalStorageResponse, CreatePetResponse>();
        
        typeAdapterConfig.NewConfig<GetAllPetsInternalStorageResponse, GetAllPetsResponse>();
        typeAdapterConfig.NewConfig<GetAllPetsInternalStorageResponse.PetDto, GetAllPetsResponse.PetDto>();
        typeAdapterConfig.NewConfig<GetAllPetsInternalStorageResponse.VaccinationType, GetAllPetsResponse.VaccinationType>();
        typeAdapterConfig.NewConfig<GetAllPetsInternalStorageResponse.VaccinationDto, GetAllPetsResponse.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetAllPetsInternalStorageResponse.PetType, GetAllPetsResponse.PetType>();
        typeAdapterConfig.NewConfig<GetAllPetsInternalStorageResponse.LostPetRecordDto, GetAllPetsResponse.LostPetRecordDto>();
        typeAdapterConfig.NewConfig<GetAllPetsInternalStorageResponse.PetWasSeenDto, GetAllPetsResponse.PetWasSeenDto>();
        
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse, GetPetsFilteredByChipResponse>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.PetDto, GetPetsFilteredByChipResponse.PetDto>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.VaccinationType, GetPetsFilteredByChipResponse.VaccinationType>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.VaccinationDto, GetPetsFilteredByChipResponse.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.PetType, GetPetsFilteredByChipResponse.PetType>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.LostPetRecordDto, GetPetsFilteredByChipResponse.LostPetRecordDto>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.PetWasSeenDto, GetPetsFilteredByChipResponse.PetWasSeenDto>();
        
        return typeAdapterConfig;
    }
}