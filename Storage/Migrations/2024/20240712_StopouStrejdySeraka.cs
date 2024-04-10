namespace Storage.Migrations._2024;

internal class _20240712_StopouStrejdySeraka : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("854b2a95-7ee8-4b49-9da5-851928ce1822");

    public _20240712_StopouStrejdySeraka(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
            Name = "Stopou strejdy Šeráka",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Lipová lázně"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 7, 12, 17, 0, 0),
                To = new DateTime(2024, 7, 14, 13, 0, 0)
            }
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
