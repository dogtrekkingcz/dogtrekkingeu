using DogsOnTrail.Interfaces.Actions.Entities.Actions;
using SharedCode.Extensions;
using Google.Protobuf.Collections;
using Mapster;
using SharedCode.Entities;

namespace DogsOnTrailGRPCService.Services.Actions;

internal static class ActionsServiceMapping
{
    internal static TypeAdapterConfig AddActionsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<UpdateActionResponse, Protos.Actions.UpdateAction.UpdateActionResponse>();

        typeAdapterConfig.NewConfig<Protos.Actions.DeleteActionRequest, DeleteActionRequest>();

        typeAdapterConfig.NewConfig<Protos.Actions.GetAction.GetActionRequest, GetActionRequest>();

        typeAdapterConfig.NewConfig<GetAllActionsResponse, RepeatedField<Protos.Shared.ActionSimple>>()
            .Map(d => d, s => s.Actions)
            .Ignore(d => d.Capacity);
        
        typeAdapterConfig.NewConfig<Protos.Actions.GetAllActions.GetAllActionsRequest, GetAllActionsRequest>();

        typeAdapterConfig.NewConfig<RepeatedField<Protos.Shared.ActionRights>, IReadOnlyList<ActionRightsDto>>();

        typeAdapterConfig.NewConfig<Protos.Shared.ActionRights, ActionRightsDto>();

        typeAdapterConfig.NewConfig<Protos.Actions.CreateAction.CreateActionRequest, CreateActionRequest>();
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
        typeAdapterConfig.NewConfig<GetActionEntrySettingsResponse.RaceDto, Protos.Actions.GetActionEntrySettings.RaceDto>();
        typeAdapterConfig.NewConfig<GetActionEntrySettingsResponse.CategoryDto, Protos.Actions.GetActionEntrySettings.CategoryDto>();
        typeAdapterConfig.NewConfig<GetActionEntrySettingsResponse.RaceLimits, Protos.Actions.GetActionEntrySettings.RaceLimitsDto>();

        return typeAdapterConfig;
    }
}