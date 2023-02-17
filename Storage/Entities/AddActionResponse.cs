using DogtrekkingCz.Storage.Models;

namespace Storage.Interfaces.Entities;

public sealed record AddActionResponse
{
    public ActionRecord Result { get; init; }
}