using static Storage.Entities.Actions.CreateActionInternalStorageRequest;

namespace Storage.Migrations._2024;

internal class _20240328_ZdeJsouLvi : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("e155cf24-1147-453a-8d08-0010a1dfceb7");
    protected Guid IdLong { get; init; } = Guid.Parse("33d23dca-4c48-428a-9cfd-fbc904d1fb18");
    protected Guid IdLongDtw1 { get; init; } = Guid.Parse("d12361b8-9d45-46a1-b3ed-9b744bd6ce6b");
    protected Guid IdLongDtm1 { get; init; } = Guid.Parse("bdda20ff-a97d-4de3-ac32-0ac23d4fce7f");
    protected Guid IdLongDtw2 { get; init; } = Guid.Parse("6b510642-0c64-4d63-874b-6e3f0fae9ad5");
    protected Guid IdLongDtm2 { get; init; } = Guid.Parse("89c34c52-23bf-4bd6-9550-ab93b7db99f3");
    protected Guid IdMid { get; init; } = Guid.Parse("58b23d8b-a700-4e33-9ac0-f957b3d1ee13");
    protected Guid IdMidDmw1 { get; init; } = Guid.Parse("abc137d7-5093-4495-9ad4-b13e473add93");
    protected Guid IdMidDmw2 { get; init; } = Guid.Parse("fc2819a3-7a95-48c3-b63f-76b478f08142");
    protected Guid IdMidDmm1 { get; init; } = Guid.Parse("73dfe2b0-f3ae-45ad-ac41-5bbc2921cdaa");
    protected Guid IdMidDmm2 { get; init; } = Guid.Parse("abbdb3a4-cd3a-4bac-9716-a0ee7a27c7d5");

    protected override string Name { get; init; } = nameof(_20240328_ZdeJsouLvi);

    public _20240328_ZdeJsouLvi(IServiceProvider serviceProvider) : base(serviceProvider) 
    {
        var start = new DateTime(2024, 3, 29, 09, 0, 0);

        this
            .AddUpAction(() => ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
            {
                Id = Id,
                Name = "ZDE JSOU LVI",
                Type = Constants.ActivityType.Dogtrekking,
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
                    new RaceDto
                    {
                        Id = IdLong,
                        Name = "Dogtrekking",
                        EnteringFrom = new DateTime(2024, 3, 28, 17, 0, 0),
                        EnteringTo = new DateTime(2024, 4, 28, 17, 30, 0),
                        Begin = new DateTime(2024, 3, 29, 07, 0, 0),
                        End = new DateTime(2024, 3, 31, 23, 59, 59),
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
                                Id = IdLongDtw1,
                                Name = "DTW1",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new RacerDto { 
                                        FirstName = "Nikol", 
                                        LastName = "Hamáková", 
                                        Start = start,
                                        Finish = start.AddHours(12).AddMinutes(37),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Argo",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Karolína", 
                                        LastName = "Ježovičová", 
                                        Start = start,
                                        Finish = start.AddHours(13).AddMinutes(02),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Beyond Forever Sailon Narmo",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Anna Marie", 
                                        LastName = "Cudráková", 
                                        Start = start,
                                        Finish = start.AddHours(13).AddMinutes(18),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Everest Mystery Arctic Devil",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Iveta", 
                                        LastName = "Hajlichová", 
                                        Start = start,
                                        Finish = start.AddHours(13).AddMinutes(18),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Black Symphony of Arctic",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Kristýna", 
                                        LastName = "Lédlová", 
                                        Start = start,
                                        Finish = start.AddHours(14).AddMinutes(44),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Rebell Rony",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Klára", 
                                        LastName = "Dolečková", 
                                        Start = start,
                                        Finish = start.AddHours(17).AddMinutes(59),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Lizy",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Eliška", 
                                        LastName = "Drugdová", 
                                        Start = start,
                                        Finish = start.AddHours(18).AddMinutes(19),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Goro",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Luisa", 
                                        LastName = "Wáwrová", 
                                        Start = start,
                                        Finish = start.AddHours(18).AddMinutes(58),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Femina Famosa Canis Mayrau",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Barbora", 
                                        LastName = "Šonská", 
                                        Start = start,
                                        Finish = start.AddHours(21).AddMinutes(33),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Cvrček Sullivan Dancing Warrior",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Nela", 
                                        LastName = "Jandeková", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(09),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Grey Hunter Miraja",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Naty", 
                                        LastName = "Dvořáková", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(26),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Miňonka",
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = IdLongDtm1,
                                Name = "DTM1",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new RacerDto
                                    {
                                        FirstName = "Robert", 
                                        LastName = "Šotkovský", 
                                        Start = start,
                                        Finish = start.AddHours(9).AddMinutes(15),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Delta",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Marek", 
                                        LastName = "Fukala", 
                                        Start = start,
                                        Finish = start.AddHours(9).AddMinutes(51),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Loki",
                                            },
                                            new PetDto
                                            {
                                                Name = "Mia",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Tomáš", 
                                        LastName = "Tryzna", 
                                        Start = start,
                                        Finish = start.AddHours(10).AddMinutes(32),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Summer",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Lukáš", 
                                        LastName = "Byrtus", 
                                        Start = start,
                                        Finish = start.AddHours(10).AddMinutes(50),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Fina Akpytora",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Michal", 
                                        LastName = "Koplík", 
                                        Start = start,
                                        Finish = start.AddHours(13).AddMinutes(18),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Bruno",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Vojtěch", 
                                        LastName = "Rečka", 
                                        Start = start,
                                        Finish = start.AddHours(15).AddMinutes(33),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Heidy Grey Wolf",
                                            },
                                            new PetDto
                                            {
                                                Name = "Waffle Wild Freespirit leveris",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Petr", 
                                        LastName = "Fuk", 
                                        Start = start,
                                        Finish = start.AddHours(16).AddMinutes(28),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Severus",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jiří", 
                                        LastName = "Hartl", 
                                        Start = start,
                                        Finish = start.AddHours(21).AddMinutes(40),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Loki",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Vojtěch", 
                                        LastName = "Adámek", 
                                        Start = start,
                                        Finish = start.AddHours(32).AddMinutes(07),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Flip Krosandra",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Šimon", 
                                        LastName = "Polášek", 
                                        Start = start,
                                        Finish = start.AddHours(39).AddMinutes(05),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Apu",
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = IdLongDtw2,
                                Name = "DTW2",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new RacerDto
                                    {
                                        FirstName = "Helena", 
                                        LastName = "Bayerová", 
                                        Start = start,
                                        Finish = start.AddHours(10).AddMinutes(45),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Darko",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        LastName = "Urbánková",
                                        FirstName = "Helena",
                                        Start = start,
                                        Finish = start.AddHours(14).AddMinutes(41),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Pax Arqeva",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Kateřina", 
                                        LastName = "Knopová", 
                                        Start = start,
                                        Finish = start.AddHours(15).AddMinutes(01),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Ponny",
                                            },
                                            new PetDto
                                            {
                                                Name = "Horalka",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Zlatka",
                                        LastName = "Hadravová",
                                        Start = start,
                                        Finish = start.AddHours(16).AddMinutes(15),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Cira",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Lenka",
                                        LastName = "Čížková",
                                        Start = start,
                                        Finish = start.AddHours(17).AddMinutes(53),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Burák",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jana", 
                                        LastName = "Kalinová", 
                                        Start = start,
                                        Finish = start.AddHours(21).AddMinutes(40),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Aimy z Archy",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Hana", 
                                        LastName = "Němcová", 
                                        Start = start,
                                        Finish = start.AddHours(30).AddMinutes(03),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Rocky",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Simona", 
                                        LastName = "Mayerová", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(09),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Airin z Litavské kotliny",
                                            },
                                            new PetDto
                                            {
                                                Name = "Alex",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Irena", 
                                        LastName = "Lojkásková", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(52),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Skipes",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Zuzana", 
                                        LastName = "Dluhošová", 
                                        Start = start,
                                        Finish = start.AddHours(32).AddMinutes(07),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Goyathlay Austrian Wolf",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jaroslava", 
                                        LastName = "Radová", 
                                        State = RaceState.DidNotFinished,
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Baltazar Vločka z Beskyd",
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = IdLongDtm2,
                                Name = "DTM2",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new RacerDto
                                    {
                                        FirstName = "Zbyněk", 
                                        LastName = "Adámek", 
                                        Start = start,
                                        Finish = start.AddHours(9).AddMinutes(13),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Neo",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jaroslav", 
                                        LastName = "Chvalný", 
                                        Start = start,
                                        Finish = start.AddHours(12).AddMinutes(38),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Max",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Martin", 
                                        LastName = "Lédl", 
                                        Start = start,
                                        Finish = start.AddHours(14).AddMinutes(46),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Arnold",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jan", 
                                        LastName = "Šeda", 
                                        Start = start,
                                        Finish = start.AddHours(15).AddMinutes(50),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Hick Sideric Miks",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Radim", 
                                        LastName = "Suchý", 
                                        Start = start,
                                        Finish = start.AddHours(16).AddMinutes(59),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Gina",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jiří", 
                                        LastName = "Egg", 
                                        Start = start,
                                        Finish = start.AddHours(17).AddMinutes(09),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Isildur",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Pavel", 
                                        LastName = "Školník", 
                                        Start = start,
                                        Finish = start.AddHours(18).AddMinutes(21),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Airy",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Dalibor", 
                                        LastName = "Machů", 
                                        Start = start,
                                        Finish = start.AddHours(27).AddMinutes(03),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Tim",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Jan", 
                                        LastName = "Hirsch", 
                                        Start = start,
                                        Finish = start.AddHours(30).AddMinutes(14),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Geena",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Libor", 
                                        LastName = "Bolehovský", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(09),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Angie Akruko",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Michal", 
                                        LastName = "Vejtasa", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(19),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Dellin",
                                            },
                                            new PetDto
                                            {
                                                Name = "Karlička",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Petr", 
                                        LastName = "Dvořák", 
                                        Start = start,
                                        Finish = start.AddHours(31).AddMinutes(28),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Perníček",
                                            }
                                        }
                                    },
                                    new RacerDto
                                    {
                                        FirstName = "Roman", 
                                        LastName = "Polášek", 
                                        Start = start,
                                        Finish = start.AddHours(39).AddMinutes(05),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Pandur",
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new RaceDto
                    {
                        Id = IdMid,
                        Name = "DogMid",
                        Categories = new List<CategoryDto>
                        {
                            new CategoryDto
                            {
                                Id = IdMidDmw1,
                                Name = "DMW1",
                                Racers = new List<RacerDto>
                                { 
                                    new RacerDto
                                    {
                                        FirstName = "dmw1_tester", 
                                        LastName = "dmw1_Tester", 
                                        Start = start,
                                        Finish = start.AddHours(21).AddMinutes(40),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Aimy z Archy",
                                            }
                                        }
                                    },
                                }
                            },
                            new CategoryDto
                            {
                                Id = IdMidDmw2,
                                Name = "DMW2",
                                Racers = new List<RacerDto>
                                { 
                                    new RacerDto
                                    {
                                        FirstName = "dmw2_tester", 
                                        LastName = "dmw2_Tester", 
                                        Start = start,
                                        Finish = start.AddHours(10).AddMinutes(45),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Darko",
                                            }
                                        }
                                    },
                                }
                            },
                            new CategoryDto
                            {
                                Id = IdMidDmm1,
                                Name = "DMM1",
                                Racers = new List<RacerDto>
                                { 
                                    new RacerDto
                                    {
                                        FirstName = "dmm1_tester", 
                                        LastName = "dmm1_Tester", 
                                        Start = start,
                                        Finish = start.AddHours(9).AddMinutes(15),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Delta",
                                            }
                                        }
                                    },
                                }
                            },
                            new CategoryDto
                            {
                                Id = IdMidDmm2,
                                Name = "DMM2",
                                Racers = new List<RacerDto>
                                { 
                                    new RacerDto
                                    {
                                        FirstName = "dmm2_tester", 
                                        LastName = "dmm2_Tester", 
                                        Start = start,
                                        Finish = start.AddHours(9).AddMinutes(13),
                                        Pets = new List<PetDto>
                                        {
                                            new PetDto
                                            {
                                                Name = "Neo",
                                            }
                                        }
                                    },
                                }
                            }
                        }
                    }
                }
            }, CancellationToken.None))

            .AddDownAction(() => ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
