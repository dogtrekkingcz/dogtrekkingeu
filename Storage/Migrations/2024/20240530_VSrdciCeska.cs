namespace Storage.Migrations._2024;

internal class _20240530_VSrdciCeska : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("f6a9149b-c0e3-4cd9-8422-59f0c4192f13");

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
            Name = "V srdci Česka",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Kemp MOŘE, rybník ŘEKA, Krucemburk"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 5, 30, 17, 0, 0),
                To = new DateTime(2024, 6, 2, 13, 0, 0)
            }
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
