using SharedCode.Entities;

namespace Storage.Models;

internal sealed record EntryRecord : EntryDto, IRecord
{
    public string ActionId { get; set; } = String.Empty;

    public string RaceId { get; set; } = string.Empty;

    public string CategoryId { get; set; } = string.Empty;
}