namespace Constants;

public static class PetType
{
    public const string Dog = "e68822f3-1732-4c21-8edb-b187caff3679";
    public const string Cat = "52661afc-1679-40a4-b393-2f5517c8e231";
    public const string Horse = "e7ebb102-bd9b-4e5d-aaa2-55b75e5983a7";

    public static List<Guid> All => new List<Guid>
    {
        Guid.Parse(Dog),
        Guid.Parse(Cat),
        Guid.Parse(Horse)
    };
}
