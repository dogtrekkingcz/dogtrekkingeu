namespace Storage.Migrations._2024;

internal class _20241025_ValasskaVlcicaMemorialAlciVesele : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("49d22684-7bab-4f05-943b-eba59551c2b2");
    protected override string Name { get; init; } = nameof(_20241025_ValasskaVlcicaMemorialAlciVesele);

    public _20241025_ValasskaVlcicaMemorialAlciVesele(IServiceProvider serviceProvider) : base(serviceProvider) 
    { 
        this
            .AddUpAction(() => ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
            {
                Id = Id,
                Name = "Valašská Vlčica - Memoriál Alči Veselé",
                Type = Constants.ActivityType.Dogtrekking,
                Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                {
                    City = "Chřiby"
                },
                Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
                {
                    From = new DateTime(2024, 10, 25, 17, 0, 0),
                    To = new DateTime(2024, 10, 28, 13, 0, 0)
                }
            }, CancellationToken.None))

            .AddDownAction(() => ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
