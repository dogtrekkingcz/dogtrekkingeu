using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Storage.Models;

internal record BaseRecord : IRecord
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public Guid UserId { get; set; } = Guid.Empty;

    public Guid CorrelationId { get; set; } = Guid.Empty;
}