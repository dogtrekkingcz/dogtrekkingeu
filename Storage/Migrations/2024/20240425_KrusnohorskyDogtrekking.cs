namespace Storage.Migrations._2024;

internal class _20240425_KrusnohorskyDogtrekking : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("be8ac863-2f05-4753-8291-913082c27239");

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
            Name = "Krušnohorský dogtrekking",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Kemp Stebnice, obec Lipová u Chebu"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 4, 25, 17, 0, 0),
                To = new DateTime(2024, 4, 28, 13, 0, 0)
            }
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
