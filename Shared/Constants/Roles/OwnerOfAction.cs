namespace Constants.Roles;

public static class OwnerOfAction
{
    public const string Id = "OwnerOfAction";

    public const string Name = "Owner of the action";

    public static IList<string> Actions = new List<string>
    {
        Constants.Actions.ManageOwnedActions,
    };
}