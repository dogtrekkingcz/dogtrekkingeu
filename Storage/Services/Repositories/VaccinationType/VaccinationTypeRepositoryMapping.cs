using Mapster;
using Storage.Entities.VaccinationTypes;
using Storage.Models;

namespace Storage.Services.Repositories.VaccinationType;

internal static class VaccinationTypeRepositoryMapping
{
    internal static TypeAdapterConfig AddVaccinationTypeRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<AddVaccinationTypeInternalStorageRequest, VaccinationTypeRecord>()
            .Ignore(d => d.CorrelationId);

        typeAdapterConfig.NewConfig<VaccinationTypeRecord, GetAllVaccinationTypesInternalStorageResponse.VaccinationTypeDto>();

        return typeAdapterConfig;
    }
}