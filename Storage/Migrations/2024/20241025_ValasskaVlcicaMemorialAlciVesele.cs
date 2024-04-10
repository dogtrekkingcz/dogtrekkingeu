namespace Storage.Migrations._2024;

internal class _20241025_ValasskaVlcicaMemorialAlciVesele : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("49d22684-7bab-4f05-943b-eba59551c2b2");

    public _20241025_ValasskaVlcicaMemorialAlciVesele(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
            Name = "Valašská Vlčica - Memoriál Alči Veselé",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Chřiby"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 10, 25, 17, 0, 0),
                To = new DateTime(2024, 10, 28, 13, 0, 0)
            }
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
