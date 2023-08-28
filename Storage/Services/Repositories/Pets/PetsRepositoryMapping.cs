using Mapster;
using Storage.Entities.Pets;
using Storage.Models;

namespace Storage.Services.Repositories.Pets
{
    internal static class PetsRepositoryMapping
    {
        internal static TypeAdapterConfig AddPetsRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<CreatePetInternalStorageRequest, PetRecord>()
                .Map(d => d.Id, s => s.Id.ToString());
            typeAdapterConfig.NewConfig<CreatePetInternalStorageRequest.VaccinationDto, PetRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<CreatePetInternalStorageRequest.VaccinationType, PetRecord.VaccinationType>();
            typeAdapterConfig.NewConfig<CreatePetInternalStorageRequest.PetType, PetRecord.PetType>();
            typeAdapterConfig.NewConfig<CreatePetInternalStorageRequest.LostPetRecordDto, PetRecord.LostPetRecordDto>();
            typeAdapterConfig.NewConfig<CreatePetInternalStorageRequest.PetWasSeenDto, PetRecord.PetWasSeenDto>();
            
            typeAdapterConfig.NewConfig<UpdatePetInternalStorageRequest, PetRecord>();
            typeAdapterConfig.NewConfig<UpdatePetInternalStorageRequest.VaccinationDto, PetRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<UpdatePetInternalStorageRequest.VaccinationType, PetRecord.VaccinationType>();
            typeAdapterConfig.NewConfig<UpdatePetInternalStorageRequest.PetType, PetRecord.PetType>();
            typeAdapterConfig.NewConfig<UpdatePetInternalStorageRequest.LostPetRecordDto, PetRecord.LostPetRecordDto>();
            typeAdapterConfig.NewConfig<UpdatePetInternalStorageRequest.PetWasSeenDto, PetRecord.PetWasSeenDto>();
            
            typeAdapterConfig.NewConfig<PetRecord, GetPetsFilteredByChipInternalStorageResponse.PetDto>();
            typeAdapterConfig.NewConfig<PetRecord.VaccinationDto, GetPetsFilteredByChipInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<PetRecord.VaccinationType, GetPetsFilteredByChipInternalStorageResponse.VaccinationType>();
            typeAdapterConfig.NewConfig<PetRecord.PetType, GetPetsFilteredByChipInternalStorageResponse.PetType>();
            typeAdapterConfig.NewConfig<PetRecord.LostPetRecordDto, GetPetsFilteredByChipInternalStorageResponse.LostPetRecordDto>();
            typeAdapterConfig.NewConfig<PetRecord.PetWasSeenDto, GetPetsFilteredByChipInternalStorageResponse.PetWasSeenDto>();
            
            typeAdapterConfig.NewConfig<PetRecord, GetAllPetsInternalStorageResponse.PetDto>();
            typeAdapterConfig.NewConfig<PetRecord.VaccinationDto, GetAllPetsInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<PetRecord.VaccinationType, GetAllPetsInternalStorageResponse.VaccinationType>();
            typeAdapterConfig.NewConfig<PetRecord.PetType, GetAllPetsInternalStorageResponse.PetType>();
            typeAdapterConfig.NewConfig<PetRecord.LostPetRecordDto, GetAllPetsInternalStorageResponse.LostPetRecordDto>();
            typeAdapterConfig.NewConfig<PetRecord.PetWasSeenDto, GetAllPetsInternalStorageResponse.PetWasSeenDto>();
            
            typeAdapterConfig.NewConfig<PetRecord, GetPetInternalStorageResponse>();
            typeAdapterConfig.NewConfig<PetRecord.VaccinationDto, GetPetInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<PetRecord.VaccinationType, GetPetInternalStorageResponse.VaccinationType>();
            typeAdapterConfig.NewConfig<PetRecord.PetType, GetPetInternalStorageResponse.PetType>();
            
            return typeAdapterConfig;
        }
    }
}