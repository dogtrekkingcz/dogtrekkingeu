using SharedCode.Mapping;
using Google.Protobuf.Collections;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharedCode.Interceptors;
using SharedCode.JwtToken;
using SharedCode.Options;

namespace SharedCode
{
    public static class DIComposerDogsOnTrailShared
    {
        public static IServiceCollection AddDogsOnTrailShared(this IServiceCollection services, out TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
        {
            typeAdapterConfig = new TypeAdapterConfig
            {
                RequireDestinationMemberSource = true,
                RequireExplicitMapping = true,
                Default =
                {
                    Settings =
                    {
                        UseDestinationValues =
                        {
                            (member => member.SetterModifier == AccessModifier.None &&
                                       member.Type.IsGenericType &&
                                       member.Type.GetGenericTypeDefinition() == typeof(RepeatedField<>))
                        }
                    }
                }
            };

            services
                .AddSingleton(typeAdapterConfig)
                .AddScoped<IMapper, ServiceMapper>()
                .AddScoped<IJwtTokenService, JwtTokenService>()
                .AddScoped<JwtTokenInterceptor>()
                .AddLogging(config =>
                {
                    config.AddConsole();
                });

            typeAdapterConfig.AddSharedMapping();

            return services;
        }
    }
}
