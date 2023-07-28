namespace Constants.Roles;

public static class InternalAdministrator
{
    public const string Id = "InternalAdministrator";

    public const string Name = "Internal Administrator";

    public static IList<string> Actions = new List<string>
    {
        Constants.Actions.ManageAllActions,
        Constants.Actions.ManageAllEntries,
        Constants.Actions.ManageAllDogs,
        Constants.Actions.ManageAllActionRights
    };
}