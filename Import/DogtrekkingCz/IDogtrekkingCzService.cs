namespace Import.DogtrekkingCz;

public interface IDogtrekkingCzService
{
    Task RunImportAsync(IServiceProvider serviceProvider, string importUrl);
}