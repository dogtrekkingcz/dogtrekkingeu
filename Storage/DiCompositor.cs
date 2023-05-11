using SharedCode.Mapping;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
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
using Storage.Services.Repositories.UserProfiles;

namespace Storage;

public static class DiCompositor
{
    public static async Task<IHost> ConfigureStorageAsync(this IHost host, CancellationToken cancellationToken)
    {
        var initializationService = host.Services.GetService<IInitializeService>();
        if (initializationService == null)
            throw new Exception($"When calling '{nameof(ConfigureStorageAsync)}' the '{nameof(IInitializeService)}' is not registered");

        await initializationService.InitializeAsync(cancellationToken);

        return host;
    } 
    
    public static IServiceCollection AddStorage(this IServiceCollection serviceProvider, StorageOptions options, TypeAdapterConfig typeAdapterConfig)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        serviceProvider
            .AddSingleton<IInitializeService>(new InitializeService(options))
            .AddScoped<StorageSeedEngine>()

            .AddSingleton<IStorageService<ActionRecord>, StorageService<ActionRecord>>()
            .AddScoped<IActionsRepositoryService, ActionsRepositoryService>()
            
            .AddSingleton<IStorageService<ActionRightsRecord>, StorageService<ActionRightsRecord>>()
            .AddScoped<IActionRightsRepositoryService, ActionRightsRepositoryService>()
            
            .AddSingleton<IStorageService<UserProfileRecord>, StorageService<UserProfileRecord>>()
            .AddScoped<IUserProfilesRepositoryService, UserProfilesRepositoryService>()
            
            .AddSingleton<IStorageService<DogRecord>, StorageService<DogRecord>>()
            .AddScoped<IDogsRepositoryService, DogsRepositoryService>()
            
            .AddSingleton<IStorageService<AuthorizationRoleRecord>, StorageService<AuthorizationRoleRecord>>()
            .AddScoped<IAuthorizationRolesRepositoryService, AuthorizationRolesRepositoryService>()
            
            .AddSingleton<IStorageService<EntryRecord>, StorageService<EntryRecord>>()
            .AddScoped<IEntriesRepositoryService, EntriesRepositoryService>();


        typeAdapterConfig
            .AddSharedMapping()
            .AddActionRepositoryMapping()
            .AddActionRightsRepositoryMapping()
            .AddUserProfilesRepositoryMapping()
            .AddEntriesRepositoryMapping()
            .AddDogsRepositoryMapping();

        BsonClassMap.RegisterClassMap<ActionRecord>();
        BsonClassMap.RegisterClassMap<UserProfileRecord>();
        BsonClassMap.RegisterClassMap<EntryRecord>();
        BsonClassMap.RegisterClassMap<ActionRightsRecord>();
        BsonClassMap.RegisterClassMap<AuthorizationRoleRecord>();
        BsonClassMap.RegisterClassMap<DogRecord>();

        var client = new MongoClient(options.MongoDbConnectionString);

        var db = client.GetDatabase("DogsOnTrailDb");

        var listOfCollections = db.ListCollectionNames().ToList();
        
        if (listOfCollections.Contains("Actions") == false)
        {
            db.CreateCollection("Actions");
        }
        if (listOfCollections.Contains("UserProfiles") == false)
        {
            db.CreateCollection("UserProfiles");
        }
        if (listOfCollections.Contains("Dogs") == false)
        {
            db.CreateCollection("Dogs");
        }
        if (listOfCollections.Contains("ActionRights") == false)
        {
            db.CreateCollection("ActionRights");
        }
        if (listOfCollections.Contains("AuthorizationRoles") == false)
        {
            db.CreateCollection("AuthorizationRoles");
        }
        if (listOfCollections.Contains("Entries") == false)
        {
            db.CreateCollection("Entries");
        }

        Console.WriteLine($"MongoDb.DogtrekkingEu.Collections with initialized collections: {db.ListCollectionNames()}");
        
        serviceProvider.AddSingleton<IMongoCollection<ActionRecord>>(db.GetCollection<ActionRecord>("Actions"));
        serviceProvider.AddSingleton<IMongoCollection<UserProfileRecord>>(db.GetCollection<UserProfileRecord>("UserProfiles"));
        serviceProvider.AddSingleton<IMongoCollection<DogRecord>>(db.GetCollection<DogRecord>("Dogs"));
        serviceProvider.AddSingleton<IMongoCollection<ActionRightsRecord>>(db.GetCollection<ActionRightsRecord>("ActionRights"));
        serviceProvider.AddSingleton<IMongoCollection<AuthorizationRoleRecord>>(db.GetCollection<AuthorizationRoleRecord>("AuthorizationRoles"));
        serviceProvider.AddSingleton<IMongoCollection<EntryRecord>>(db.GetCollection<EntryRecord>("Entries"));

        return serviceProvider;
    }   
}