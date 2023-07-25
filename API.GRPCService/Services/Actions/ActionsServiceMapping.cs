using DogsOnTrail.Interfaces.Actions.Entities.Actions;
using Google.Protobuf.Collections;
using Mapster;
using SharedCode.Entities;

namespace API.GRPCService.Services.Actions;

internal static class ActionsServiceMapping
{
    internal static TypeAdapterConfig AddActionsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<UpdateActionResponse, Protos.Actions.UpdateAction.UpdateActionResponse>();

        typeAdapterConfig.NewConfig<Protos.Actions.DeleteAction.DeleteActionRequest, DeleteActionRequest>();

        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.GetActionRequest, GetActionRequest>();

        typeAdapterConfig.NewConfig<GetAllActionsResponse, RepeatedField<Protos.Shared.ActionSimple>>()
            .Map(d => d, s => s.Actions)
            .Ignore(d => d.Capacity);

        typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionDto, Protos.Actions.GetAllActions.Action>();
        
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.GetAllActionsRequest, GetAllActionsRequest>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse, Protos.Actions.GetAllActions.GetAllActionsResponse>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionDto, Protos.Actions.GetAllActions.Action>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionType, Protos.Actions.GetAllActions.ActionType>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RacerDto, Protos.Actions.GetAllActions.RacerDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.NoteDto, Protos.Actions.GetAllActions.NoteDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.PaymentDto, Protos.Actions.GetAllActions.PaymentDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RequestedPaymentItem, Protos.Actions.GetAllActions.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RequestedPaymentsDto, Protos.Actions.GetAllActions.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.AddressDto, Protos.Actions.GetAllActions.AddressDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.CategoryDto, Protos.Actions.GetAllActions.CategoryDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.DogDto, Protos.Actions.GetAllActions.DogDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.LimitsDto, Protos.Actions.GetAllActions.LimitsDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RaceDto, Protos.Actions.GetAllActions.RaceDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RaceState, Protos.Actions.GetAllActions.RaceState>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.TermDto, Protos.Actions.GetAllActions.TermDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.VaccinationDto, Protos.Actions.GetAllActions.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.VaccinationType, Protos.Actions.GetAllActions.VaccinationType>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionSaleDto, Protos.Actions.GetAllActions.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.MerchandizeItemDto, Protos.Actions.GetAllActions.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.PaymentDefinitionDto, Protos.Actions.GetAllActions.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionSaleItemDto, Protos.Actions.GetAllActions.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.LatLngDto, Google.Type.LatLng>()
            .Map(d => d.Latitude, s => s.GpsLatitude)
            .Map(d => d.Longitude, s => s.GpsLongitude);
        
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.GetSelectedActionsRequest, GetSelectedActionsRequest>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse, Protos.Actions.GetSelectedActions.GetSelectedActionsResponse>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.ActionDto, Protos.Actions.GetSelectedActions.Action>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.ActionType, Protos.Actions.GetSelectedActions.ActionType>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.RacerDto, Protos.Actions.GetSelectedActions.RacerDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.NoteDto, Protos.Actions.GetSelectedActions.NoteDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.PaymentDto, Protos.Actions.GetSelectedActions.PaymentDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.RequestedPaymentItem, Protos.Actions.GetSelectedActions.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.RequestedPaymentsDto, Protos.Actions.GetSelectedActions.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.AddressDto, Protos.Actions.GetSelectedActions.AddressDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.CategoryDto, Protos.Actions.GetSelectedActions.CategoryDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.DogDto, Protos.Actions.GetSelectedActions.DogDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.LimitsDto, Protos.Actions.GetSelectedActions.LimitsDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.RaceDto, Protos.Actions.GetSelectedActions.RaceDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.RaceState, Protos.Actions.GetSelectedActions.RaceState>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.TermDto, Protos.Actions.GetSelectedActions.TermDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.VaccinationDto, Protos.Actions.GetSelectedActions.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.VaccinationType, Protos.Actions.GetSelectedActions.VaccinationType>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.ActionSaleDto, Protos.Actions.GetSelectedActions.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.MerchandizeItemDto, Protos.Actions.GetSelectedActions.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.PaymentDefinitionDto, Protos.Actions.GetSelectedActions.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.ActionSaleItemDto, Protos.Actions.GetSelectedActions.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.LatLngDto, Google.Type.LatLng>()
            .Map(d => d.Latitude, s => s.GpsLatitude)
            .Map(d => d.Longitude, s => s.GpsLongitude);

        typeAdapterConfig.NewConfig<RepeatedField<Protos.Shared.ActionRights>, IReadOnlyList<ActionRightsDto>>();

        typeAdapterConfig.NewConfig<Protos.Shared.ActionRights, ActionRightsDto>();

        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.CreateActionRequest, CreateActionRequest>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.ActionType, CreateActionRequest.ActionType>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.RacerDto, CreateActionRequest.RacerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.NoteDto, CreateActionRequest.NoteDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.PaymentDto, CreateActionRequest.PaymentDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.RequestedPaymentItem, CreateActionRequest.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.RequestedPaymentsDto, CreateActionRequest.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.AddressDto, CreateActionRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.CategoryDto, CreateActionRequest.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.DogDto, CreateActionRequest.DogDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.LimitsDto, CreateActionRequest.LimitsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.RaceDto, CreateActionRequest.RaceDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.RaceState, CreateActionRequest.RaceState>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.TermDto, CreateActionRequest.TermDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.VaccinationDto, CreateActionRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.VaccinationType, CreateActionRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.ActionSaleDto, CreateActionRequest.ActionSaleDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.MerchandizeItemDto, CreateActionRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.PaymentDefinitionDto, CreateActionRequest.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.ActionSaleItemDto, CreateActionRequest.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, CreateActionRequest.LatLngDto>()
            .Map(d => d.GpsLatitude, s => s.Latitude)
            .Map(d => d.GpsLongitude, s => s.Longitude);

        typeAdapterConfig.NewConfig<CreateActionResponse, Protos.Actions.CreateAction.CreateActionResponse>()
            .MapWith(s => new Protos.Actions.CreateAction.CreateActionResponse
            {
                Id = s.Id
            });

        typeAdapterConfig.NewConfig<GetActionEntrySettingsResponse, Protos.Actions.GetActionEntrySettings.GetActionEntrySettingsResponse>();
        typeAdapterConfig.NewConfig<GetActionEntrySettingsResponse.ActionType, Protos.Actions.GetActionEntrySettings.ActionType>();
        typeAdapterConfig.NewConfig<GetActionEntrySettingsResponse.RaceDto, Protos.Actions.GetActionEntrySettings.RaceDto>();
        typeAdapterConfig.NewConfig<GetActionEntrySettingsResponse.CategoryDto, Protos.Actions.GetActionEntrySettings.CategoryDto>();
        typeAdapterConfig.NewConfig<GetActionEntrySettingsResponse.RaceLimits, Protos.Actions.GetActionEntrySettings.RaceLimitsDto>();
        
        typeAdapterConfig.NewConfig<Protos.Actions.GetRacesForAction.GetRacesForActionRequest, GetRacesForActionRequest>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse, Protos.Actions.GetRacesForAction.GetRacesForActionResponse>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.RacerDto, Protos.Actions.GetRacesForAction.RacerDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.NoteDto, Protos.Actions.GetRacesForAction.NoteDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.PaymentDto, Protos.Actions.GetRacesForAction.PaymentDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.RequestedPaymentItem, Protos.Actions.GetRacesForAction.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.RequestedPaymentsDto, Protos.Actions.GetRacesForAction.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.AddressDto, Protos.Actions.GetRacesForAction.AddressDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.CategoryDto, Protos.Actions.GetRacesForAction.CategoryDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.DogDto, Protos.Actions.GetRacesForAction.DogDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.LimitsDto, Protos.Actions.GetRacesForAction.LimitsDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.RaceDto, Protos.Actions.GetRacesForAction.RaceDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.RaceState, Protos.Actions.GetRacesForAction.RaceState>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.TermDto, Protos.Actions.GetRacesForAction.TermDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.VaccinationDto, Protos.Actions.GetRacesForAction.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.VaccinationType, Protos.Actions.GetRacesForAction.VaccinationType>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.ActionSaleDto, Protos.Actions.GetRacesForAction.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.MerchandizeItemDto, Protos.Actions.GetRacesForAction.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.PaymentDefinitionDto, Protos.Actions.GetRacesForAction.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.ActionSaleItemDto, Protos.Actions.GetRacesForAction.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.LatLngDto, Google.Type.LatLng>()
            .Map(d => d.Latitude, s => s.GpsLatitude)
            .Map(d => d.Longitude, s => s.GpsLongitude);

        return typeAdapterConfig;
    }
}