using DogtrekkingCz.Storage.Models;
using static Storage.Entities.Actions.AddActionRequest;

namespace Storage.Entities.Actions;

public sealed record UpdateActionResponse
{
    public string Id { get; set; }
}