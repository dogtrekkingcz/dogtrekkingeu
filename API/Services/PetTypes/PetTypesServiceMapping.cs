using PetsOnTrail.Interfaces.Actions.Entities.PetTypes;
using Mapster;
using Storage.Entities.PetTypes;

namespace PetsOnTrail.Actions.Services.PetsManage;

internal static class PetTypesServiceMapping
{
    public static TypeAdapterConfig AddPetTypesMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetPetTypesInternalStorageResponse, GetPetTypesResponse>();
        typeAdapterConfig.NewConfig<GetPetTypesInternalStorageResponse.PetTypeDto, GetPetTypesResponse.PetTypeDto>();

        return typeAdapterConfig;
    }
}