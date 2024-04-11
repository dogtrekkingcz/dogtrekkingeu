using Storage.Migrations._2024;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Storage.Migrations;

internal class M_20240410_LoadActionsForYear2024 : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("9558cd8f-d871-4ccb-a72e-75e1fb9f0235");
    protected override string Name { get; init; } = nameof(M_20240410_LoadActionsForYear2024);

    protected override List<Type> ActionsToMigrate { get; init; } = new List<Type>()
    {
        typeof(_20240328_ZdeJsouLvi),
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
}