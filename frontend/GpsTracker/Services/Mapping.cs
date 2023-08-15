using GpsTracker.Services.Storage;
using Mapster;

namespace GpsTracker.Services;

public static class Mapping
{
    public static TypeAdapterConfig AddMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<IGpsPositionService.PositionDto, PositionHistoryService.PositionDto>()
            .Ignore(d => d.Id)
            .Ignore(d => d.ActionId)
            .Ignore(d => d.TimeOfSynchronizationWithServer);

        typeAdapterConfig.NewConfig<Location, PositionHistoryService.PositionDto>()
            .Map(d => d.Time, s => s.Timestamp)
            .Ignore(d => d.ActionId)
            .Ignore(d => d.Id)
            .Ignore(d => d.TimeOfSynchronizationWithServer);
        
        return typeAdapterConfig;
    }
}