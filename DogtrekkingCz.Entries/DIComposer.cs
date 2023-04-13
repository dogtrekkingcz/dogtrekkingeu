using DogtrekkingCz.Entries.Interface.Services;
using DogtrekkingCzShared.Interceptors;
using DogtrekkingCzShared.JwtToken;
using DogtrekkingCzShared.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Storage;
using Storage.Options;

namespace DogtrekkingCz.Entries
{
    public static class DIComposer
    {
        public static IServiceCollection AddEntries(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
        {
            services
                .AddScoped<IJwtTokenService, JwtTokenService>()
                .AddScoped<JwtTokenInterceptor>()
                .AddStorage(new StorageOptions() { MongoDbConnectionString = options.MongoDbConnectionString }, typeAdapterConfig);

            services.AddScoped<IEntriesService, EntriesService>();

            return services;
        }
    }
}
