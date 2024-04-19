using System.ComponentModel.DataAnnotations;

namespace PetsOnTrailApp.Models;

public sealed record ResultsModel : BaseSynchronizedModel
{
    public Guid ActionId { get; init; }

    public Guid RaceId { get; init; }

    public Guid CategoryId { get; init; }

    public List<ResultDto> Results { get; set; } = new();

    public sealed record ResultDto
    {
        public Guid Id { get; init; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public List<string> Pets { get; set; } = new List<string>();

        public DateTimeOffset? Start { get; set; } = null;

        public DateTimeOffset? Finish { get; set; } = null;

        public ResultState State { get; set; } = ResultState.NotValid;
    }

    public enum ResultState
    {
        NotValid = 0,
        NotStarted,
        Started,
        Finished,
        DidNotFinished,
        Disqualified
    }
}
