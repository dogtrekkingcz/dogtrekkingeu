using System.Globalization;
using Google.Protobuf.Collections;
using Mapster;
using DogtrekkingCz.Shared.Extensions;
using DogtrekkingCz.Shared.Entities;

namespace DogtrekkingCzApp.Models;

 internal static class ActionModelMapping
{
    internal static TypeAdapterConfig AddActionModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<RepeatedField<Protos.Shared.ActionDetail>, IList<ActionModel>>()
            .TwoWays();

        typeAdapterConfig.NewConfig<Protos.Shared.ActionDetail, ActionModel>()
            .TwoWays();

        typeAdapterConfig.NewConfig<Protos.Shared.ActionSimple, ActionModel>()
            .TwoWays();

        typeAdapterConfig.NewConfig<Protos.Shared.RaceSimple, RaceDto>()
            .Ignore(d => d.Categories)
            .TwoWays();

        return typeAdapterConfig;
    }
}