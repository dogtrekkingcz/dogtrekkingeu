using DogtrekkingCz.Storage.Models;

namespace Storage.Entities.Actions;

public sealed record GetAllActionsResponse
{
    public IReadOnlyList<ActionDto> Actions { get; init; }

    public sealed record ActionDto
    {
        public required string Name { get; set; }

        public OwnerDto Owner { get; set; }

        public string Description { get; set; }
    }

    public sealed record OwnerDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }
    }
}