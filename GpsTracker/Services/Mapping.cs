using Mapster;

namespace GpsTracker.Services;

public static class Mapping
{
    public static TypeAdapterConfig AddMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<IGpsPositionService.PositionDto, IPositionRepository.PositionDto>();
        
        return typeAdapterConfig;
    }
}