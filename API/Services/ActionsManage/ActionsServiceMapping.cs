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

        typeAdapterConfig.NewConfig<CreateActionRequest, CreateActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<CreateActionInternalStorageResponse, CreateActionResponse>();

        typeAdapterConfig.NewConfig<DeleteActionRequest, DeleteActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<GetActionEntrySettingsRequest, GetActionInternalStorageRequest>()
            .Map(d => d.Id, s => s.ActionId);

        typeAdapterConfig.NewConfig<GetActionRequest, GetActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse, GetActionResponse>();

        typeAdapterConfig.NewConfig<UpdateActionRequest, UpdateActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<UpdateActionInternalStorageResponse, UpdateActionResponse>();

        typeAdapterConfig.NewConfig<GetActionInternalStorageResponse, UpdateActionInternalStorageRequest>();

        typeAdapterConfig.NewConfig<GetEntryInternalStorageResponse, RacerDto>()
            .Ignore(d => d.Start)
            .Ignore(d => d.Finish)
            .Ignore(d => d.Accepted)
            .Ignore(d => d.Payed)
            .Ignore(d => d.Payments)
            .Ignore(d => d.State)
            .Ignore(d => d.RequestedPayments)
            .Map(d => d.FirstName, s => s.Name)
            .Map(d => d.LastName, s => s.Surname);

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