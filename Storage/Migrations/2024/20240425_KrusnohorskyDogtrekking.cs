using Constants;

namespace Storage.Migrations._2024;

internal class _20240425_KrusnohorskyDogtrekking : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("be8ac863-2f05-4753-8291-913082c27239");
    protected override string Name { get; init; } = nameof(_20240425_KrusnohorskyDogtrekking);

    public _20240425_KrusnohorskyDogtrekking(IServiceProvider serviceProvider) : base(serviceProvider) 
    { 
        this
            .AddUpAction(() => ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
            {
                Id = Id,
                Name = "Krušnohorský dogtrekking",
                TypeId = ActivityType.Dogtrekking,
                Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                {
                    City = "Kemp Stebnice, obec Lipová u Chebu"
                },
                Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
                {
                    From = new DateTime(2024, 4, 25, 17, 0, 0),
                    To = new DateTime(2024, 4, 28, 13, 0, 0)
                }
            }, CancellationToken.None))

            .AddDownAction(() => ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
