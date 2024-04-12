namespace Constants;

public enum ActionType
{
    None = 0,
    GlobalRead = 1,
    GlobalInsert = 2,
    GlobalUpdate = 3,
    GlobalDelete = 4,

    ActionsRead = 5,
    ActionsInsert = 6,
    ActionsUpdate = 7,
    ActionsDelete = 8,

    ActionsUpdateOwn = 5,
    ActionsDeleteOwn = 6
}