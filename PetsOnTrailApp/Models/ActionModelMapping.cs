using PetsOnTrailApp.Extensions;
using Mapster;

namespace PetsOnTrailApp.Models;

 internal static class ActionModelMapping
{
    internal static TypeAdapterConfig AddActionModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<ActionModel, Protos.Actions.CreateAction.CreateActionRequest>();
        typeAdapterConfig.NewConfig<ActionModel.ActionType, Protos.Actions.CreateAction.ActionType>();
        typeAdapterConfig.NewConfig<ActionModel.RacerDto, Protos.Actions.CreateAction.RacerDto>();
        typeAdapterConfig.NewConfig<ActionModel.NoteDto, Protos.Actions.CreateAction.NoteDto>();
        typeAdapterConfig.NewConfig<ActionModel.PaymentDto, Protos.Actions.CreateAction.PaymentDto>();
        typeAdapterConfig.NewConfig<ActionModel.RequestedPaymentItem, Protos.Actions.CreateAction.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<ActionModel.RequestedPaymentsDto, Protos.Actions.CreateAction.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<ActionModel.AddressDto, Protos.Actions.CreateAction.AddressDto>();
        typeAdapterConfig.NewConfig<ActionModel.CategoryDto, Protos.Actions.CreateAction.CategoryDto>();
        typeAdapterConfig.NewConfig<ActionModel.DogDto, Protos.Actions.CreateAction.DogDto>();
        typeAdapterConfig.NewConfig<ActionModel.LimitsDto, Protos.Actions.CreateAction.LimitsDto>();
        typeAdapterConfig.NewConfig<ActionModel.CheckpointDto, Protos.Actions.CreateAction.CheckpointDto>();
        typeAdapterConfig.NewConfig<ActionModel.RaceDto, Protos.Actions.CreateAction.RaceDto>();
        typeAdapterConfig.NewConfig<ActionModel.RaceState, Protos.Actions.CreateAction.RaceState>();
        typeAdapterConfig.NewConfig<ActionModel.TermDto, Protos.Actions.CreateAction.TermDto>();
        typeAdapterConfig.NewConfig<ActionModel.VaccinationDto, Protos.Actions.CreateAction.VaccinationDto>();
        typeAdapterConfig.NewConfig<ActionModel.VaccinationType, Protos.Actions.CreateAction.VaccinationType>();
        typeAdapterConfig.NewConfig<ActionModel.ActionSaleDto, Protos.Actions.CreateAction.ActionSaleDto>();
        typeAdapterConfig.NewConfig<ActionModel.MerchandizeItemDto, Protos.Actions.CreateAction.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<ActionModel.PaymentDefinitionDto, Protos.Actions.CreateAction.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<ActionModel.ActionSaleItemDto, Protos.Actions.CreateAction.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<ActionModel.LatLngDto, Google.Type.LatLng>()
            .Map(d => d.Latitude, s => s.GpsLatitude)
            .Map(d => d.Longitude, s => s.GpsLongitude);
        typeAdapterConfig.NewConfig<ActionModel.CheckpointDto, Protos.Actions.CreateAction.CheckpointDto>();
        
        typeAdapterConfig.NewConfig<ActionModel, Protos.Actions.UpdateAction.UpdateActionRequest>();
        typeAdapterConfig.NewConfig<ActionModel.ActionType, Protos.Actions.UpdateAction.ActionType>();
        typeAdapterConfig.NewConfig<ActionModel.RacerDto, Protos.Actions.UpdateAction.RacerDto>();
        typeAdapterConfig.NewConfig<ActionModel.NoteDto, Protos.Actions.UpdateAction.NoteDto>();
        typeAdapterConfig.NewConfig<ActionModel.PaymentDto, Protos.Actions.UpdateAction.PaymentDto>();
        typeAdapterConfig.NewConfig<ActionModel.RequestedPaymentItem, Protos.Actions.UpdateAction.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<ActionModel.RequestedPaymentsDto, Protos.Actions.UpdateAction.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<ActionModel.AddressDto, Protos.Actions.UpdateAction.AddressDto>();
        typeAdapterConfig.NewConfig<ActionModel.CategoryDto, Protos.Actions.UpdateAction.CategoryDto>();
        typeAdapterConfig.NewConfig<ActionModel.DogDto, Protos.Actions.UpdateAction.DogDto>();
        typeAdapterConfig.NewConfig<ActionModel.LimitsDto, Protos.Actions.UpdateAction.LimitsDto>();
        typeAdapterConfig.NewConfig<ActionModel.CheckpointDto, Protos.Actions.UpdateAction.CheckpointDto>();
        typeAdapterConfig.NewConfig<ActionModel.RaceDto, Protos.Actions.UpdateAction.RaceDto>();
        typeAdapterConfig.NewConfig<ActionModel.RaceState, Protos.Actions.UpdateAction.RaceState>();
        typeAdapterConfig.NewConfig<ActionModel.TermDto, Protos.Actions.UpdateAction.TermDto>();
        typeAdapterConfig.NewConfig<ActionModel.VaccinationDto, Protos.Actions.UpdateAction.VaccinationDto>();
        typeAdapterConfig.NewConfig<ActionModel.VaccinationType, Protos.Actions.UpdateAction.VaccinationType>();
        typeAdapterConfig.NewConfig<ActionModel.ActionSaleDto, Protos.Actions.UpdateAction.ActionSaleDto>();
        typeAdapterConfig.NewConfig<ActionModel.MerchandizeItemDto, Protos.Actions.UpdateAction.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<ActionModel.PaymentDefinitionDto, Protos.Actions.UpdateAction.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<ActionModel.ActionSaleItemDto, Protos.Actions.UpdateAction.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<ActionModel.CheckpointDto, Protos.Actions.UpdateAction.CheckpointDto>();

        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.GetActionResponse, ActionModel>()
            .Map(d => d.Created, s => s.Created.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.ActionType, ActionModel.ActionType>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RacerDto, ActionModel.RacerDto>()
            .Map(d => d.Finish, s => s.Finish.ToDateTimeOffset())
            .Map(d => d.Start, s => s.Start.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.NoteDto, ActionModel.NoteDto>()
            .Map(d => d.Time, s => s.Time.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.PaymentDto, ActionModel.PaymentDto>()
            .Map(d => d.Date, s => s.Date.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RequestedPaymentItem, ActionModel.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RequestedPaymentsDto, ActionModel.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.AddressDto, ActionModel.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.CategoryDto, ActionModel.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.DogDto, ActionModel.DogDto>()
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset())
            .Map(d => d.Decease, s => s.Decease.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.LimitsDto, ActionModel.LimitsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.CheckpointDto, ActionModel.CheckpointDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RaceDto, ActionModel.RaceDto>()
            .Map(d => d.EnteringFrom, s => s.EnteringFrom.ToDateTimeOffset())
            .Map(d => d.EnteringTo, s => s.EnteringTo.ToDateTimeOffset())
            .Map(d => d.Begin, s => s.Begin.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.RaceState, ActionModel.RaceState>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.TermDto, ActionModel.TermDto>()
            .Map(d => d.From, s => s.From.ToDateTimeOffset())
            .Map(d => d.To, s => s.To.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.VaccinationDto, ActionModel.VaccinationDto>()
            .Map(d => d.Date, s => s.Date.ToDateTimeOffset())
            .Map(d => d.ValidUntil, s => s.ValidUntil.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.VaccinationType, ActionModel.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.ActionSaleDto, ActionModel.ActionSaleDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.MerchandizeItemDto, ActionModel.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.PaymentDefinitionDto, ActionModel.PaymentDefinitionDto>()
            .Map(d => d.From, s => s.From.ToDateTimeOffset())
            .Map(d => d.To, s => s.To.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.ActionSaleItemDto, ActionModel.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, ActionModel.LatLngDto>()
            .Map(d => d.GpsLatitude, s => s.Latitude)
            .Map(d => d.GpsLongitude, s => s.Longitude);
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.CheckpointDto, ActionModel.CheckpointDto>();

        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.Action, ActionModel>()
            .Ignore(d => d.Checkpoints);
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
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.CheckpointDto, ActionModel.CheckpointDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.RaceDto, ActionModel.RaceDto>()
            .Map(d => d.Begin, s => s.Begin.ToDateTimeOffset())
            .Map(d => d.EnteringFrom, s => s.EnteringFrom.ToDateTimeOffset())
            .Map(d => d.EnteringTo, s => s.EnteringTo.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.RaceState, ActionModel.RaceState>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.TermDto, ActionModel.TermDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.VaccinationDto, ActionModel.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.VaccinationType, ActionModel.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.ActionSaleDto, ActionModel.ActionSaleDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.MerchandizeItemDto, ActionModel.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.PaymentDefinitionDto, ActionModel.PaymentDefinitionDto>()
            .Map(d => d.From, s => s.From.ToDateTimeOffset())
            .Map(d => d.To, s => s.To.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.ActionSaleItemDto, ActionModel.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.CheckpointDto, ActionModel.CheckpointDto>();
        
        return typeAdapterConfig;
    }
}