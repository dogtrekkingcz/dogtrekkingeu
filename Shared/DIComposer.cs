using DogtrekkingCzShared.Interceptors;
using DogtrekkingCzShared.Options;
using Google.Protobuf.Collections;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace DogtrekkingCzShared
{
    public static class DIComposerDogtrekkingCzShared
    {
        public static IServiceCollection AddDogtrekkingCzShared(this IServiceCollection services, out TypeAdapterConfig typeAdapterConfig, DogtrekkingCzOptions options)
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
                .AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
