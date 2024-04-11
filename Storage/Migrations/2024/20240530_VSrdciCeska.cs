namespace Storage.Migrations._2024;

internal class _20240530_VSrdciCeska : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("f6a9149b-c0e3-4cd9-8422-59f0c4192f13");
    protected override string Name { get; init; } = nameof(_20240530_VSrdciCeska);

    public _20240530_VSrdciCeska(IServiceProvider serviceProvider) : base(serviceProvider) 
    { 
        AddUpAction(ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Id,
            Name = "V srdci Česka",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Kemp MOŘE, rybník ŘEKA, Krucemburk"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 5, 30, 17, 0, 0),
                To = new DateTime(2024, 6, 2, 13, 0, 0)
            }
        }, CancellationToken.None));

        AddDownAction(ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
