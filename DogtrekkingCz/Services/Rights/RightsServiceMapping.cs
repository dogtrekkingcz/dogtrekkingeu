using DogtrekkingCz.Interfaces.Actions.Entities.Rights;
using Mapster;

namespace DogtrekkingCz.Actions.Services.Rights;

internal static class RightsServiceMapping
{
    public static TypeAdapterConfig AddRightsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Storage.Entities.ActionRights.GetAllRightsResponse, GetAllRightsResponse>();

        return typeAdapterConfig;
    }
}