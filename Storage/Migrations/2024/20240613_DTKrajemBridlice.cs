namespace Storage.Migrations._2024;

internal class _20240613_DTKrajemBridlice : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("044db04d-1200-4c3e-9100-f7d3cb7e7137");
    protected override string Name { get; init; } = nameof(_20240613_DTKrajemBridlice);

    public _20240613_DTKrajemBridlice(IServiceProvider serviceProvider) : base(serviceProvider) 
    { 
        AddUpAction(ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Id,
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
        }, CancellationToken.None));

        AddDownAction(ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
