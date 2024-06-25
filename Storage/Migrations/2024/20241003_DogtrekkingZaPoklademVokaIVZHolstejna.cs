namespace Storage.Migrations._2024;

internal class _20241003_DogtrekkingZaPoklademVokaIVZHolstejna : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("b67b4ee1-0719-4b8b-8fbc-6ae64cc68a48");
    protected override string Name { get; init; } = nameof(_20241003_DogtrekkingZaPoklademVokaIVZHolstejna);

    public _20241003_DogtrekkingZaPoklademVokaIVZHolstejna(IServiceProvider serviceProvider) : base(serviceProvider) 
    {
        this
            .AddUpAction(() => ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
            {
                Id = Id,
                Name = "Dogtrekking za pokladem Voka IV. z Holštejna",
                TypeId = Constants.ActivityType.Dogtrekking,
                ResultsCanEdit = new List<Guid> { Constants.Roles.InternalAdministrator.GUID },
                CompetitorsCanEdit = new List<Guid> { Constants.Roles.InternalAdministrator.GUID },
                ActionCanEdit = new List<Guid> { Constants.Roles.InternalAdministrator.GUID },
                Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                {
                    City = "Moravský kras"
                },
                Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
                {
                    From = new DateTime(2024, 10, 3, 17, 0, 0),
                    To = new DateTime(2024, 10, 6, 13, 0, 0)
                }
            }, CancellationToken.None))

            .AddDownAction(() => ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
