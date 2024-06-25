namespace Storage.Migrations._2024;

internal class _20240509_DT_RudolfJedeNaSazavu : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("8e57b433-557e-432a-bb05-21262b75e80e");
    protected override string Name { get; init; } = nameof(_20240509_DT_RudolfJedeNaSazavu);

    public _20240509_DT_RudolfJedeNaSazavu(IServiceProvider serviceProvider) : base(serviceProvider) 
    {
        this
            .AddUpAction(() => ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
            {
                Id = Id,
                Name = "DT Rudolf jede na Sázavu",
                TypeId = Constants.ActivityType.Dogtrekking,
                ResultsCanEdit = new List<Guid> { Constants.Roles.InternalAdministrator.GUID },
                CompetitorsCanEdit = new List<Guid> { Constants.Roles.InternalAdministrator.GUID },
                ActionCanEdit = new List<Guid> { Constants.Roles.InternalAdministrator.GUID },
                Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                {
                    City = "Kácov"
                },
                Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
                {
                    From = new DateTime(2024, 5, 9, 17, 0, 0),
                    To = new DateTime(2024, 5, 12, 13, 0, 0)
                }
            }, CancellationToken.None))

            .AddDownAction(() => ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
