using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Storage.Entities.Actions;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;

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
        if (string.IsNullOrEmpty(request.Id))
            request.Id = Guid.NewGuid().ToString();
        
        await _collection.InsertOneAsync(request, cancellationToken: cancellationToken);

        return request;
    }

    public async Task<T> UpdateAsync(T request, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq("_id", request.Id);
        
        await _collection.ReplaceOneAsync(filter, request, cancellationToken: cancellationToken);

        return request;
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq("_id", id);
        
        await _collection.DeleteOneAsync(filter, cancellationToken: cancellationToken);
    }

    public async Task<T> GetAsync(string id, CancellationToken cancellationToken)
    {
        Console.WriteLine($"StorageService:GetAsync({id}");
        
        var filter = Builders<T>.Filter.Eq("_id", id);

        var document = await _collection
            .Find(filter)
            .FirstAsync(cancellationToken: cancellationToken);
        
        if (document != null)
            Console.WriteLine($"StorageService:GetAsync(): {document.Dump()}");
        else
            Console.WriteLine($"StorageService:GetAsync(): document with ID:'{id}' not found");

        return document;
    }

    public async Task<IReadOnlyList<T>> GetByFilterAsync(IList<(string key, System.Type typeOfValue, object value)> filterList, CancellationToken cancellationToken)
    {
        FilterDefinition<T> filter = null;
        
        if (filterList[0].typeOfValue == typeof(Guid))
        {
            filter = Builders<T>.Filter
                .Eq(filterList[0].key, ((Guid) filterList[0].value).ToString()); 
        }
        else if (filterList[0].typeOfValue == typeof(string))
        {
            filter = Builders<T>.Filter
                .Eq(filterList[0].key, (string) filterList[0].value);
        }
        else if (filterList[0].typeOfValue == typeof(bool))
        {
            filter = Builders<T>.Filter
                .Eq(filterList[0].key, (bool) filterList[0].value);
        }
        else if (filterList[0].typeOfValue == typeof(int))
        {
            filter = Builders<T>.Filter
                .Eq(filterList[0].key, (int) filterList[0].value);
        }
        else if (filterList[0].typeOfValue == typeof(double))
        {
            filter = Builders<T>.Filter
                .Eq(filterList[0].key, (double) filterList[0].value);
        }
        
        foreach (var f in filterList.Skip(1))
        {
            if (f.typeOfValue == typeof(Guid))
                filter &= (Builders<T>.Filter.Eq(f.key, ((Guid) f.value)).ToString());
            else if (f.typeOfValue == typeof(string))
                filter &= (Builders<T>.Filter.Eq(f.key, (string) f.value));
            else if (f.typeOfValue == typeof(bool))
                filter &= (Builders<T>.Filter.Eq(f.key, (bool) f.value));
            else if (f.typeOfValue == typeof(int))
                filter &= (Builders<T>.Filter.Eq(f.key, (int) f.value));
            else if (f.typeOfValue == typeof(double))
                filter &= (Builders<T>.Filter.Eq(f.key, (double) f.value));
        }



        var document = await _collection
            .Find(filter)
            .ToListAsync(cancellationToken);

        return document;
    }

    public async Task<IReadOnlyList<T>> GetByFilterBeLikeAsync(IList<(string key, string likeValue)> filterList, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter
            .Regex(filterList[0].key, new BsonRegularExpression($".*{filterList[0].likeValue}.*"));

        foreach (var f in filterList.Skip(1))
        {
            filter &= (Builders<T>.Filter
                .Regex(f.key, new BsonRegularExpression($".*{f.likeValue}.*")));
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