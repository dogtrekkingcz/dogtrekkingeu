using MongoDB.Bson;
using MongoDB.Driver;
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
        FilterDefinition<T> filter = Builders<T>.Filter.Empty;

        foreach (var f in filterList)
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
        var filter = Builders<T>.Filter.Empty;

        foreach (var f in filterList)
        {
            filter &= (Builders<T>.Filter
                .Regex(f.key, new BsonRegularExpression($".*{f.likeValue}.*")));
        }

        var document = await _collection
            .Find(filter)
            .ToListAsync(cancellationToken);

        return document;
    }

    public async Task<IReadOnlyList<T>> GetByTimeFilterAsync(IList<(string key, IStorageService<T>.FilterOptions option, DateTimeOffset value)> filterList, CancellationToken cancellationToken)
    {

        var filter = Builders<T>.Filter.Empty;
        
        foreach (var f in filterList)
        {
            switch (f.option)
            {
                case IStorageService<T>.FilterOptions.Equal: 
                    filter &= (Builders<T>.Filter.Eq(f.key, f.value));
                    break;
                
                case IStorageService<T>.FilterOptions.LessThan:
                    filter &= (Builders<T>.Filter.Lt(f.key, f.value));
                    break;
                
                case IStorageService<T>.FilterOptions.LessThanOrEqual:
                    filter &= (Builders<T>.Filter.Lte(f.key, f.value));
                    break;
                
                case IStorageService<T>.FilterOptions.MoreThan:
                    filter &= (Builders<T>.Filter.Gt(f.key, f.value));
                    break;
                
                case IStorageService<T>.FilterOptions.MoreThanOrEqual:
                    filter &= (Builders<T>.Filter.Gte(f.key, f.value));
                    break;
            }
        }
            
        var document = await _collection
            .Find(filter)
            .ToListAsync(cancellationToken);

        return document;
    }

    public async Task<IReadOnlyList<T>> GetByCustomFilterAsync(BsonDocument filter, CancellationToken cancellationToken)
    {
        var documents = await _collection
            .Find(filter)
            .ToListAsync(cancellationToken);

        return documents;
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