using static Storage.Entities.Actions.CreateActionInternalStorageRequest;

namespace Storage.Migrations._2024;

internal class _20240328_ZdeJsouLvi : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("e155cf24-1147-453a-8d08-0010a1dfceb7");
    protected override string Name { get; init; } = nameof(_20240328_ZdeJsouLvi);

    public _20240328_ZdeJsouLvi(IServiceProvider serviceProvider) : base(serviceProvider) 
    {
        var start = new DateTime(2024, 3, 29, 09, 0, 0);

        this
            .AddUpAction(() => ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
            {
                Id = Id,
                Name = "ZDE JSOU LVI",
                Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                {
                    City = "Rychta a fara v Úvalně"
                },
                Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
                {
                    From = new DateTime(2024, 3, 28, 17, 0, 0),
                    To = new DateTime(2024, 3, 31, 13, 0, 0)
                },
                Races = new List<Entities.Actions.CreateActionInternalStorageRequest.RaceDto> {
                    new Entities.Actions.CreateActionInternalStorageRequest.RaceDto
                    {
                        Name = "Dogtrekking",
                        EnteringFrom = new DateTime(2024, 3, 28, 17, 0, 0),
                        EnteringTo = new DateTime(2024, 4, 28, 17, 30, 0),
                        Begin = new DateTime(2024, 3, 29, 07, 0, 0),
                        Limits = new Entities.Actions.CreateActionInternalStorageRequest.LimitsDto
                        {
                            WithPets = true,
                            MinimalAgeOfRacerInDayes = 0,
                            MinimalAgeOfThePetInDayes = 18 * 30,
                        },
                        Categories = new List<Entities.Actions.CreateActionInternalStorageRequest.CategoryDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Name = "DTW1",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new RacerDto { 
                                        FirstName = "Nikol", 
                                        LastName = "Hamáková", 
                                        Start = start,
                                        Finish = start.AddHours(12).AddMinutes(37)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Karolína", 
                                        LastName = "Ježovičová", 
                                        Start = start,
                                        Finish = start.AddHours(13).AddMinutes(02)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Anna Marie", 
                                        LastName = "Cudráková", 
                                        Start = start,
                                        Finish = start.AddHours(13).AddMinutes(18)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Iveta", 
                                        LastName = "Hajlichová", 
                                        Start = start,
                                        Finish = start.AddHours(13).AddMinutes(18)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Kristýna", 
                                        LastName = "Lédlová", 
                                        Start = start,
                                        Finish = start.AddHours(14).AddMinutes(44)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Klára", 
                                        LastName = "Dolečková", 
                                        Start = start,
                                        Finish = start.AddHours(17).AddMinutes(59)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Eliška", 
                                        LastName = "Drugdová", 
                                        Start = start,
                                        Finish = start.AddHours(18).AddMinutes(19)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Luisa", 
                                        LastName = "Wáwrová", 
                                        Start = start,
                                        Finish = start.AddHours(18).AddMinutes(58)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Barbora", 
                                        LastName = "Šonská", 
                                        Start = start,
                                        Finish = start.AddHours(21).AddMinutes(33)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Nela", 
                                        LastName = "Jandeková", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(09)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Naty", 
                                        LastName = "Dvořáková", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(26)
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Name = "DTM1",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new RacerDto
                                    {
                                        FirstName = "Robert", 
                                        LastName = "Šotkovský", 
                                        Start = start,
                                        Finish = start.AddHours(9).AddMinutes(15)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Marek", 
                                        LastName = "Fukala", 
                                        Start = start,
                                        Finish = start.AddHours(9).AddMinutes(51)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Tomáš", 
                                        LastName = "Tryzna", 
                                        Start = start,
                                        Finish = start.AddHours(10).AddMinutes(32)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Lukáš", 
                                        LastName = "Byrtus", 
                                        Start = start,
                                        Finish = start.AddHours(10).AddMinutes(50)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Michal", 
                                        LastName = "Koplík", 
                                        Start = start,
                                        Finish = start.AddHours(13).AddMinutes(18)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Vojtěch", 
                                        LastName = "Rečka", 
                                        Start = start,
                                        Finish = start.AddHours(15).AddMinutes(33)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Petr", 
                                        LastName = "Fuk", 
                                        Start = start,
                                        Finish = start.AddHours(16).AddMinutes(28)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jiří", 
                                        LastName = "Hartl", 
                                        Start = start,
                                        Finish = start.AddHours(21).AddMinutes(40)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Vojtěch", 
                                        LastName = "Adámek", 
                                        Start = start,
                                        Finish = start.AddHours(32).AddMinutes(07)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Šimon", 
                                        LastName = "Polášek", 
                                        Start = start,
                                        Finish = start.AddHours(39).AddMinutes(05)
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Name = "DTW2",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new RacerDto
                                    {
                                        FirstName = "Helena", 
                                        LastName = "Bayerová", 
                                        Start = start,
                                        Finish = start.AddHours(10).AddMinutes(45)
                                    },
                                    new RacerDto
                                    {
                                        LastName = "Urbánková",
                                        FirstName = "Helena",
                                        Start = start,
                                        Finish = start.AddHours(14).AddMinutes(41)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Kateřina", 
                                        LastName = "Knopová", 
                                        Start = start,
                                        Finish = start.AddHours(15).AddMinutes(01)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jana", 
                                        LastName = "Kalinová", 
                                        Start = start,
                                        Finish = start.AddHours(21).AddMinutes(40)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Zlatka", 
                                        LastName = "Hadravová", 
                                        Start = start,
                                        Finish = start.AddHours(16).AddMinutes(15)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Lenka", 
                                        LastName = "Čížková", 
                                        Start = start,
                                        Finish = start.AddHours(17).AddMinutes(53)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Hana", 
                                        LastName = "Němcová", 
                                        Start = start,
                                        Finish = start.AddHours(30).AddMinutes(03)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Simona", 
                                        LastName = "Mayerová", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(09)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Irena", 
                                        LastName = "Lojkásková", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(52)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Zuzana", 
                                        LastName = "Dluhošová", 
                                        Start = start,
                                        Finish = start.AddHours(32).AddMinutes(07)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jaroslava", 
                                        LastName = "Radová", 
                                        State = RaceState.DidNotFinished
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Name = "DTM2",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new RacerDto
                                    {
                                        FirstName = "Zbyněk", 
                                        LastName = "Adámek", 
                                        Start = start,
                                        Finish = start.AddHours(9).AddMinutes(13)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jaroslav", 
                                        LastName = "Chvalný", 
                                        Start = start,
                                        Finish = start.AddHours(12).AddMinutes(38)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Martin", 
                                        LastName = "Lédl", 
                                        Start = start,
                                        Finish = start.AddHours(14).AddMinutes(46)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jan", 
                                        LastName = "Šeda", 
                                        Start = start,
                                        Finish = start.AddHours(15).AddMinutes(50)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Radim", 
                                        LastName = "Suchý", 
                                        Start = start,
                                        Finish = start.AddHours(16).AddMinutes(59)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jiří", 
                                        LastName = "Egg", 
                                        Start = start,
                                        Finish = start.AddHours(17).AddMinutes(09)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Pavel", 
                                        LastName = "Školník", 
                                        Start = start,
                                        Finish = start.AddHours(18).AddMinutes(21)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Dalibor", 
                                        LastName = "Machů", 
                                        Start = start,
                                        Finish = start.AddHours(27).AddMinutes(03)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jan", 
                                        LastName = "Hirsch", 
                                        Start = start,
                                        Finish = start.AddHours(30).AddMinutes(14)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Libor", 
                                        LastName = "Bolehovský", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(09)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Michal", 
                                        LastName = "Vejtasa", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(19)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Petr", 
                                        LastName = "Dvořák", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(28)
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Roman", 
                                        LastName = "Polášek", 
                                        Start = start,
                                        Finish = start.AddHours(39).AddMinutes(05)
                                    }
                                }
                            }
                        }
                    }
                }
            }, CancellationToken.None))

            .AddDownAction(() => ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
