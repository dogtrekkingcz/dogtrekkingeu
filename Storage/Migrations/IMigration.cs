namespace Storage.Migrations;

internal interface IMigration
{
    public Task RunAsync(CancellationToken cancellationToken);
}