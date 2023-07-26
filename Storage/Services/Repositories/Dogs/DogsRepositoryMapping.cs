using Mapster;
using Storage.Entities.Dogs;
using Storage.Models;

namespace Storage.Services.Repositories.Dogs
{
    internal static class DogsRepositoryMapping
    {
        internal static TypeAdapterConfig AddDogsRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<CreateDogInternalStorageRequest, DogRecord>();
            typeAdapterConfig.NewConfig<CreateDogInternalStorageRequest.VaccinationDto, DogRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<CreateDogInternalStorageRequest.VaccinationType, DogRecord.VaccinationType>();
            
            typeAdapterConfig.NewConfig<UpdateDogInternalStorageRequest, DogRecord>();
            typeAdapterConfig.NewConfig<UpdateDogInternalStorageRequest.VaccinationDto, DogRecord.VaccinationDto>();
            typeAdapterConfig.NewConfig<UpdateDogInternalStorageRequest.VaccinationType, DogRecord.VaccinationType>();
            
            typeAdapterConfig.NewConfig<DogRecord, GetDogsFilteredByChipInternalStorageResponse.DogDto>();
            typeAdapterConfig.NewConfig<DogRecord.VaccinationDto, GetDogsFilteredByChipInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<DogRecord.VaccinationType, GetDogsFilteredByChipInternalStorageResponse.VaccinationType>();
            
            typeAdapterConfig.NewConfig<DogRecord, GetAllDogsInternalStorageResponse.DogDto>();
            typeAdapterConfig.NewConfig<DogRecord.VaccinationDto, GetAllDogsInternalStorageResponse.VaccinationDto>();
            typeAdapterConfig.NewConfig<DogRecord.VaccinationType, GetAllDogsInternalStorageResponse.VaccinationType>();
            
            return typeAdapterConfig;
        }
    }
}