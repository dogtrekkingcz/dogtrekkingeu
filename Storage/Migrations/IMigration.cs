namespace Storage.Migrations;

internal interface IMigration
{
    public Task UpAsync(CancellationToken cancellationToken);

    public Task DownAsync(CancellationToken cancellationToken);
}