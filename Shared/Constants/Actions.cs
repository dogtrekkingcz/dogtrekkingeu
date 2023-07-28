namespace Constants;

public static class Actions
{
    public static string ManageAllActions = "Manage.AllActions";
    public static string ManageAllEntries = "Manage.AllEntries";
    public static string ManageAllDogs = "Manage.AllDogs";
    public static string ManageAllActionRights = "Manage.AllActionRights";
    public static string ManageOwnedActions = "Manage.OwnerActions";

    public static IList<string> GetAllActions()
    {
        return new List<string>
        {
            ManageAllActions,
            ManageAllEntries,
            ManageAllDogs,
            ManageAllActionRights
        };
    }
}