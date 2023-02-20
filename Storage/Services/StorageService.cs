using System.Threading.Tasks;
using DogtrekkingCz.Storage.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Storage.Entities.Actions;
using Storage.Interfaces.Services;

namespace Storage.Services;

internal class StorageService<T> : IStorageService<T> where T: BaseRecord
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

    public async Task<T> UpdateAsync(T request)
    {
        var filter = Builders<T>.Filter.Eq("Id", request.Id);
        
        await _collection.ReplaceOneAsync(filter, request);

        return request;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        var documents = await _collection
            .Find<T>(new BsonDocument())
            .ToListAsync();

        return documents;
    }
}