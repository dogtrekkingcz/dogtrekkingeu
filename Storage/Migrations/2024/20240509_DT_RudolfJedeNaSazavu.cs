namespace Storage.Migrations._2024;

internal class _20240509_DT_RudolfJedeNaSazavu : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("8e57b433-557e-432a-bb05-21262b75e80e");

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
            Name = "DT Rudolf jede na Sázavu",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Kácov"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 5, 9, 17, 0, 0),
                To = new DateTime(2024, 5, 12, 13, 0, 0)
            }
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
