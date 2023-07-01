﻿using System.Globalization;
using SharedCode.Entities;
using Google.Protobuf.Collections;
using Mapster;
using SharedCode.Extensions;

namespace DogsOnTrailApp.Models;

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
        
        return typeAdapterConfig;
    }
}