using DogsOnTrail.Interfaces.Actions.Entities.Rights;
using Mapster;
using Storage.Entities.ActionRights;

namespace DogsOnTrail.Actions.Services.Rights;

internal static class RightsServiceMapping
{
    public static TypeAdapterConfig AddRightsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetAllRightsRequest, Storage.Entities.ActionRights.GetAllRightsInternalStorageRequest>();
        typeAdapterConfig.NewConfig<Storage.Entities.ActionRights.GetAllRightsInternalStorageResponse, GetAllRightsResponse>();
        typeAdapterConfig.NewConfig<Storage.Entities.ActionRights.GetAllRightsInternalStorageResponse.ActionRightsDto, GetAllRightsResponse.ActionRightsDto>();
        
        typeAdapterConfig.NewConfig<AddActionRightsInternalStorageRequest, Storage.Entities.ActionRights.AddActionRightsInternalStorageRequest>();
        typeAdapterConfig.NewConfig<AddActionRightsInternalStorageRequest.RoleType, Storage.Entities.ActionRights.AddActionRightsInternalStorageRequest.RoleType>();
        typeAdapterConfig.NewConfig<Storage.Entities.ActionRights.AddActionRightsInternalStorageResponse, AddActionRightsInternalStorageResponse>();
        
        typeAdapterConfig.NewConfig<Storage.Entities.ActionRights.DeleteActionRightsRequest, DeleteActionRightsRequest>();

        return typeAdapterConfig;
    }
}