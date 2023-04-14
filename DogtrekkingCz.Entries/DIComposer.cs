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
            services
                .AddScoped<IJwtTokenService, JwtTokenService>()
                .AddScoped<JwtTokenInterceptor>();

            services.AddScoped<IEntriesService, EntriesService>();

            typeAdapterConfig.NewConfig<GetEntriesByActionInternalStorageResponse, GetEntriesByActionResponse>();
            typeAdapterConfig.NewConfig<GetEntriesByActionRequest, GetEntriesByActionInternalStorageRequest>();

            typeAdapterConfig.NewConfig<CreateEntryRequest, CreateEntryInternalStorageRequest>();
            typeAdapterConfig.NewConfig<CreateEntryInternalStorageResponse, CreateEntryResponse>();

            typeAdapterConfig.NewConfig<GetAllEntriesRequest, GetAllEntriesInternalStorageRequest>();
            typeAdapterConfig.NewConfig<GetAllEntriesInternalStorageResponse, GetAllEntriesResponse>();

            return services;
        }
    }
}
