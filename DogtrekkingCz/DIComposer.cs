using DogtrekkingCz.Interfaces.Services;
using DogtrekkingCz.Storage;
using DogtrekkingCzShared.Interceptors;
using DogtrekkingCzShared.Options;
using DogtrekkingCzShared.Services.JwtToken;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Storage.Interfaces.Options;

namespace DogtrekkingCz
{
    public static class DIComposer
    {
        public static IServiceCollection AddDogtrekkingCz(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
        {
            services
                .AddScoped<IJwtTokenService, JwtTokenService>()
                .AddScoped<JwtTokenInterceptor>()
                .AddStorage(new StorageOptions() { MongoDbConnectionString = options.MongoDbConnectionString }, typeAdapterConfig);

            services.AddScoped<IActionsService, ActionsService>();

            return services;
        }
    }
}
