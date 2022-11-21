using MongoDB.Bson;

namespace DogtrekkingCz.Storage.Models;

public sealed record ActionRecord
{
    [MongoDB.Bson.Serialization.Attributes.BsonElement("_id")]
    public MongoDB.Bson.ObjectId MongoId { get; set; } = ObjectId.GenerateNewId();
    public string Name { get; set; }
}