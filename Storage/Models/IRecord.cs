using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Storage.Models;

internal interface IRecord
{
    [BsonId]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid CorrelationId { get; set; }
}