namespace Storage.Migrations._2024;

internal class _20240613_DTKrajemBridlice : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("044db04d-1200-4c3e-9100-f7d3cb7e7137");

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
            Name = "DT Krajem břidlice",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Šternberk"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 6, 13, 17, 0, 0),
                To = new DateTime(2024, 6, 16, 13, 0, 0)
            }
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
