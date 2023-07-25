﻿using DogsOnTrail.Interfaces.Actions.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using SharedCode.Options;

namespace DogsOnTrail.Actions.Services.DogsManage;

internal static class DiComposerDogs
{
    public static IServiceCollection AddDogs(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        typeAdapterConfig.AddDogsMapping();
            
        services.AddScoped<IDogsService, DogsService>();

        return services;
    }
}