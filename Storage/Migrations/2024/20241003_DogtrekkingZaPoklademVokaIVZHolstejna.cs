namespace Storage.Migrations._2024;

internal class _20241003_DogtrekkingZaPoklademVokaIVZHolstejna : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("b67b4ee1-0719-4b8b-8fbc-6ae64cc68a48");

    public _20241003_DogtrekkingZaPoklademVokaIVZHolstejna(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
            Name = "Dogtrekking za pokladem Voka IV. z Holštejna",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Moravský kras"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 10, 3, 17, 0, 0),
                To = new DateTime(2024, 10, 6, 13, 0, 0)
            }
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
