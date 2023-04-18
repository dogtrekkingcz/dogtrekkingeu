using DogtrekkingCz.Interfaces.Actions.Entities.Actions;
using Mapster;
using Storage.Entities.Actions;

namespace DogtrekkingCz.Actions.Services.ActionsManage;

internal static class ActionsServiceMapping
{
    public static TypeAdapterConfig AddActionsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse, GetAllActionsResponse>();
            
        return typeAdapterConfig;
    }
}