namespace Storage.Migrations._2024;

internal class _20240627_DogtrekkingBeskydskyPuchyr : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("2d87002d-611e-4130-99d9-564b7d4d6fb5");
    protected override string Name { get; init; } = nameof(_20240627_DogtrekkingBeskydskyPuchyr);


    public _20240627_DogtrekkingBeskydskyPuchyr(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this
            .AddUpAction(() => ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
            {
                Id = Id,
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
            }, CancellationToken.None))

            .AddDownAction(() => ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
