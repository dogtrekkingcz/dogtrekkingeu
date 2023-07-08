using DogsOnTrail.Interfaces.Actions.Entities.Actions;
using Mapster;
using Storage.Entities.Actions;

namespace DogsOnTrail.Actions.Services.ActionsManage;

internal static class ActionsServiceMapping
{
    public static TypeAdapterConfig AddActionsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse, GetAllActionsResponse>();

        typeAdapterConfig.NewConfig<GetSelectedActionsRequest, GetSelectedActionsInternalStorageRequest>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse, GetSelectedActionsResponse>();

        typeAdapterConfig.NewConfig<CreateActionRequest, CreateActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<CreateActionInternalStorageResponse, CreateActionResponse>();

        typeAdapterConfig.NewConfig<DeleteActionRequest, DeleteActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<GetActionEntrySettingsRequest, GetActionInternalStorageRequest>()
            .Map(d => d.Id, s => s.ActionId);

        typeAdapterConfig.NewConfig<GetActionRequest, GetActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse, GetActionResponse>();

        return typeAdapterConfig;
    }
}