namespace Storage.Migrations._2024;

internal class _20240905_FrystackyDogtrekking : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("c684c2f2-0676-4fd9-b34a-a2ae383fd90d");
    protected override string Name { get; init; } = nameof(_20240905_FrystackyDogtrekking);

    public _20240905_FrystackyDogtrekking(IServiceProvider serviceProvider) : base(serviceProvider) 
    { 
        AddUpAction(ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Id,
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
        }, CancellationToken.None));

        AddDownAction(ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
