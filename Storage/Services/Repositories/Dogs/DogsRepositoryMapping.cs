using DogtrekkingCzShared.Entities;
using Mapster;
using Storage.Entities.Dogs;
using Storage.Models;

namespace Storage.Services.Repositories.Dogs
{
    internal static class DogsRepositoryMapping
    {
        internal static TypeAdapterConfig AddDogsRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddDogInternalStorageRequest, DogRecord>()
                .Ignore(d => d.Id);

            typeAdapterConfig.NewConfig<DogRecord, DogDto>()
                .IgnoreNullValues(true)
                .TwoWays();

            typeAdapterConfig.NewConfig<DogRecord.VaccinationDto, DogDto.VaccinationDto>()
                .IgnoreNullValues(true)
                .TwoWays();

            return typeAdapterConfig;
        }
    }
}