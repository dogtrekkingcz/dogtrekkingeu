using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DogtrekkingCz.Storage.Models;

internal record BaseRecord
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}