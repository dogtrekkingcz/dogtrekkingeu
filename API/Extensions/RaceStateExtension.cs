using PetsOnTrail.Interfaces.Actions.Entities.Actions;
using Storage.Entities.Actions;

namespace PetsOnTrail.Actions.Extensions;

internal static class RaceStateExtension
{
    public static GetActionResponse.RaceState ToGetActionResponseRaceState(this GetActionInternalStorageResponse.RaceState raceState)
    {
        return raceState switch
        {
            GetActionInternalStorageResponse.RaceState.NotStarted => GetActionResponse.RaceState.NotStarted,
            GetActionInternalStorageResponse.RaceState.Disqualified => GetActionResponse.RaceState.Disqualified,
            GetActionInternalStorageResponse.RaceState.Finished => GetActionResponse.RaceState.Finished,
            GetActionInternalStorageResponse.RaceState.DidNotFinished => GetActionResponse.RaceState.DidNotFinished,
            GetActionInternalStorageResponse.RaceState.Started => GetActionResponse.RaceState.Started,
            GetActionInternalStorageResponse.RaceState.NotValid => GetActionResponse.RaceState.NotValid,

            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
