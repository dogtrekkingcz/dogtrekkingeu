using SharedCode.Entities;

namespace DogsOnTrail.Interfaces.Actions.Entities.Entries;

public sealed record CreateEntryRequest : EntryDto
{
    public string LanguageCode { get; set; } = "en-US";
}