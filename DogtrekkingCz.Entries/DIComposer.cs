using DogtrekkingCz.Entries.Interface.Entities;
using DogtrekkingCz.Entries.Interface.Services;
using DogtrekkingCzShared.Entities;
using DogtrekkingCzShared.Interceptors;
using DogtrekkingCzShared.JwtToken;
using DogtrekkingCzShared.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Storage;
using Storage.Entities.Entries;
using Storage.Options;

namespace DogtrekkingCz.Entries
{
    public static class DIComposer
    {
        public static IServiceCollection AddEntries(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
        {
            services.AddScoped<IEntriesService, EntriesService>();



            return services;
        }
    }
}
