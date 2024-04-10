using Storage.Migrations._2024;

namespace Storage.Migrations;

internal class M_20240410_LoadActionsForYear2024 : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("9558cd8f-d871-4ccb-a72e-75e1fb9f0235");

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        if (MigrationsRepositoryService.GetAsync(_guid.ToString(), cancellationToken) != null)
        {
            return;
        }

        await new _20240328_ZdeJsouLvi().UpAsync(cancellationToken);
        
        await new _20240411_SlapanickyVlk().UpAsync(cancellationToken);

        await new _20240425_KrusnohorskyDogtrekking().UpAsync(cancellationToken);

        await new _20240509_DT_RudolfJedeNaSazavu().UpAsync(cancellationToken);

        await new _20240530_VSrdciCeska().UpAsync(cancellationToken);

        await new _20240613_DTKrajemBridlice().UpAsync(cancellationToken);

        await new _20240627_DogtrekkingBeskydskyPuchyr().UpAsync(cancellationToken);

        await new _20240712_StopouStrejdySeraka().UpAsync(cancellationToken);

        await new _20240905_FrystackyDogtrekking().UpAsync(cancellationToken);

        await new _20240919_DTKostalov().UpAsync(cancellationToken);

        await new _20241003_DogtrekkingZaPoklademVokaIVZHolstejna().UpAsync(cancellationToken);

        await new _20241025_ValasskaVlcicaMemorialAlciVesele().UpAsync(cancellationToken);

        await new _20241017_DogtrekkingBileKarpaty().UpAsync(cancellationToken);

        await MigrationsRepositoryService.CreateMigrationAsync(new Entities.Migrations.CreateMigrationInternalStorageRequest
        {
            Id = _guid.ToString(),
            Name = nameof(M_20240410_LoadActionsForYear2024),
            Created = DateTime.UtcNow
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        if (MigrationsRepositoryService.GetAsync(_guid.ToString(), cancellationToken) == null)
        {
            return;
        }

        await new _20240328_ZdeJsouLvi().DownAsync(cancellationToken);

        await new _20240411_SlapanickyVlk().DownAsync(cancellationToken);

        await new _20240425_KrusnohorskyDogtrekking().DownAsync(cancellationToken);

        await new _20240509_DT_RudolfJedeNaSazavu().DownAsync(cancellationToken);

        await new _20240530_VSrdciCeska().DownAsync(cancellationToken);

        await new _20240613_DTKrajemBridlice().DownAsync(cancellationToken);

        await new _20240627_DogtrekkingBeskydskyPuchyr().DownAsync(cancellationToken);

        await new _20240712_StopouStrejdySeraka().DownAsync(cancellationToken);

        await new _20240905_FrystackyDogtrekking().DownAsync(cancellationToken);

        await new _20240919_DTKostalov().DownAsync(cancellationToken);

        await new _20241003_DogtrekkingZaPoklademVokaIVZHolstejna().DownAsync(cancellationToken);

        await new _20241025_ValasskaVlcicaMemorialAlciVesele().DownAsync(cancellationToken);

        await new _20241017_DogtrekkingBileKarpaty().DownAsync(cancellationToken);

        await MigrationsRepositoryService.DeleteMigrationAsync(_guid.ToString(), cancellationToken);
    }
}