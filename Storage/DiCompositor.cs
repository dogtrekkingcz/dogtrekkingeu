using System;
using System.Threading;
using System.Threading.Tasks;
using DogtrekkingCz.Storage.Models;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Storage.Interfaces.Options;
using Storage.Interfaces.Services;
using Storage.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Storage.Interfaces;
using Storage.Services.Repositories;
using MapsterMapper;

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

        serviceProvider.AddScoped<IMapper, ServiceMapper>();
        serviceProvider.AddSingleton<IInitializeService>(new InitializeService(options));
        serviceProvider.AddSingleton<IStorageService<ActionRecord>, StorageService<ActionRecord>>();
        serviceProvider.AddScoped<IActionsRepositoryService, ActionsRepositoryService>();

        typeAdapterConfig.AddActionRepositoryMapping();
        
        BsonClassMap.RegisterClassMap<ActionRecord>();

        var client = new MongoClient(options.MongoDbConnectionString);
        Console.WriteLine($"MongoDb client: {client}");
        
        Console.WriteLine($"MongoDb databases: {string.Join(", ", client.ListDatabaseNames().ToList())}");

        var db = client.GetDatabase("DogtrekkingEu");

        var listOfCollections = db.ListCollectionNames().ToList();
        Console.WriteLine($"MongoDb.DogtrekkingEu.Collections: {string.Join(", ", listOfCollections)}");
        
        if (listOfCollections.Contains("Actions") == false)
        {
            db.CreateCollection("Actions");
        }

        Console.WriteLine($"MongoDb.DogtrekkingEu.Collections with initialized collections: {db.ListCollectionNames()}");
        
        serviceProvider.AddSingleton<IMongoCollection<ActionRecord>>(db.GetCollection<ActionRecord>("Actions"));

        return serviceProvider;
    }   
}