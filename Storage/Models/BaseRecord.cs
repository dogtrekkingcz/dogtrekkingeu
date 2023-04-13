using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Storage.Models;

internal record BaseRecord
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}