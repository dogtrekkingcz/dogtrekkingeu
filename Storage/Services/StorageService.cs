﻿using System.Threading.Tasks;
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

    public async Task DeleteAsync(T request)
    {
        var filter = Builders<T>.Filter.Eq("Id", request.Id);
        
        await _collection.DeleteOneAsync(filter);
    }

    public async Task<T> GetAsync(T request)
    {
        var filter = Builders<T>.Filter.Eq("Id", request.Id);

        var document = await _collection
            .Find(filter)
            .FirstAsync();

        return document;
    }

    public async Task<IReadOnlyList<T>> GetByFilterAsync(IList<(string key, string value)> filterList)
    {
        var filter = Builders<T>.Filter
            .Eq(filterList[0].key, filterList[0].value);

        foreach (var f in filterList.Skip(1))
        {
            filter &= (Builders<T>.Filter.Eq(f.key, f.value));
        }

        var document = await _collection
            .Find(filter)
            .ToListAsync();

        return document;
    }
    
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        var documents = await _collection
            .Find<T>(new BsonDocument())
            .ToListAsync();

        return documents;
    }
    
    public async Task<IReadOnlyList<T>> GetAllAsync(string[] param)
    {
        var documents = await _collection.Find<T>(new BsonDocument())
            .Project<T>(Builders<T>.Projection.Include(obj => obj.Id))
            .ToListAsync();

        return documents;
    }
}