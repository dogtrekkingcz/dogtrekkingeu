namespace Storage.Migrations._2024;

internal class _20241017_DogtrekkingBileKarpaty : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("18558dc3-d06b-4bcf-afe4-c2284152b3da");
    protected override string Name { get; init; } = nameof(_20241017_DogtrekkingBileKarpaty);

    public _20241017_DogtrekkingBileKarpaty(IServiceProvider serviceProvider) : base(serviceProvider) 
    { 
        this
            .AddUpAction(ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
            {
                Id = Id,
                Name = "Dogtrekking Bílé Karpaty",
                Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                {
                    City = "Bílé Karpaty"
                },
                Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
                {
                    From = new DateTime(2024, 10, 17, 17, 0, 0),
                    To = new DateTime(2024, 10, 20, 13, 0, 0)
                }
            }, CancellationToken.None))

            .AddDownAction(ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
