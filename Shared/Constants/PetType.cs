namespace Constants;

public static class PetType
{
    public static Guid Dog => Guid.Parse("e68822f3-1732-4c21-8edb-b187caff3679");
    public static Guid Cat => Guid.Parse("52661afc-1679-40a4-b393-2f5517c8e231");
    public static Guid Horse => Guid.Parse("e7ebb102-bd9b-4e5d-aaa2-55b75e5983a7");

    public static List<Guid> All => new List<Guid>
    {
        Dog,
        Cat,
        Horse
    };
}
