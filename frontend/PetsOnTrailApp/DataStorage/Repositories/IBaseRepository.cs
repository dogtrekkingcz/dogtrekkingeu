using static Protos.Actions.Actions;

namespace PetsOnTrailApp.DataStorage.Repositories;

public interface IBaseRepository
{
    protected ActionsClient ActionsClientInstance { get; init; }

    List<Guid> GetMyRoles();
}
