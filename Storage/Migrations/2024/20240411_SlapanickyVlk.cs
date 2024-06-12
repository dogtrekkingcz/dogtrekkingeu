using System.Threading;

namespace Storage.Migrations._2024;

internal class _20240411_SlapanickyVlk : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("e67c4971-1185-4e40-864f-fc3f876c84fd");
    protected Guid IdLong { get; init; } = Guid.Parse("4d962ac4-c877-4b51-9dcf-5bf297abccdd");
    protected Guid IdLongDtw1 { get; init; } = Guid.Parse("a0474a99-2a30-4ed7-9adb-9232ffc421cc");
    protected Guid IdLongDtm1 { get; init; } = Guid.Parse("0069ab28-5aa2-4e77-81ed-4f72f345b732");
    protected Guid IdLongDtw2 { get; init; } = Guid.Parse("b79e61bc-1624-487c-a1f8-ed3ebe2a1ba5");
    protected Guid IdLongDtm2 { get; init; } = Guid.Parse("859786b1-45b1-4ef4-aa96-df3d9a270d03");

    protected Guid IdMid { get; init; } = Guid.Parse("bc4d2851-23cb-4455-97b7-28990c585f69");
    protected Guid IdMidDmw1 { get; init; } = Guid.Parse("70ce5b42-4b89-439d-8e47-f12f03898725");
    protected Guid IdMidDmm1 { get; init; } = Guid.Parse("afb93d57-343d-4b93-99a1-2c9d2ef8c5cc");
    protected Guid IdMidDmw2 { get; init; } = Guid.Parse("144e1f9e-8a21-4a56-b94f-d0687e6aa902");
    protected Guid IdMidDmm2 { get; init; } = Guid.Parse("6b59eb5b-a7a0-49f9-97b8-49f9ad6db3ac");

    protected override string Name { get; init; } = nameof(_20240411_SlapanickyVlk);

    public _20240411_SlapanickyVlk(IServiceProvider serviceProvider) : base(serviceProvider) 
    {
        this
            .AddUpAction(() => ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
            {
                Id = Id,
                Name = "Šlapanický vlk",
                TypeId = Constants.ActivityType.Dogtrekking,
                Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                {
                    City = "Šlapanice"
                },
                Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
                {
                    From = new DateTime(2024, 4, 11, 17, 0, 0),
                    To = new DateTime(2024, 4, 14, 13, 0, 0)
                },
                Races = new List<Entities.Actions.CreateActionInternalStorageRequest.RaceDto>
                {
                    new Entities.Actions.CreateActionInternalStorageRequest.RaceDto
                    {
                        Id = IdLong,
                        Name = "Dogtrekking",
                        Begin = new DateTime(2024, 4, 12, 7, 0, 0),
                        End = new DateTime(2024, 4, 14, 12, 0, 0),
                        Limits = new Entities.Actions.CreateActionInternalStorageRequest.LimitsDto
                        {
                            WithPets = true,
                            MinimalAgeOfRacerInDayes = 0,
                            MinimalAgeOfThePetInDayes = 18 * 30,
                        },
                        Distance = 92,
                        Categories = new List<Entities.Actions.CreateActionInternalStorageRequest.CategoryDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = IdLongDtw1,
                                Name = "DTW1",
                                Description = "DTW1",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "Nikol",
                                        LastName = "Hamáková",
                                        Start = new DateTime(2024, 4, 12, 7, 12, 0),
                                        Finish = new DateTime(2024, 4, 12, 21, 51, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Finished
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "Kristýna",
                                        LastName = "Lédlová",
                                        Start = new DateTime(2024, 4, 12, 8, 29, 0),
                                        Finish = new DateTime(2024, 4, 13, 02, 40, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Finished
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "Luisa",
                                        LastName = "Wáwrová",
                                        Start = new DateTime(2024, 4, 12, 7, 45, 0),
                                        Finish = new DateTime(2024, 4, 13, 04, 23, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Finished
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "Veronika",
                                        LastName = "Fránková",
                                        Start = new DateTime(2024, 4, 12, 7, 43, 0),
                                        Finish = new DateTime(2024, 4, 13, 04, 38, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Finished
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "Adelhaida",
                                        LastName = "Fego",
                                        Start = new DateTime(2024, 4, 12, 7, 28, 0),
                                        Finish = new DateTime(2024, 4, 13, 05, 56, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Finished
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "Klára",
                                        LastName = "Dolečková",
                                        Start = new DateTime(2024, 4, 12, 9, 00, 0),
                                        Finish = new DateTime(2024, 4, 13, 12, 41, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Finished
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "Eliška",
                                        LastName = "Drugdová",
                                        Start = new DateTime(2024, 4, 12, 7, 24, 0),
                                        Finish = new DateTime(2024, 4, 13, 11, 53, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Finished
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "Adéla",
                                        LastName = "Finkousová",
                                        Start = new DateTime(2024, 4, 12, 7, 25, 0),
                                        Finish = new DateTime(2024, 4, 13, 12, 34, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Finished
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "Nela",
                                        LastName = "Jandeková",
                                        Start = new DateTime(2024, 4, 12, 7, 56, 0),
                                        Finish = new DateTime(2024, 4, 13, 17, 09, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Finished
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "Andrea",
                                        LastName = "Šefraná",
                                        Start = new DateTime(2024, 4, 12, 7, 20, 0),
                                        Finish = new DateTime(2024, 4, 14, 06, 50, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Finished
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "Jana",
                                        LastName = "Štefková",
                                        Start = new DateTime(2024, 4, 12, 7, 07, 0),
                                        Finish = new DateTime(2024, 4, 14, 12, 00, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.DidNotFinished
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "Iveta",
                                        LastName = "Hajlichová",
                                        Start = new DateTime(2024, 4, 12, 9, 00, 0),
                                        Finish = new DateTime(2024, 4, 14, 12, 00, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.DidNotFinished
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = IdLongDtm1,
                                Name = "DTM1",
                                Description = "DTM1"
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = IdLongDtw2,
                                Name = "DTW2",
                                Description = "DTW2"
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = IdLongDtm2,
                                Name = "DTM2",
                                Description = "DTM2"
                            },
                        }
                    },
                    new Entities.Actions.CreateActionInternalStorageRequest.RaceDto
                    {
                        Id = IdMid,
                        Name = "Mid",
                        Begin = new DateTime(2024, 4, 13, 7, 0, 0),
                        End = new DateTime(2024, 4, 14, 12, 0, 0),
                        Limits = new Entities.Actions.CreateActionInternalStorageRequest.LimitsDto
                        {
                            WithPets = true,
                            MinimalAgeOfRacerInDayes = 0,
                            MinimalAgeOfThePetInDayes = 18 * 30,
                        },
                        Distance = 46,
                        Categories = new List<Entities.Actions.CreateActionInternalStorageRequest.CategoryDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = IdMidDmw1,
                                Name = "DMW1",
                                Description = "DMW1"
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = IdMidDmm1,
                                Name = "DMM1",
                                Description = "DMM1"
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = IdMidDmw2,
                                Name = "DMW2",
                                Description = "DMW2"
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = IdMidDmm2,
                                Name = "DMM2",
                                Description = "DMM2"
                            }
                        }
                    }
                }
            }, CancellationToken.None))

            .AddDownAction(() => ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
