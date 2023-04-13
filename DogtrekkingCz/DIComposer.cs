using DogtrekkingCz.Interfaces.Actions.Services;
using DogtrekkingCzShared.Interceptors;
using DogtrekkingCzShared.JwtToken;
using DogtrekkingCzShared.Options;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Storage;
using Storage.Options;

namespace DogtrekkingCz.Actions
{
    public static class DIComposer
    {
        public static IServiceCollection AddActions(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
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
