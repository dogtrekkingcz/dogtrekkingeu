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
                .Map(d => d.Id, s => s.Id.ToString())
                .Ignore(d => d.CorrelationId);
            typeAdapterConfig.NewConfig<CreatePetInternalStorageRequest.VaccinationDto, PetRecord.VaccinationDto>();
            
            typeAdapterConfig.NewConfig<UpdatePetInternalStorageRequest, PetRecord>()
                .Ignore(d => d.CorrelationId);
            typeAdapterConfig.NewConfig<UpdatePetInternalStorageRequest.VaccinationDto, PetRecord.VaccinationDto>();
            
            typeAdapterConfig.NewConfig<PetRecord, GetPetsFilteredByChipInternalStorageResponse.PetDto>();
            typeAdapterConfig.NewConfig<PetRecord.VaccinationDto, GetPetsFilteredByChipInternalStorageResponse.VaccinationDto>();
            
            typeAdapterConfig.NewConfig<PetRecord, GetAllPetsInternalStorageResponse.PetDto>();
            typeAdapterConfig.NewConfig<PetRecord.VaccinationDto, GetAllPetsInternalStorageResponse.VaccinationDto>();
            
            typeAdapterConfig.NewConfig<PetRecord, GetPetInternalStorageResponse>();
            typeAdapterConfig.NewConfig<PetRecord.VaccinationDto, GetPetInternalStorageResponse.VaccinationDto>();
            
            return typeAdapterConfig;
        }
    }
}