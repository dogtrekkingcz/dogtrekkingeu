using System.Globalization;
using SharedCode.Entities;
using Google.Protobuf.Collections;
using Mapster;
using SharedCode.Extensions;

namespace DogsOnTrailApp.Models;

 internal static class ActionModelMapping
{
    internal static TypeAdapterConfig AddActionModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.GetActionResponse, ActionModel>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.ActionType, ActionModel.ActionType>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RacerDto, ActionModel.RacerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.NoteDto, ActionModel.NoteDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.PaymentDto, ActionModel.PaymentDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RequestedPaymentItem, ActionModel.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RequestedPaymentsDto, ActionModel.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.AddressDto, ActionModel.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.CategoryDto, ActionModel.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.DogDto, ActionModel.DogDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.LimitsDto, ActionModel.LimitsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RaceDto, ActionModel.RaceDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RaceState, ActionModel.RaceState>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.TermDto, ActionModel.TermDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.VaccinationDto, ActionModel.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.VaccinationType, ActionModel.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.ActionSaleDto, ActionModel.ActionSaleDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.MerchandizeItemDto, ActionModel.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.PaymentDefinitionDto, ActionModel.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.ActionSaleItemDto, ActionModel.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, ActionModel.LatLngDto>()
            .Map(d => d.GpsLatitude, s => s.Latitude)
            .Map(d => d.GpsLongitude, s => s.Longitude);
        
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.Action, ActionModel>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.ActionType, ActionModel.ActionType>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.RacerDto, ActionModel.RacerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.NoteDto, ActionModel.NoteDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.PaymentDto, ActionModel.PaymentDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.RequestedPaymentItem, ActionModel.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.RequestedPaymentsDto, ActionModel.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.AddressDto, ActionModel.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.CategoryDto, ActionModel.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.DogDto, ActionModel.DogDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.LimitsDto, ActionModel.LimitsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.RaceDto, ActionModel.RaceDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.RaceState, ActionModel.RaceState>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.TermDto, ActionModel.TermDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.VaccinationDto, ActionModel.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.VaccinationType, ActionModel.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.ActionSaleDto, ActionModel.ActionSaleDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.MerchandizeItemDto, ActionModel.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.PaymentDefinitionDto, ActionModel.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.ActionSaleItemDto, ActionModel.ActionSaleItemDto>();

        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.Action, ActionModel>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.ActionType, ActionModel.ActionType>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.RacerDto, ActionModel.RacerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.NoteDto, ActionModel.NoteDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.PaymentDto, ActionModel.PaymentDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.RequestedPaymentItem, ActionModel.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.RequestedPaymentsDto, ActionModel.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.AddressDto, ActionModel.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.CategoryDto, ActionModel.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.DogDto, ActionModel.DogDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.LimitsDto, ActionModel.LimitsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.RaceDto, ActionModel.RaceDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.RaceState, ActionModel.RaceState>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.TermDto, ActionModel.TermDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.VaccinationDto, ActionModel.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.VaccinationType, ActionModel.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.ActionSaleDto, ActionModel.ActionSaleDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.MerchandizeItemDto, ActionModel.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.PaymentDefinitionDto, ActionModel.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.ActionSaleItemDto, ActionModel.ActionSaleItemDto>();
        
        return typeAdapterConfig;
    }
}