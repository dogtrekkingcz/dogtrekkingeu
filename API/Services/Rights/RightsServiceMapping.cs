using PetsOnTrail.Interfaces.Actions.Entities.Rights;
using Mapster;
using Storage.Entities.ActionRights;

namespace PetsOnTrail.Actions.Services.Rights;

internal static class RightsServiceMapping
{
    public static TypeAdapterConfig AddRightsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetAllRightsRequest, GetAllRightsInternalStorageRequest>();
        typeAdapterConfig.NewConfig<GetAllRightsInternalStorageResponse, GetAllRightsResponse>();
        typeAdapterConfig.NewConfig<GetAllRightsInternalStorageResponse.ActionRightsDto, GetAllRightsResponse.ActionRightsDto>();
        
        typeAdapterConfig.NewConfig<AddActionRightsInternalStorageRequest, AddActionRightsInternalStorageRequest>();
        typeAdapterConfig.NewConfig<AddActionRightsInternalStorageResponse, AddActionRightsInternalStorageResponse>();
        
        typeAdapterConfig.NewConfig<DeleteActionRightsRequest, DeleteActionRightsRequest>();

        return typeAdapterConfig;
    }
}