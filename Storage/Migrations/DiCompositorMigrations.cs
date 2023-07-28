using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;
using Storage.Options;
using Storage.Seed;
using Storage.Services;
using Storage.Services.Repositories.ActionRights;
using Storage.Services.Repositories.Actions;
using Storage.Services.Repositories.AuthorizationRoles;
using Storage.Services.Repositories.Dogs;
using Storage.Services.Repositories.Entries;
using Storage.Services.Repositories.Migrations;
using Storage.Services.Repositories.UserProfiles;

namespace Storage.Migrations;

public static class DiCompositor
{
    public static IServiceCollection AddMigrations(this IServiceCollection serviceProvider, TypeAdapterConfig typeAdapterConfig)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        return serviceProvider;
    }   
}