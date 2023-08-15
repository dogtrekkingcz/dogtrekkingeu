using System;
using Google.Protobuf.Collections;
using Mapster;
using SharedLib.Extensions;

namespace SharedLib;

public static class Mapping
{
    public static TypeAdapterConfig CreateFrontendMapping()
    {
        var typeAdapterConfig = new TypeAdapterConfig
        {
            RequireDestinationMemberSource = true,
            RequireExplicitMapping = true,
            Default =
            {
                Settings =
                {
                    UseDestinationValues =
                    {
                        (member => member.SetterModifier == AccessModifier.None &&
                                   member.Type.IsGenericType &&
                                   member.Type.GetGenericTypeDefinition() == typeof(RepeatedField<>))
                    }
                }
            }
        };


        typeAdapterConfig.NewConfig<Google.Type.DateTime, DateTimeOffset?>()
        .Map(d => d, s => s.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Google.Type.DateTime, DateTimeOffset>()
        .Map(d => d, s => s.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<DateTimeOffset, Google.Type.DateTime>()
        .Map(d => d, s => s.ToGoogleDateTime());
        typeAdapterConfig.NewConfig<DateTimeOffset?, Google.Type.DateTime>()
        .Map(d => d, s => s.ToGoogleDateTime());

        typeAdapterConfig.NewConfig<Google.Type.Interval, Google.Type.Interval>();
        typeAdapterConfig.NewConfig<Google.Protobuf.WellKnownTypes.Timestamp, Google.Protobuf.WellKnownTypes.Timestamp>();
        typeAdapterConfig.NewConfig<Google.Type.DateTime, Google.Type.DateTime>();
        typeAdapterConfig.NewConfig<Google.Protobuf.WellKnownTypes.Duration, Google.Protobuf.WellKnownTypes.Duration>();
        typeAdapterConfig.NewConfig<Google.Type.TimeZone, Google.Type.TimeZone>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, Google.Type.LatLng>();

        return typeAdapterConfig;
    }
}