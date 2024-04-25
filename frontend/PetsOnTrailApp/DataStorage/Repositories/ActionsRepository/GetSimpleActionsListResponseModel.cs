using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.DataStorage.Repositories.ActionsRepository;

public sealed record GetSimpleActionsListResponseModel
{
    public SimpleActionModel[] Actions { get; set; } = Array.Empty<SimpleActionModel>();
}
