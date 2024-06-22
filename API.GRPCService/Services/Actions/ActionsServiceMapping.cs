using PetsOnTrail.Interfaces.Actions.Entities.Actions;
using Google.Protobuf.Collections;
using Mapster;
using Amazon.Auth.AccessControlPolicy;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.GRPCService.Services.Actions;

internal static class ActionsServiceMapping
{
    internal static TypeAdapterConfig AddActionsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Actions.DeleteAction.DeleteActionRequest, DeleteActionRequest>();

        typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionDto, Protos.Actions.GetAllActions.Action>();
        
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.GetAllActionsRequest, GetAllActionsRequest>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse, Protos.Actions.GetAllActions.GetAllActionsResponse>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionDto, Protos.Actions.GetAllActions.Action>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RacerDto, Protos.Actions.GetAllActions.RacerDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.NoteDto, Protos.Actions.GetAllActions.NoteDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.PaymentDto, Protos.Actions.GetAllActions.PaymentDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RequestedPaymentItem, Protos.Actions.GetAllActions.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RequestedPaymentsDto, Protos.Actions.GetAllActions.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.AddressDto, Protos.Actions.GetAllActions.AddressDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.CategoryDto, Protos.Actions.GetAllActions.CategoryDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.PetDto, Protos.Actions.GetAllActions.PetDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.LimitsDto, Protos.Actions.GetAllActions.LimitsDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RaceDto, Protos.Actions.GetAllActions.RaceDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.RaceState, Protos.Actions.GetAllActions.RaceState>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.TermDto, Protos.Actions.GetAllActions.TermDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionSaleDto, Protos.Actions.GetAllActions.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.MerchandizeItemDto, Protos.Actions.GetAllActions.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.PaymentDefinitionDto, Protos.Actions.GetAllActions.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.ActionSaleItemDto, Protos.Actions.GetAllActions.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.PassedCheckpointDto, Protos.Actions.GetAllActions.PassedCheckpointDto>();
        typeAdapterConfig.NewConfig<GetAllActionsResponse.LatLngDto, Google.Type.LatLng>();
        
        
        typeAdapterConfig.NewConfig<Protos.Actions.GetSelectedActions.GetSelectedActionsRequest, GetSelectedActionsRequest>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse, Protos.Actions.GetSelectedActions.GetSelectedActionsResponse>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.ActionDto, Protos.Actions.GetSelectedActions.Action>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.RacerDto, Protos.Actions.GetSelectedActions.RacerDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.NoteDto, Protos.Actions.GetSelectedActions.NoteDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.PaymentDto, Protos.Actions.GetSelectedActions.PaymentDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.RequestedPaymentItem, Protos.Actions.GetSelectedActions.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.RequestedPaymentsDto, Protos.Actions.GetSelectedActions.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.AddressDto, Protos.Actions.GetSelectedActions.AddressDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.CategoryDto, Protos.Actions.GetSelectedActions.CategoryDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.PetDto, Protos.Actions.GetSelectedActions.PetDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.LimitsDto, Protos.Actions.GetSelectedActions.LimitsDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.CheckpointDto, Protos.Actions.GetSelectedActions.CheckpointDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.RaceDto, Protos.Actions.GetSelectedActions.RaceDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.RaceState, Protos.Actions.GetSelectedActions.RaceState>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.TermDto, Protos.Actions.GetSelectedActions.TermDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.ActionSaleDto, Protos.Actions.GetSelectedActions.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.MerchandizeItemDto, Protos.Actions.GetSelectedActions.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.PaymentDefinitionDto, Protos.Actions.GetSelectedActions.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.ActionSaleItemDto, Protos.Actions.GetSelectedActions.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.PassedCheckpointDto, Protos.Actions.GetSelectedActions.PassedCheckpointDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsResponse.LatLngDto, Google.Type.LatLng>();
        
        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.GetActionRequest, GetActionRequest>();
        typeAdapterConfig.NewConfig<GetActionResponse, Protos.Actions.GetAction.GetActionResponse>();
        typeAdapterConfig.NewConfig<GetActionResponse.RacerDto, Protos.Actions.GetAction.RacerDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.NoteDto, Protos.Actions.GetAction.NoteDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.PaymentDto, Protos.Actions.GetAction.PaymentDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.RequestedPaymentItem, Protos.Actions.GetAction.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<GetActionResponse.RequestedPaymentsDto, Protos.Actions.GetAction.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.AddressDto, Protos.Actions.GetAction.AddressDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.CategoryDto, Protos.Actions.GetAction.CategoryDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.PetDto, Protos.Actions.GetAction.PetDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.LimitsDto, Protos.Actions.GetAction.LimitsDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.CheckpointDto, Protos.Actions.GetAction.CheckpointDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.RaceDto, Protos.Actions.GetAction.RaceDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.RaceState, Protos.Actions.GetAction.RaceState>();
        typeAdapterConfig.NewConfig<GetActionResponse.TermDto, Protos.Actions.GetAction.TermDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.ActionSaleDto, Protos.Actions.GetAction.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.MerchandizeItemDto, Protos.Actions.GetAction.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.PaymentDefinitionDto, Protos.Actions.GetAction.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.ActionSaleItemDto, Protos.Actions.GetAction.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.PassedCheckpointDto, Protos.Actions.GetAction.PassedCheckpointDto>();
        typeAdapterConfig.NewConfig<GetActionResponse.LatLngDto, Google.Type.LatLng>();

        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.CreateActionRequest, CreateActionRequest>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.RacerDto, CreateActionRequest.RacerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.NoteDto, CreateActionRequest.NoteDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.PaymentDto, CreateActionRequest.PaymentDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.RequestedPaymentItem, CreateActionRequest.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.RequestedPaymentsDto, CreateActionRequest.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.AddressDto, CreateActionRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.CategoryDto, CreateActionRequest.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.PetDto, CreateActionRequest.PetDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.LimitsDto, CreateActionRequest.LimitsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.CheckpointDto, CreateActionRequest.CheckpointDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.RaceDto, CreateActionRequest.RaceDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.RaceState, CreateActionRequest.RaceState>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.TermDto, CreateActionRequest.TermDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.ActionSaleDto, CreateActionRequest.ActionSaleDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.MerchandizeItemDto, CreateActionRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.PaymentDefinitionDto, CreateActionRequest.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.ActionSaleItemDto, CreateActionRequest.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.PassedCheckpointDto, CreateActionRequest.PassedCheckpointDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, CreateActionRequest.LatLngDto>();
        typeAdapterConfig.NewConfig<CreateActionResponse, Protos.Actions.CreateAction.CreateActionResponse>();


        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.UpdateActionRequest, UpdateActionRequest>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.RacerDto, UpdateActionRequest.RacerDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.NoteDto, UpdateActionRequest.NoteDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.PaymentDto, UpdateActionRequest.PaymentDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.RequestedPaymentItem, UpdateActionRequest.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.RequestedPaymentsDto, UpdateActionRequest.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.AddressDto, UpdateActionRequest.AddressDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.CategoryDto, UpdateActionRequest.CategoryDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.PetDto, UpdateActionRequest.PetDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.LimitsDto, UpdateActionRequest.LimitsDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.CheckpointDto, UpdateActionRequest.CheckpointDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.RaceDto, UpdateActionRequest.RaceDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.RaceState, UpdateActionRequest.RaceState>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.TermDto, UpdateActionRequest.TermDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.ActionSaleDto, UpdateActionRequest.ActionSaleDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.MerchandizeItemDto, UpdateActionRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.PaymentDefinitionDto, UpdateActionRequest.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.ActionSaleItemDto, UpdateActionRequest.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<Protos.Actions.UpdateAction.PassedCheckpointDto, UpdateActionRequest.PassedCheckpointDto>();
        typeAdapterConfig.NewConfig<Google.Type.LatLng, UpdateActionRequest.LatLngDto>();
        typeAdapterConfig.NewConfig<UpdateActionResponse, Protos.Actions.UpdateAction.UpdateActionResponse>();
        

        typeAdapterConfig.NewConfig<GetActionEntrySettingsResponse, Protos.Actions.GetActionEntrySettings.GetActionEntrySettingsResponse>();
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
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.PetDto, Protos.Actions.GetRacesForAction.PetDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.LimitsDto, Protos.Actions.GetRacesForAction.LimitsDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.RaceDto, Protos.Actions.GetRacesForAction.RaceDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.RaceState, Protos.Actions.GetRacesForAction.RaceState>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.TermDto, Protos.Actions.GetRacesForAction.TermDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.ActionSaleDto, Protos.Actions.GetRacesForAction.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.MerchandizeItemDto, Protos.Actions.GetRacesForAction.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.PaymentDefinitionDto, Protos.Actions.GetRacesForAction.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.ActionSaleItemDto, Protos.Actions.GetRacesForAction.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<GetRacesForActionResponse.LatLngDto, Google.Type.LatLng>();
        
        typeAdapterConfig.NewConfig<GetResultsForActionResponse, Protos.Actions.GetResultsForAction.GetResultsForActionResponse>();
        typeAdapterConfig.NewConfig<GetResultsForActionResponse.RaceResultsDto, Protos.Actions.GetResultsForAction.RaceResultsDto>();
        typeAdapterConfig.NewConfig<GetResultsForActionResponse.RaceState, Protos.Actions.GetResultsForAction.RaceState>();
        typeAdapterConfig.NewConfig<GetResultsForActionResponse.PassedCheckpointDto, Protos.Actions.GetResultsForAction.PassedCheckpointDto>();
        typeAdapterConfig.NewConfig<GetResultsForActionResponse.LatLngDto, Google.Type.LatLng>()
            .Map(d => d.Longitude, s => s.Longitude)
            .Map(d => d.Latitude, s => s.Latitude);
        typeAdapterConfig.NewConfig<GetResultsForActionResponse.CategoryResultsDto, Protos.Actions.GetResultsForAction.CategoryResultsDto>();
        typeAdapterConfig.NewConfig<GetResultsForActionResponse.PetDto, Protos.Actions.GetResultsForAction.PetDto>();
        typeAdapterConfig.NewConfig<GetResultsForActionResponse.RacerResultDto, Protos.Actions.GetResultsForAction.RacerResultsDto>();

        typeAdapterConfig.NewConfig<Protos.Actions.AcceptCheckpoint.AcceptCheckpointRequest, AcceptCheckpointRequest>();
        
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse, Protos.Actions.GetPublicActionsList.GetPublicActionsListResponse>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.ActionDto, Protos.Actions.GetPublicActionsList.ActionDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.RacerDto, Protos.Actions.GetPublicActionsList.RacerDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.AddressDto, Protos.Actions.GetPublicActionsList.AddressDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.CategoryDto, Protos.Actions.GetPublicActionsList.CategoryDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.PetDto, Protos.Actions.GetPublicActionsList.PetDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.LimitsDto, Protos.Actions.GetPublicActionsList.LimitsDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.RaceDto, Protos.Actions.GetPublicActionsList.RaceDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.RaceState, Protos.Actions.GetPublicActionsList.RaceState>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.TermDto, Protos.Actions.GetPublicActionsList.TermDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.ActionSaleDto, Protos.Actions.GetPublicActionsList.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.PaymentDefinitionDto, Protos.Actions.GetPublicActionsList.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.ActionSaleItemDto, Protos.Actions.GetPublicActionsList.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.PassedCheckpointDto, Protos.Actions.GetPublicActionsList.PassedCheckpointDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.CheckpointDto, Protos.Actions.GetPublicActionsList.CheckpointDto>();
        typeAdapterConfig.NewConfig<GetPublicActionsListResponse.LatLngDto, Google.Type.LatLng>();
        
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse, Protos.Actions.GetSelectedPublicActionsList.GetSelectedPublicActionsListResponse>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.ActionDto, Protos.Actions.GetSelectedPublicActionsList.ActionDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.RacerDto, Protos.Actions.GetSelectedPublicActionsList.RacerDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.AddressDto, Protos.Actions.GetSelectedPublicActionsList.AddressDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.CategoryDto, Protos.Actions.GetSelectedPublicActionsList.CategoryDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.PetDto, Protos.Actions.GetSelectedPublicActionsList.PetDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.LimitsDto, Protos.Actions.GetSelectedPublicActionsList.LimitsDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.RaceDto, Protos.Actions.GetSelectedPublicActionsList.RaceDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.RaceState, Protos.Actions.GetSelectedPublicActionsList.RaceState>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.TermDto, Protos.Actions.GetSelectedPublicActionsList.TermDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.ActionSaleDto, Protos.Actions.GetSelectedPublicActionsList.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.PaymentDefinitionDto, Protos.Actions.GetSelectedPublicActionsList.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.ActionSaleItemDto, Protos.Actions.GetSelectedPublicActionsList.ActionSaleItemDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.PassedCheckpointDto, Protos.Actions.GetSelectedPublicActionsList.PassedCheckpointDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.CheckpointDto, Protos.Actions.GetSelectedPublicActionsList.CheckpointDto>();
        typeAdapterConfig.NewConfig<GetSelectedPublicActionsListResponse.LatLngDto, Google.Type.LatLng>();

        typeAdapterConfig.NewConfig<GetSimpleActionsListByTypeResponse, Protos.Actions.GetSimpleActionsList.GetSimpleActionsListResponse>();
        typeAdapterConfig.NewConfig<GetSimpleActionsListByTypeResponse.RaceDto, Protos.Actions.GetSimpleActionsList.RaceDto>();
        typeAdapterConfig.NewConfig<GetSimpleActionsListByTypeResponse.ActionDto, Protos.Actions.GetSimpleActionsList.SimpleActionDto>();


        return typeAdapterConfig;
    }
}