using DogsOnTrail.Interfaces.Actions.Entities.Actions;
using Mapster;
using SharedCode.Entities;
using Storage.Entities.Actions;
using Storage.Entities.Entries;

namespace DogsOnTrail.Actions.Services.ActionsManage;

internal static class ActionsServiceMapping
{
    public static TypeAdapterConfig AddActionsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse, GetAllActionsResponse>();

        typeAdapterConfig.NewConfig<GetSelectedActionsRequest, GetSelectedActionsInternalStorageRequest>();
        
        
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse, GetSelectedActionsResponse>(); 
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.ActionDto, GetSelectedActionsResponse.ActionDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.RacerDto, GetSelectedActionsResponse.RacerDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.NoteDto, GetSelectedActionsResponse.NoteDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.PaymentDto, GetSelectedActionsResponse.PaymentDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.RequestedPaymentItem, GetSelectedActionsResponse.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.RequestedPaymentsDto, GetSelectedActionsResponse.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.AddressDto, GetSelectedActionsResponse.AddressDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.CategoryDto, GetSelectedActionsResponse.CategoryDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.DogDto, GetSelectedActionsResponse.DogDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.LimitsDto, GetSelectedActionsResponse.LimitsDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.RaceDto, GetSelectedActionsResponse.RaceDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.RaceState, GetSelectedActionsResponse.RaceState>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.TermDto, GetSelectedActionsResponse.TermDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.VaccinationDto, GetSelectedActionsResponse.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.VaccinationType, GetSelectedActionsResponse.VaccinationType>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.ActionSaleDto, GetSelectedActionsResponse.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.LatLngDto, GetSelectedActionsResponse.LatLngDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.MerchandizeItemDto, GetSelectedActionsResponse.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.PaymentDefinitionDto, GetSelectedActionsResponse.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.ActionSaleItemDto, GetSelectedActionsResponse.ActionSaleItemDto>();
        

        typeAdapterConfig.NewConfig<CreateActionRequest, CreateActionInternalStorageRequest>();
        typeAdapterConfig.NewConfig<CreateActionRequest.RacerDto, CreateActionInternalStorageRequest.RacerDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.NoteDto, CreateActionInternalStorageRequest.NoteDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.PaymentDto, CreateActionInternalStorageRequest.PaymentDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.RequestedPaymentItem, CreateActionInternalStorageRequest.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<CreateActionRequest.RequestedPaymentsDto, CreateActionInternalStorageRequest.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.AddressDto, CreateActionInternalStorageRequest.AddressDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.CategoryDto, CreateActionInternalStorageRequest.CategoryDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.DogDto, CreateActionInternalStorageRequest.DogDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.LimitsDto, CreateActionInternalStorageRequest.LimitsDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.RaceDto, CreateActionInternalStorageRequest.RaceDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.RaceState, CreateActionInternalStorageRequest.RaceState>();
        typeAdapterConfig.NewConfig<CreateActionRequest.TermDto, CreateActionInternalStorageRequest.TermDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.VaccinationDto, CreateActionInternalStorageRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.VaccinationType, CreateActionInternalStorageRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<CreateActionRequest.ActionSaleDto, CreateActionInternalStorageRequest.ActionSaleDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.LatLngDto, CreateActionInternalStorageRequest.LatLngDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.MerchandizeItemDto, CreateActionInternalStorageRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.PaymentDefinitionDto, CreateActionInternalStorageRequest.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<CreateActionRequest.ActionSaleItemDto, CreateActionInternalStorageRequest.ActionSaleItemDto>();
        

        typeAdapterConfig.NewConfig<CreateActionInternalStorageResponse, CreateActionResponse>();

        typeAdapterConfig.NewConfig<DeleteActionRequest, DeleteActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<GetActionEntrySettingsRequest, GetActionInternalStorageRequest>()
            .Map(d => d.Id, s => s.ActionId);

        typeAdapterConfig.NewConfig<GetActionRequest, GetActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse, GetActionResponse>();

        typeAdapterConfig.NewConfig<UpdateActionRequest, UpdateActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<UpdateActionInternalStorageResponse, UpdateActionResponse>();

        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse, UpdateActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.MerchandizeItemDto, MerchandizeItemDto>();

        typeAdapterConfig.NewConfig<EntryDto.DogDto, DogDto>()
            .Ignore(d => d.UserId)
            .Ignore(d => d.Kennel)
            .Ignore(d => d.Decease)
            .Ignore(d => d.UriToPhoto)
            .Ignore(d => d.Contact);

        return typeAdapterConfig;
    }
}