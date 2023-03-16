using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DogtrekkingCz.Storage.Models;

internal interface IRecord
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}