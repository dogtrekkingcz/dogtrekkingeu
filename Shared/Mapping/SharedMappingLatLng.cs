using Mapster;
using DogtrekkingCz.Shared.Entities;
using DogtrekkingCz.Shared.Extensions;

namespace DogtrekkingCz.Shared.Mapping
{
    public static class SharedMappingLatLng
    {
        public static TypeAdapterConfig AddSharedMappingLatLng(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<LatLngDto, Google.Type.LatLng>()
                .MapWith(s => new Google.Type.LatLng { Latitude = s.GpsLatitude, Longitude = s.GpsLongitude });

            typeAdapterConfig.NewConfig<Google.Type.LatLng, LatLngDto>()
                .MapWith(s => new LatLngDto { GpsLatitude = s.Latitude, GpsLongitude = s.Longitude });

            typeAdapterConfig.NewConfig<LatLngDto, LatLngDto>();

            return typeAdapterConfig;
        }
    }
}
