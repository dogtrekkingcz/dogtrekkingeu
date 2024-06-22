namespace Storage.Migrations._2024;

internal class _20240919_DTKostalov : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("9e7ade86-f39c-4383-8458-825a15e863ae");
    protected override string Name { get; init; } = nameof(_20240919_DTKostalov);

    public _20240919_DTKostalov(IServiceProvider serviceProvider) : base(serviceProvider) 
    { 
        this
            .AddUpAction(() => ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
            {
                Id = Id,
                Name = "DT Košťálov",
                TypeId = Constants.ActivityType.Dogtrekking,
                ResultsCanEdit = Constants.Roles.InternalAdministrator.GUID,
                CompetitorsCanEdit = Constants.Roles.InternalAdministrator.GUID,
                ActionCanEdit = Constants.Roles.InternalAdministrator.GUID,
                Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                {
                    City = "Košťálov"
                },
                Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
                {
                    From = new DateTime(2024, 9, 19, 17, 0, 0),
                    To = new DateTime(2024, 9, 22, 13, 0, 0)
                }
            }, CancellationToken.None))

            .AddDownAction(() => ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
