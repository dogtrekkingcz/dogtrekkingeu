using System.Globalization;
using Google.Protobuf.Collections;
using Mapster;
using Storage.Entities.Actions;

namespace DogtrekkingCzApp.Models;

 internal static class ActionModelMapping
{
    internal static TypeAdapterConfig AddActionModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<RepeatedField<Protos.Actions.ActionDto>, IList<ActionModel>>();
        typeAdapterConfig.NewConfig<Protos.Actions.ActionDto, ActionModel>();
        typeAdapterConfig.NewConfig<Protos.Actions.OwnerDto, ActionModel.OwnerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.TermDto, ActionModel.TermDto>()
            .Map(d => d.From, s => DateTime.ParseExact(s.From, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
            .Map(d => d.To, s => DateTime.ParseExact(s.To, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        typeAdapterConfig.NewConfig<Protos.Actions.AddressDto, ActionModel.AddressDto>();
        
        typeAdapterConfig.NewConfig<ActionModel, Protos.Actions.ActionDto>();
        typeAdapterConfig.NewConfig<ActionModel.OwnerDto, Protos.Actions.OwnerDto>();
        typeAdapterConfig.NewConfig<ActionModel.TermDto, Protos.Actions.TermDto>()
            .Map(d => d.From, s => s.From.ToString("yyyy-MM-dd HH:mm:ss"))
            .Map(d => d.To, s => s.To.ToString("yyyy-MM-dd HH:mm:ss"));
        typeAdapterConfig.NewConfig<ActionModel.AddressDto, Protos.Actions.AddressDto>();

        return typeAdapterConfig;
    }
}