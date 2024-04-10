namespace Storage.Migrations._2024;

internal class _20240919_DTKostalov : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("9e7ade86-f39c-4383-8458-825a15e863ae");

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
            Name = "DT Košťálov",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Košťálov"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 9, 19, 17, 0, 0),
                To = new DateTime(2024, 9, 22, 13, 0, 0)
            }
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
