using System.Reflection.Metadata.Ecma335;

namespace Constants;

public static class ActivityType
{
    public const string Dogtrekking = "37a107bc-b06b-4bd5-ba03-95ee5a14473d";
    public const string Obedience = "371e749e-f59d-47d6-8e71-dfb7f245c2e2";
    public const string RallyObedience = "e2c9a183-b98c-4144-9e10-0c07fff3e483";
    public const string Agility = "818360ec-98d4-459a-a36f-a1276ed10ee8";
    public const string Canicross = "834de30b-d249-41e8-addb-600d20e658a5";
    public const string Bikejoring = "c80969ba-7353-4d1a-a184-4c83ae6e174b";
    public const string Skijoring = "3996610f-47fa-4327-a43a-392011b9093c";
    public const string SledDog = "85d442ad-4b22-453e-8454-0abe8cc0d818";
    public const string DogDancing = "22a65fb3-26ee-4aa6-87ae-54eb29d280d6";
    public const string Frisbee = "7e19a001-c922-4a0f-bc3a-67c91f8fcbc3";
    public const string Flyball = "ad1d65ed-a5a8-4d6e-aafe-9feeb9996d22";
    public const string DiscDog = "c507f081-f72d-4d20-9945-69c5d8bcef0b";
    public const string DogHiking = "bdf01b39-02a6-4a34-b434-18711660fa74";
    public const string Tracking = "d52e3bfc-6c59-4361-9579-c24d3dd8a4c1";
    public const string IPO = "14990dcf-24c2-40e1-9d32-a30ded374213";
    public const string Scooter = "f4f44850-c10e-4c40-997e-65492665ff12";
    public const string EScooter = "2b17494c-faec-4dda-8ed3-29acc94dde90";
    public const string DogTrekking = "f9101c55-532f-4eb2-823f-96130b6ecab4";
    public const string Snowboarding = "67541ec5-1715-4057-8bb2-2b37ed174f00";
    public const string Skiing = "5a341758-98e0-45d6-a305-38e261bb4193";
    public const string Skating = "f8332595-fe1f-4154-a697-f20c48c1c247";
    public const string Hiking = "e8e7a580-50bc-4ffd-b1ac-1afe223cf6da";
    public const string Biking = "b9eb998e-66c4-405d-9a54-466894426a49";
    public const string Running = "e00720e9-0129-454d-89a7-29524aadcece";
    public const string Walking = "fb9e28de-36f0-478c-84ca-87d41203629b";

    public static List<Guid> All => new List<Guid>
    {
        Guid.Parse(Dogtrekking),
        Guid.Parse(Obedience),
        Guid.Parse(RallyObedience),
        Guid.Parse(Agility),
        Guid.Parse(Canicross),
        Guid.Parse(Bikejoring),
        Guid.Parse(Skijoring),
        Guid.Parse(SledDog),
        Guid.Parse(DogDancing),
        Guid.Parse(Frisbee),
        Guid.Parse(Flyball),
        Guid.Parse(DiscDog),
        Guid.Parse(DogHiking),
        Guid.Parse(Tracking),
        Guid.Parse(IPO),
        Guid.Parse(Scooter),
        Guid.Parse(EScooter),
        Guid.Parse(DogTrekking),
        Guid.Parse(Snowboarding),
        Guid.Parse(Skiing),
        Guid.Parse(Skating),
        Guid.Parse(Hiking),
        Guid.Parse(Biking),
        Guid.Parse(Running),
        Guid.Parse(Walking)
    };
}
