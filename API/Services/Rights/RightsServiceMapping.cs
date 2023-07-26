using DogsOnTrail.Interfaces.Actions.Entities.Rights;
using Mapster;

namespace DogsOnTrail.Actions.Services.Rights;

internal static class RightsServiceMapping
{
    public static TypeAdapterConfig AddRightsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Storage.Entities.ActionRights.GetAllRightsInternalStorageResponse, GetAllRightsResponse>();

        return typeAdapterConfig;
    }
}