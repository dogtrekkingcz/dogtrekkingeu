using System.Threading.Tasks;
using DogtrekkingCz.Storage.Models;
using Google.Protobuf.WellKnownTypes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Storage.Entities.Actions;
using Storage.Interfaces.Services;

namespace Storage.Services;

internal class StorageService<T> : IStorageService<T> where T: IRecord
{
    private readonly IMongoCollection<T> _collection;
    
    public StorageService(IMongoCollection<T> collection)
    {
        _collection = collection;
    }
    public async Task<T> AddAsync(T request, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(request, cancellationToken: cancellationToken);

        return request;
    }

    public async Task<T> UpdateAsync(T request, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq("Id", request.Id);
        
        await _collection.ReplaceOneAsync(filter, request, cancellationToken: cancellationToken);

        return request;
    }

    public async Task DeleteAsync(T request, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq("Id", request.Id);
        
        await _collection.DeleteOneAsync(filter, cancellationToken: cancellationToken);
    }

    public async Task<T> GetAsync(T request, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq("Id", request.Id);

        var document = await _collection
            .Find(filter)
            .FirstAsync(cancellationToken: cancellationToken);

        return document;
    }

    public async Task<IReadOnlyList<T>> GetByFilterAsync(IList<(string key, string value)> filterList, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter
            .Eq(filterList[0].key, filterList[0].value);

        foreach (var f in filterList.Skip(1))
        {
            filter &= (Builders<T>.Filter.Eq(f.key, f.value));
        }

        var document = await _collection
            .Find(filter)
            .ToListAsync(cancellationToken);

        return document;
    }
    
    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        var documents = await _collection
            .Find<T>(new BsonDocument())
            .ToListAsync(cancellationToken);

        return documents;
    }
    
    public async Task<IReadOnlyList<T>> GetAllAsync(string[] param, CancellationToken cancellationToken)
    {
        var documents = await _collection.Find<T>(new BsonDocument())
            .Project<T>(Builders<T>.Projection.Include(obj => obj.Id))
            .ToListAsync(cancellationToken);

        return documents;
    }
}