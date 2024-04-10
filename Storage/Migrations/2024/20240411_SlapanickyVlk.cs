namespace Storage.Migrations._2024;

internal class _20240411_SlapanickyVlk : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("e67c4971-1185-4e40-864f-fc3f876c84fd");

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
            Name = "Šlapanický vlk",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Šlapanice"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 4, 11, 17, 0, 0),
                To = new DateTime(2024, 4, 14, 13, 0, 0)
            }
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
