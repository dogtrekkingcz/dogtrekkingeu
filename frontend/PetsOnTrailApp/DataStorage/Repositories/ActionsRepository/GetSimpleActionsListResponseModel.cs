using PetsOnTrailApp.Models;
using Protos.Actions.GetSimpleActionsList;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public sealed record GetSimpleActionsListResponseModel
{
    public IList<SimpleActionDto> Actions { get; set; }

    public sealed record SimpleActionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public Guid Type { get; set; }    
        public IList<RaceDto> Races { get; set; }
    }

    public sealed record RaceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
