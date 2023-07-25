using DogsOnTrail.Interfaces.Actions.Entities.Actions;
using Mapster;
using Storage.Entities.Actions;
using Storage.Entities.Entries;

namespace DogsOnTrail.Actions.Services.ActionsManage;

internal static class ActionsServiceMapping
{
    public static TypeAdapterConfig AddActionsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse, GetAllActionsResponse>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.ActionType, GetAllActionsResponse.ActionType>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.ActionDto, GetAllActionsResponse.ActionDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.RacerDto, GetAllActionsResponse.RacerDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.NoteDto, GetAllActionsResponse.NoteDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.PaymentDto, GetAllActionsResponse.PaymentDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.RequestedPaymentItem, GetAllActionsResponse.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.RequestedPaymentsDto, GetAllActionsResponse.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.AddressDto, GetAllActionsResponse.AddressDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.CategoryDto, GetAllActionsResponse.CategoryDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.DogDto, GetAllActionsResponse.DogDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.LimitsDto, GetAllActionsResponse.LimitsDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.RaceDto, GetAllActionsResponse.RaceDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.RaceState, GetAllActionsResponse.RaceState>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.TermDto, GetAllActionsResponse.TermDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.VaccinationDto, GetAllActionsResponse.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.VaccinationType, GetAllActionsResponse.VaccinationType>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.ActionSaleDto, GetAllActionsResponse.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.LatLngDto, GetAllActionsResponse.LatLngDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.MerchandizeItemDto, GetAllActionsResponse.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.PaymentDefinitionDto, GetAllActionsResponse.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetAllActionsInternalStorageResponse.ActionSaleItemDto, GetAllActionsResponse.ActionSaleItemDto>();
        

        typeAdapterConfig.NewConfig<GetSelectedActionsRequest, GetSelectedActionsInternalStorageRequest>();
        
        
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse, GetSelectedActionsResponse>();
        typeAdapterConfig.NewConfig<GetSelectedActionsInternalStorageResponse.ActionType, GetSelectedActionsResponse.ActionType>();
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


        typeAdapterConfig.NewConfig<CreateActionRequest, CreateActionInternalStorageRequest>()
            .Ignore(d => d.Id)
            .Ignore(d => d.Created);
        typeAdapterConfig.NewConfig<CreateActionRequest.ActionType, CreateActionInternalStorageRequest.ActionType>();
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
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.ActionType, GetActionResponse.ActionType>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RacerDto, GetActionResponse.RacerDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.NoteDto, GetActionResponse.NoteDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.PaymentDto, GetActionResponse.PaymentDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RequestedPaymentItem, GetActionResponse.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RequestedPaymentsDto, GetActionResponse.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.AddressDto, GetActionResponse.AddressDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.CategoryDto, GetActionResponse.CategoryDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.DogDto, GetActionResponse.DogDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.LimitsDto, GetActionResponse.LimitsDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RaceDto, GetActionResponse.RaceDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RaceState, GetActionResponse.RaceState>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.TermDto, GetActionResponse.TermDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.VaccinationDto, GetActionResponse.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.VaccinationType, GetActionResponse.VaccinationType>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.ActionSaleDto, GetActionResponse.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.LatLngDto, GetActionResponse.LatLngDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.MerchandizeItemDto, GetActionResponse.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.PaymentDefinitionDto, GetActionResponse.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.ActionSaleItemDto, GetActionResponse.ActionSaleItemDto>();

        typeAdapterConfig.NewConfig<UpdateActionRequest, UpdateActionInternalStorageRequest>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.ActionType, UpdateActionInternalStorageRequest.ActionType>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.RacerDto, UpdateActionInternalStorageRequest.RacerDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.NoteDto, UpdateActionInternalStorageRequest.NoteDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.PaymentDto, UpdateActionInternalStorageRequest.PaymentDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.RequestedPaymentItem, UpdateActionInternalStorageRequest.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.RequestedPaymentsDto, UpdateActionInternalStorageRequest.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.AddressDto, UpdateActionInternalStorageRequest.AddressDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.CategoryDto, UpdateActionInternalStorageRequest.CategoryDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.DogDto, UpdateActionInternalStorageRequest.DogDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.LimitsDto, UpdateActionInternalStorageRequest.LimitsDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.RaceDto, UpdateActionInternalStorageRequest.RaceDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.RaceState, UpdateActionInternalStorageRequest.RaceState>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.TermDto, UpdateActionInternalStorageRequest.TermDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.VaccinationDto, UpdateActionInternalStorageRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.VaccinationType, UpdateActionInternalStorageRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.ActionSaleDto, UpdateActionInternalStorageRequest.ActionSaleDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.LatLngDto, UpdateActionInternalStorageRequest.LatLngDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.MerchandizeItemDto, UpdateActionInternalStorageRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.PaymentDefinitionDto, UpdateActionInternalStorageRequest.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<UpdateActionRequest.ActionSaleItemDto, UpdateActionInternalStorageRequest.ActionSaleItemDto>();

        typeAdapterConfig.NewConfig<UpdateActionInternalStorageResponse, UpdateActionResponse>();

        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse, UpdateActionInternalStorageRequest>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.ActionType, UpdateActionInternalStorageRequest.ActionType>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RacerDto, UpdateActionInternalStorageRequest.RacerDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.NoteDto, UpdateActionInternalStorageRequest.NoteDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.PaymentDto, UpdateActionInternalStorageRequest.PaymentDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RequestedPaymentItem, UpdateActionInternalStorageRequest.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RequestedPaymentsDto, UpdateActionInternalStorageRequest.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.AddressDto, UpdateActionInternalStorageRequest.AddressDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.CategoryDto, UpdateActionInternalStorageRequest.CategoryDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.DogDto, UpdateActionInternalStorageRequest.DogDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.LimitsDto, UpdateActionInternalStorageRequest.LimitsDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RaceDto, UpdateActionInternalStorageRequest.RaceDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RaceState, UpdateActionInternalStorageRequest.RaceState>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.TermDto, UpdateActionInternalStorageRequest.TermDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.VaccinationDto, UpdateActionInternalStorageRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.VaccinationType, UpdateActionInternalStorageRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.ActionSaleDto, UpdateActionInternalStorageRequest.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.LatLngDto, UpdateActionInternalStorageRequest.LatLngDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.MerchandizeItemDto, UpdateActionInternalStorageRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.PaymentDefinitionDto, UpdateActionInternalStorageRequest.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.ActionSaleItemDto, UpdateActionInternalStorageRequest.ActionSaleItemDto>();

        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse, UpdateActionInternalStorageRequest.RacerDto>()
            .Ignore(d => d.Start)
            .Ignore(d => d.Finish)
            .Ignore(d => d.Payed)
            .Ignore(d => d.Payments)
            .Ignore(d => d.RequestedPayments)
            .Ignore(d => d.State)
            .Map(d => d.FirstName, s => s.Name)
            .Map(d => d.LastName, s => s.Surname);
            
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.VaccinationType, UpdateActionInternalStorageRequest.VaccinationType>();
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.VaccinationDto, UpdateActionInternalStorageRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.DogDto, UpdateActionInternalStorageRequest.DogDto>()
            .Ignore(d => d.UserId)
            .Ignore(d => d.Kennel)
            .Ignore(d => d.Decease)
            .Ignore(d => d.UriToPhoto)
            .Ignore(d => d.Contact);
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.MerchandizeItemDto, UpdateActionInternalStorageRequest.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.AddressDto, UpdateActionInternalStorageRequest.AddressDto>();
        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse.LatLngDto, UpdateActionInternalStorageRequest.LatLngDto>();

        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse, GetRacesForActionResponse>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RacerDto, GetRacesForActionResponse.RacerDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.NoteDto, GetRacesForActionResponse.NoteDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.PaymentDto, GetRacesForActionResponse.PaymentDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RequestedPaymentItem, GetRacesForActionResponse.RequestedPaymentItem>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RequestedPaymentsDto, GetRacesForActionResponse.RequestedPaymentsDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.AddressDto, GetRacesForActionResponse.AddressDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.CategoryDto, GetRacesForActionResponse.CategoryDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.DogDto, GetRacesForActionResponse.DogDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.LimitsDto, GetRacesForActionResponse.LimitsDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RaceDto, GetRacesForActionResponse.RaceDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.RaceState, GetRacesForActionResponse.RaceState>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.TermDto, GetRacesForActionResponse.TermDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.VaccinationDto, GetRacesForActionResponse.VaccinationDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.VaccinationType, GetRacesForActionResponse.VaccinationType>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.ActionSaleDto, GetRacesForActionResponse.ActionSaleDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.LatLngDto, GetRacesForActionResponse.LatLngDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.MerchandizeItemDto, GetRacesForActionResponse.MerchandizeItemDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.PaymentDefinitionDto, GetRacesForActionResponse.PaymentDefinitionDto>();
        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse.ActionSaleItemDto, GetRacesForActionResponse.ActionSaleItemDto>();
        
        return typeAdapterConfig;
    }
}