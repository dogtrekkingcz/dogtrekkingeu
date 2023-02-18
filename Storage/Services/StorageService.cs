using System.Threading.Tasks;
using DogtrekkingCz.Storage.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Storage.Entities.Actions;
using Storage.Interfaces.Services;

namespace Storage.Services;

internal class StorageService<T> : IStorageService<T>
{
    private readonly MongoClient _client;
    private readonly IMongoCollection<T> _collection;
    
    public StorageService(IMongoCollection<T> collection)
    {
        _collection = collection;
    }
    public async Task<T> AddAsync(T request)
    {
        await _collection.InsertOneAsync(request);

        return request;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        var list = await _collection.FindAsync(FilterDefinition<T>.Empty);

        var response = new List<T>();
        await list.ForEachAsync(item => response.Add(item));
        
        return response;
    }
}