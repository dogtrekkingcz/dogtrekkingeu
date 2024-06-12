using System.Reflection.Metadata.Ecma335;

namespace Constants;

public static class ActivityType
{
    public static Guid Dogtrekking = Guid.Parse("37a107bc-b06b-4bd5-ba03-95ee5a14473d");
    public static Guid Obedience = Guid.Parse("371e749e-f59d-47d6-8e71-dfb7f245c2e2");
    public static Guid RallyObedience = Guid.Parse("e2c9a183-b98c-4144-9e10-0c07fff3e483");
    public static Guid Agility = Guid.Parse("818360ec-98d4-459a-a36f-a1276ed10ee8");
    public static Guid Canicross = Guid.Parse("834de30b-d249-41e8-addb-600d20e658a5");
    public static Guid Bikejoring = Guid.Parse("c80969ba-7353-4d1a-a184-4c83ae6e174b");
    public static Guid Skijoring = Guid.Parse("3996610f-47fa-4327-a43a-392011b9093c");
    public static Guid SledDog = Guid.Parse("85d442ad-4b22-453e-8454-0abe8cc0d818");
    public static Guid DogDancing = Guid.Parse("22a65fb3-26ee-4aa6-87ae-54eb29d280d6");
    public static Guid Frisbee = Guid.Parse("7e19a001-c922-4a0f-bc3a-67c91f8fcbc3");
    public static Guid Flyball = Guid.Parse("ad1d65ed-a5a8-4d6e-aafe-9feeb9996d22");
    public static Guid DiscDog = Guid.Parse("c507f081-f72d-4d20-9945-69c5d8bcef0b");
    public static Guid DogHiking = Guid.Parse("bdf01b39-02a6-4a34-b434-18711660fa74");
    public static Guid Tracking = Guid.Parse("d52e3bfc-6c59-4361-9579-c24d3dd8a4c1");
    public static Guid IPO = Guid.Parse("14990dcf-24c2-40e1-9d32-a30ded374213");
    public static Guid Scooter = Guid.Parse("f4f44850-c10e-4c40-997e-65492665ff12");
    public static Guid EScooter = Guid.Parse("2b17494c-faec-4dda-8ed3-29acc94dde90");
    public static Guid DogTrekking = Guid.Parse("f9101c55-532f-4eb2-823f-96130b6ecab4");
    public static Guid Snowboarding = Guid.Parse("67541ec5-1715-4057-8bb2-2b37ed174f00");
    public static Guid Skiing = Guid.Parse("5a341758-98e0-45d6-a305-38e261bb4193");
    public static Guid Skating = Guid.Parse("f8332595-fe1f-4154-a697-f20c48c1c247");
    public static Guid Hiking = Guid.Parse("e8e7a580-50bc-4ffd-b1ac-1afe223cf6da");
    public static Guid Biking = Guid.Parse("b9eb998e-66c4-405d-9a54-466894426a49");
    public static Guid Running = Guid.Parse("e00720e9-0129-454d-89a7-29524aadcece");
    public static Guid Walking = Guid.Parse("fb9e28de-36f0-478c-84ca-87d41203629b");

    public static List<Guid> All => new List<Guid>
    {
        Dogtrekking,
        Obedience,
        RallyObedience,
        Agility,
        Canicross,
        Bikejoring,
        Skijoring,
        SledDog,
        DogDancing,
        Frisbee,
        Flyball,
        DiscDog,
        DogHiking,
        Tracking,
        IPO,
        Scooter,
        EScooter,
        DogTrekking,
        Snowboarding,
        Skiing,
        Skating,
        Hiking,
        Biking,
        Running,
        Walking
    };
}
