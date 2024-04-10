﻿namespace Storage.Migrations._2024;

internal class _20241017_DogtrekkingBileKarpaty : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("18558dc3-d06b-4bcf-afe4-c2284152b3da");

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
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
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
