namespace PetsOnTrailApp.Models;

public sealed record UserActivitiesModel
{
    public Guid UserId { get; init; }

    public IList<ActivityModel> Activities { get; init; } = new List<ActivityModel>(0);
}
