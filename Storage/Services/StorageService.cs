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
        _actionsCollection.InsertOne(new ActionRecord
        {
            Name = request.Name,
            Description = request.Description,
            Owner = new ActionRecord.OwnerDto
            {
                Id = request.Owner.Id,
                Email = request.Owner.Email,
                FirstName = request.Owner.FirstName,
                FamilyName = request.Owner.FamilyName
            }
        });

        var list = await _actionsCollection.FindAsync(FilterDefinition<ActionRecord>.Empty);

        var first = list.FirstOrDefault();
        var str = first.ToString();

        return new AddActionResponse();
    }

    public async Task<GetAllActionsResponse> GetAllActionsAsync(GetAllActionsRequest request)
    {
        IAsyncCursor<ActionRecord> list = null;

        // if (request.Year != null)
        //     list = await _actionsCollection.FindAsync(filter => filter.Begin.Value.Year == request.Year); // nullable not supported here!
        // else
            list = await _actionsCollection.FindAsync(FilterDefinition<ActionRecord>.Empty);

        var actions = new List<ActionRecord>();
        await list.ForEachAsync(action => actions.Add(action));
        
        var result = new GetAllActionsResponse
        {
            Actions = actions
        };

        return result;
    }
}