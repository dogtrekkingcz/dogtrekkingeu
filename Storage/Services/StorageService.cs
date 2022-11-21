using System.Threading.Tasks;
using DogtrekkingCz.Storage.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Storage.Interfaces.Entities;
using Storage.Interfaces.Services;

namespace Storage.Services;

public class StorageService : IStorageService
{
    private readonly MongoClient _client;
    private readonly IMongoCollection<ActionRecord> _actionsCollection;
    
    public StorageService(IMongoCollection<ActionRecord> actionsCollection)
    {
        _actionsCollection = actionsCollection;
    }
    public async Task<AddActionResponse> AddActionAsync(AddActionRequest request)
    {
        _actionsCollection.InsertOne(new ActionRecord { Name = request.Name });

        var list = await _actionsCollection.FindAsync(FilterDefinition<ActionRecord>.Empty);

        var first = list.FirstOrDefault();
        var str = first.ToString();
        
        
        return new AddActionResponse();
    }
}