using Mapster;

namespace DogsOnTrailApp.Models;

internal static class ActionSettingsModelMapping
{
    internal static TypeAdapterConfig AddActionSettingsModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Actions.GetActionEntrySettingsResponse, ActionSettingsModel>()
            .TwoWays();
        
        typeAdapterConfig.NewConfig<Protos.Actions.RaceDto, ActionSettingsModel.RaceDto>()
            .TwoWays();
        
        typeAdapterConfig.NewConfig<Protos.Actions.CategoryDto, ActionSettingsModel.CategoryDto>()
            .TwoWays();

        return typeAdapterConfig;
    }
}