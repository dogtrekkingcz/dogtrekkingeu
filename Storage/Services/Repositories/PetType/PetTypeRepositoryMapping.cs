using Mapster;
using Storage.Entities.PetTypes;
using Storage.Models;

namespace Storage.Services.Repositories.PetType;

internal static class PetTypeRepositoryMapping
{
    internal static TypeAdapterConfig AddPetTypeRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<AddPetTypeInternalStorageRequest, PetTypeRecord>()
            .Ignore(d => d.CorrelationId);

        typeAdapterConfig.NewConfig<PetTypeRecord, GetPetTypesInternalStorageResponse.PetTypeDto>();

        return typeAdapterConfig;
    }
}