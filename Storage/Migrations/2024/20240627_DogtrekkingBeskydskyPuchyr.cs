namespace Storage.Migrations._2024;

internal class _20240627_DogtrekkingBeskydskyPuchyr : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("2d87002d-611e-4130-99d9-564b7d4d6fb5");

    public _20240627_DogtrekkingBeskydskyPuchyr(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
            Name = "Dogtrekking Beskydský puchýř",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Palkovice"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 6, 27, 17, 0, 0),
                To = new DateTime(2024, 6, 30, 13, 0, 0)
            }
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
