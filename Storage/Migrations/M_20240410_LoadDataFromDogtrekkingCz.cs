using Storage.Migrations._2024;

namespace Storage.Migrations;

internal class M_20240410_LoadActionsForYear2024 : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("9558cd8f-d871-4ccb-a72e-75e1fb9f0235");

    public M_20240410_LoadActionsForYear2024(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("M_20240410_LoadActionsForYear2024 UP is running...");

        try
        { 
            var thisMigration = await MigrationsRepositoryService.GetAsync(_guid.ToString(), cancellationToken);
            if (thisMigration is not null && (thisMigration.Id == _guid.ToString()))
            {
                Console.WriteLine("M_20240410_LoadActionsForYear2024 UP is already done, the ID is exists");
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[FAILED] Load _20240410_LoadActionsForYear2024.MigrationExists: '{ex}'");
        }

        try 
        { 
            await new _20240328_ZdeJsouLvi(ServiceProvider).UpAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[FAILED] Load _20240328_ZdeJsouLvi: '{ex}'");
        }


        await new _20240411_SlapanickyVlk(ServiceProvider).UpAsync(cancellationToken);

        await new _20240425_KrusnohorskyDogtrekking(ServiceProvider).UpAsync(cancellationToken);

        await new _20240509_DT_RudolfJedeNaSazavu(ServiceProvider).UpAsync(cancellationToken);

        await new _20240530_VSrdciCeska(ServiceProvider).UpAsync(cancellationToken);

        await new _20240613_DTKrajemBridlice(ServiceProvider).UpAsync(cancellationToken);

        await new _20240627_DogtrekkingBeskydskyPuchyr(ServiceProvider).UpAsync(cancellationToken);

        await new _20240712_StopouStrejdySeraka(ServiceProvider).UpAsync(cancellationToken);

        await new _20240905_FrystackyDogtrekking(ServiceProvider).UpAsync(cancellationToken);

        await new _20240919_DTKostalov(ServiceProvider).UpAsync(cancellationToken);

        await new _20241003_DogtrekkingZaPoklademVokaIVZHolstejna(ServiceProvider).UpAsync(cancellationToken);

        await new _20241025_ValasskaVlcicaMemorialAlciVesele(ServiceProvider).UpAsync(cancellationToken);

        await new _20241017_DogtrekkingBileKarpaty(ServiceProvider).UpAsync(cancellationToken);

        await MigrationsRepositoryService.CreateMigrationAsync(new Entities.Migrations.CreateMigrationInternalStorageRequest
        {
            Id = _guid.ToString(),
            Name = nameof(M_20240410_LoadActionsForYear2024),
            Created = DateTime.UtcNow
        }, cancellationToken);

        Console.WriteLine("M_20240410_LoadActionsForYear2024 UP is finished...");
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("M_20240410_LoadActionsForYear2024 DOWN is running...");

        if (await MigrationsRepositoryService.GetAsync(_guid.ToString(), cancellationToken) == null)
        {
            Console.WriteLine("M_20240410_LoadActionsForYear2024 DOWN is already done, the ID is not exists");
            return;
        }

        await new _20240328_ZdeJsouLvi(ServiceProvider).DownAsync(cancellationToken);

        await new _20240411_SlapanickyVlk(ServiceProvider).DownAsync(cancellationToken);

        await new _20240425_KrusnohorskyDogtrekking(ServiceProvider).DownAsync(cancellationToken);

        await new _20240509_DT_RudolfJedeNaSazavu(ServiceProvider).DownAsync(cancellationToken);

        await new _20240530_VSrdciCeska(ServiceProvider).DownAsync(cancellationToken);

        await new _20240613_DTKrajemBridlice(ServiceProvider).DownAsync(cancellationToken);

        await new _20240627_DogtrekkingBeskydskyPuchyr(ServiceProvider).DownAsync(cancellationToken);

        await new _20240712_StopouStrejdySeraka(ServiceProvider).DownAsync(cancellationToken);

        await new _20240905_FrystackyDogtrekking(ServiceProvider).DownAsync(cancellationToken);

        await new _20240919_DTKostalov(ServiceProvider).DownAsync(cancellationToken);

        await new _20241003_DogtrekkingZaPoklademVokaIVZHolstejna(ServiceProvider).DownAsync(cancellationToken);

        await new _20241025_ValasskaVlcicaMemorialAlciVesele(ServiceProvider).DownAsync(cancellationToken);

        await new _20241017_DogtrekkingBileKarpaty(ServiceProvider).DownAsync(cancellationToken);

        await MigrationsRepositoryService.DeleteMigrationAsync(_guid.ToString(), cancellationToken);

        Console.WriteLine("M_20240410_LoadActionsForYear2024 DOWN is finished...");
    }
}