using Import.DogtrekkingCz;
using Storage.Seed;

namespace API.GRPCService.Extensions
{
    public static class SeedDataExtension
    {
        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder builder)
        {
            // var storageSeed = builder.ApplicationServices.GetService<StorageSeedEngine>();
            // if (storageSeed != null) 
            // {
            //     await storageSeed.SeedAsync();
            // }

            var importSeed = builder.ApplicationServices.GetService<IDogtrekkingCzService>();
            if (importSeed != null)
            {
                await importSeed.RunImportAsync(builder.ApplicationServices, "");
            }

            return builder;
        }
    }
}
