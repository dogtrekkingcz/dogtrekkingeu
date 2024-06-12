using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Storage.Extensions;
using Storage.Interfaces;
using Storage.Models;
using Storage.Options;

namespace Storage.Services;

internal class StorageService<T> : IStorageService<T> where T: IRecord
{
    private readonly IMongoCollection<T> _collection;
    private readonly ILogger<StorageService<T>> _logger;
    private readonly StorageOptions _storageOptions;
    
    public StorageService(ILogger<StorageService<T>> logger, IMongoCollection<T> collection, StorageOptions storageOptions)
    {
        _collection = collection;
        _logger = logger;
        _storageOptions = storageOptions;
    }
    public async Task<T> AddOrUpdateAsync(T request, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq(x => x.Id, request.Id);
        if (request.Id == Guid.Empty)
            request.Id = Guid.NewGuid();

        BackupHistory(request);
        UpdateSeedWithLatestData(request);

        if ((await _collection.FindAsync(filter)).Any(cancellationToken))
            await _collection.ReplaceOneAsync(filter, request, cancellationToken: cancellationToken);
        else
            await _collection.InsertOneAsync(request, cancellationToken: cancellationToken);

        return request;
    }

    private void UpdateSeedWithLatestData(T request)
    {
        var seedTargetDirectory = Path.Combine(_storageOptions.SeedPath, $"{typeof(T).FullName}/");
        Directory.CreateDirectory(seedTargetDirectory);

        var seedTargetFile = Path.Combine(seedTargetDirectory, $"{request.Id}.json");
        using (FileStream fcreate = File.Open(seedTargetFile, FileMode.Create))
        {
            using (StreamWriter outputFile = new StreamWriter(fcreate))
            {
                outputFile.Write(request.Dump());
            }
        }
    }

    private void BackupHistory(T request)
    {
        var targetDirectory = Path.Combine(_storageOptions.BackupPath, $"{typeof(T).FullName}/{DateTime.Now.ToString("yyyy-MM-dd")}/");
        Directory.CreateDirectory(targetDirectory);

        var targetFile = Path.Combine(targetDirectory, $"{request.Id}___{DateTime.Now.ToString("HHmmss")}.json");
        using (FileStream fcreate = File.Open(targetFile, FileMode.Create))
        {
            using (StreamWriter outputFile = new StreamWriter(fcreate))
            {
                outputFile.Write(request.Dump());
            }
        }
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq(x => x.Id, id);
        
        await _collection.DeleteOneAsync(filter, cancellationToken: cancellationToken);
    }

    public async Task DeleteAllByCorrelationIdAsync(Guid correlationId, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq(x => x.CorrelationId, correlationId);
        
        await _collection.DeleteManyAsync(filter, cancellationToken: cancellationToken);
    }

    public async Task<T> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq(x => x.Id, id);

        var document = await _collection
            .Find(filter)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        
        return document;
    }

    public async Task<IReadOnlyList<T>> GetSelectedListAsync(IList<Guid> ids, CancellationToken cancellationToken)
    {
        FilterDefinition<T> filter = Builders<T>.Filter
            .In(x => x.Id, ids.Select(id => id));
        
        var document = await _collection
            .Find(filter)
            .ToListAsync(cancellationToken);

        return document;
    }

    public async Task<IReadOnlyList<T>> GetSelectedListAsync(string key, IList<Guid> ids, CancellationToken cancellationToken)
    {
        FilterDefinition<T> filter = Builders<T>.Filter
            .In(key, ids.Select(id => id));
        
        var document = await _collection
            .Find(filter)
            .ToListAsync(cancellationToken);

        return document;
    }
    
    public async Task<IReadOnlyList<T>> GetByFilterAsync(IList<(string key, System.Type typeOfValue, object value)> filterList, CancellationToken cancellationToken)
    {
        FilterDefinition<T> filter = Builders<T>.Filter.Empty;

        foreach (var f in filterList)
        {
            if (f.typeOfValue == typeof(Guid))
                filter &= (Builders<T>.Filter.Eq(f.key, (((Guid) f.value)).ToString()));
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

    public async Task<IReadOnlyList<T>> GetByUserId(Guid userId, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Where(e => e.UserId == userId);
        
        var documents = await _collection
            .Find(filter)
            .ToListAsync(cancellationToken);

        return documents;
    }

    public async Task<IReadOnlyList<T>> GetByUserIdAndCorrelationId(Guid userId, Guid correlationId, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Where(e => e.UserId == userId && e.CorrelationId == correlationId);

        var documents = await _collection
            .Find(filter)
            .ToListAsync(cancellationToken);

        return documents;
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