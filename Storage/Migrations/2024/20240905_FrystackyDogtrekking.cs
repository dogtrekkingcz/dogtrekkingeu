namespace Storage.Migrations._2024;

internal class _20240905_FrystackyDogtrekking : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("c684c2f2-0676-4fd9-b34a-a2ae383fd90d");

    public _20240905_FrystackyDogtrekking(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
            Name = "Fryštácký dogtrekking",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Ranč kemp Bystřička"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 9, 5, 17, 0, 0),
                To = new DateTime(2024, 9, 8, 13, 0, 0)
            }
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
