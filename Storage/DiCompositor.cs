using DogtrekkingCz.Storage.Models;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Storage.Interfaces.Options;
using Storage.Interfaces.Services;
using Storage.Services;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Storage.Interfaces;
using Storage.Services.Repositories;
using MapsterMapper;
using Storage.Models;
using DogtrekkingCz.Shared.Mapping;

namespace DogtrekkingCz.Storage;

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
            .AddScoped<IMapper, ServiceMapper>()
            .AddSingleton<IInitializeService>(new InitializeService(options))

            .AddSingleton<IStorageService<ActionRecord>, StorageService<ActionRecord>>()
            .AddScoped<IActionsRepositoryService, ActionsRepositoryService>()

            .AddSingleton<IStorageService<UserProfileRecord>, StorageService<UserProfileRecord>>()
            .AddScoped<IUserProfilesRepositoryService, UserProfilesRepositoryService>()

            .AddSingleton<IStorageService<DogRecord>, StorageService<DogRecord>>()
            .AddScoped<IDogsRepositoryService, DogsRepositoryService>();


        typeAdapterConfig
            .AddSharedMapping()
            .AddActionRepositoryMapping()
            .AddUserProfilesRepositoryMapping();

        BsonClassMap.RegisterClassMap<ActionRecord>();
        BsonClassMap.RegisterClassMap<UserProfileRecord>();

        var client = new MongoClient(options.MongoDbConnectionString);

        var db = client.GetDatabase("DogtrekkingEu");

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

        Console.WriteLine($"MongoDb.DogtrekkingEu.Collections with initialized collections: {db.ListCollectionNames()}");
        
        serviceProvider.AddSingleton<IMongoCollection<ActionRecord>>(db.GetCollection<ActionRecord>("Actions"));
        serviceProvider.AddSingleton<IMongoCollection<UserProfileRecord>>(db.GetCollection<UserProfileRecord>("UserProfiles"));
        serviceProvider.AddSingleton<IMongoCollection<DogRecord>>(db.GetCollection<DogRecord>("Dogs"));

        return serviceProvider;
    }   
}