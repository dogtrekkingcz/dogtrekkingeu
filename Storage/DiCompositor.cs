using DogtrekkingCz.Storage.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Storage.Interfaces.Options;
using Storage.Interfaces.Services;
using Storage.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

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
    
    public static IServiceCollection AddStorage(this IServiceCollection serviceProvider, StorageOptions options)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        
        serviceProvider.AddSingleton<IInitializeService>(new InitializeService(options));
        serviceProvider.AddSingleton<IStorageService, StorageService>();
        
        BsonClassMap.RegisterClassMap<ActionRecord>();

        serviceProvider.AddSingleton<IMongoCollection<ActionRecord>>(new MongoClient(options.MongoDbConnectionString)
            .GetDatabase("DogtrekkingEu")
            .GetCollection<ActionRecord>("Actions"));

        return serviceProvider;
    }   
}