using Storage.Migrations._2024;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Storage.Migrations;

internal class M_20240410_LoadActionsForYear2024 : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("9558cd8f-d871-4ccb-a72e-75e1fb9f0235");

    private readonly List<Type> actions = new List<Type>()
    {
        typeof(_20240411_SlapanickyVlk),
        typeof(_20240425_KrusnohorskyDogtrekking),
        typeof(_20240509_DT_RudolfJedeNaSazavu),
        typeof(_20240530_VSrdciCeska),
        typeof(_20240613_DTKrajemBridlice),
        typeof(_20240627_DogtrekkingBeskydskyPuchyr),
        typeof(_20240712_StopouStrejdySeraka),
        typeof(_20240905_FrystackyDogtrekking),
        typeof(_20240919_DTKostalov),
        typeof(_20241003_DogtrekkingZaPoklademVokaIVZHolstejna),
        typeof(_20241025_ValasskaVlcicaMemorialAlciVesele),
        typeof(_20241017_DogtrekkingBileKarpaty)
    };


    public M_20240410_LoadActionsForYear2024(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("M_20240410_LoadActionsForYear2024 UP is running...");

        if (await MigrationsRepositoryService.GetAsync(_guid.ToString(), cancellationToken) is not null)
        {
            Console.WriteLine("M_20240410_LoadActionsForYear2024 UP is already done, the ID is exists");
            return;
        }

        try 
        { 
            await new _20240328_ZdeJsouLvi(ServiceProvider).UpAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[FAILED] Load _20240328_ZdeJsouLvi: '{ex}'");
        }


        await Task.WhenAll(actions.Select(action => (Activator.CreateInstance(action, ServiceProvider) as M_00_MigrationBase).UpAsync(cancellationToken)));


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

        if (await MigrationsRepositoryService.GetAsync(_guid.ToString(), cancellationToken) is null)
        {
            Console.WriteLine("M_20240410_LoadActionsForYear2024 DOWN is already done, the ID is not exists");
            return;
        }

        
        await Task.WhenAll(actions.Select(action => (Activator.CreateInstance(action, ServiceProvider) as M_00_MigrationBase).DownAsync(cancellationToken)));


        await MigrationsRepositoryService.DeleteMigrationAsync(_guid.ToString(), cancellationToken);

        Console.WriteLine("M_20240410_LoadActionsForYear2024 DOWN is finished...");
    }
}