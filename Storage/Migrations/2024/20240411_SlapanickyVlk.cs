using System.Threading;

namespace Storage.Migrations._2024;

internal class _20240411_SlapanickyVlk : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("e67c4971-1185-4e40-864f-fc3f876c84fd");
    protected override string Name { get; init; } = nameof(_20240411_SlapanickyVlk);

    public _20240411_SlapanickyVlk(IServiceProvider serviceProvider) : base(serviceProvider) 
    {
        AddUpAction(ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Id,
            Name = "Šlapanický vlk",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Šlapanice"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 4, 11, 17, 0, 0),
                To = new DateTime(2024, 4, 14, 13, 0, 0)
            }
        }, CancellationToken.None));

        AddDownAction(ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
