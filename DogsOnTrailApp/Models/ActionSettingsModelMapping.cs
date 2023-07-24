using Mapster;
using SharedCode.Entities;
using SharedCode.Extensions;
using Action = Protos.Actions.GetAllActions.Action;

namespace DogsOnTrailApp.Models;

internal static class ActionSettingsModelMapping
{
    internal static TypeAdapterConfig AddActionSettingsModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Actions.GetActionEntrySettings.GetActionEntrySettingsResponse, ActionSettingsModel>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetActionEntrySettings.RaceDto, ActionSettingsModel.RaceDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetActionEntrySettings.CategoryDto, ActionSettingsModel.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetActionEntrySettings.RaceLimitsDto, ActionSettingsModel.RaceLimits>();

        return typeAdapterConfig;
    }
}