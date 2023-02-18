using DogtrekkingCz.Storage.Models;
using static Storage.Entities.Actions.AddActionRequest;

namespace Storage.Entities.Actions;

public sealed record AddActionResponse
{
    public required string Name { get; set; }

    public OwnerDto Owner { get; set; }

    public string Description { get; set; }

    public sealed record OwnerDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }
    }
}