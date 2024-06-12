using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Storage.Models;

internal record BaseRecord : IRecord
{
    [BsonId]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; } = Guid.Empty;

    public Guid CorrelationId { get; set; } = Guid.Empty;
}