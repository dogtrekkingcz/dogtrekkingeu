using Mapster;
using SharedCode.Entities;
using SharedCode.Extensions;

namespace DogsOnTrailApp.Models;

internal static class ActionSettingsModelMapping
{
    internal static TypeAdapterConfig AddActionSettingsModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Actions.GetActionEntrySettingsResponse, ActionSettingsModel>()
            .TwoWays();
        
        typeAdapterConfig.NewConfig<Protos.Actions.RaceDto, ActionSettingsModel.RaceDto>()
            .IgnoreNullValues(true)
            .Map(d => d.Start, s => s.Start.ToDateTimeOffset());
        
        typeAdapterConfig.NewConfig<ActionSettingsModel.RaceDto, Protos.Actions.RaceDto>()
            .IgnoreNullValues(true)
            .Map(d => d.Start, s => s.Start.ToGoogleTimestamp());

        typeAdapterConfig.NewConfig<Protos.Actions.CategoryDto, ActionSettingsModel.CategoryDto>()
            .TwoWays();

        typeAdapterConfig.NewConfig<Protos.Shared.RaceLimits, ActionSettingsDto.RaceLimits>();

        return typeAdapterConfig;
    }
}