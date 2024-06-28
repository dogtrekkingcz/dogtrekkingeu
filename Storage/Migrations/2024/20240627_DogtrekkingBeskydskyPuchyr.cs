using System.Collections.Generic;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Storage.Migrations._2024;

internal class _20240627_DogtrekkingBeskydskyPuchyr : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("2d87002d-611e-4130-99d9-564b7d4d6fb5");
    protected override string Name { get; init; } = nameof(_20240627_DogtrekkingBeskydskyPuchyr);


    public _20240627_DogtrekkingBeskydskyPuchyr(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this
            .AddUpAction(() => ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
            {
                Id = Id,
                Name = "Dogtrekking Beskydský puchýř",
                TypeId = Constants.ActivityType.Dogtrekking,
                ResultsCanEdit = new List<Guid> { Constants.Roles.InternalAdministrator.GUID },
                CompetitorsCanEdit = new List<Guid> { Constants.Roles.InternalAdministrator.GUID },
                ActionCanEdit = new List<Guid> { Constants.Roles.InternalAdministrator.GUID },
                Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                {
                    City = "Palkovice",
                    Country = "Czech Republic",
                    Street = "Rekreační středisko Palkovické Hůrky, Palkovice 226",
                    ZipCode = "739 41"
                },
                Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
                {
                    From = new DateTime(2024, 6, 27, 17, 0, 0),
                    To = new DateTime(2024, 6, 30, 13, 0, 0)
                },
                Www = "https://beskydskaliska.webnode.cz/",
                Races = new List<Entities.Actions.CreateActionInternalStorageRequest.RaceDto>
                {
                    new Entities.Actions.CreateActionInternalStorageRequest.RaceDto
                    {
                        Id = Guid.Parse("2b34bf0e-800a-46e3-aa50-4820d4788481"),
                        Name = "Dogtrekking",
                        Distance = 93,
                        Incline = 2471,
                        Begin = new DateTime(2024, 6, 28, 5, 0, 0),
                        End = new DateTime(2024, 6, 30, 10, 0, 0),
                        Checkpoints = new List<Entities.Actions.CreateActionInternalStorageRequest.CheckpointDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CheckpointDto
                            {
                                Id = Guid.Parse("1882514b-4bcf-4232-96e6-153f4ea1e363"),
                                Name = "Živá"
                            }
                        },
                        Categories = new List<Entities.Actions.CreateActionInternalStorageRequest.CategoryDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("42719606-a893-4cf2-8e2e-98ad19dbc648"),
                                Name = "DTW 1",
                                Description = "Ženy do 35 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Veronika",
                                        LastName = "Fránková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Ostravice 817",
                                            City = "",
                                            ZipCode = ""
                                        },
                                        Phone = "739167676",
                                        Email = "v.erda.frankova@gmail.com",
                                        Start = new DateTime(2024, 6, 28, 5, 29, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Belatrix Chlupatý nesmysl",
                                                Breed = "Chodský pes",
                                                Birthday = new DateTime(2022, 5, 27),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Nikol",
                                        LastName = "Hamáková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Medkovy Kopce 18",
                                            City = "",
                                            ZipCode = ""
                                        },
                                        Phone = "602569924",
                                        Email = "nikol-hamakova@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 5, 51, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Argo",
                                                Breed = "Kříženec kólie",
                                                Birthday = new DateTime(2020, 6, 3),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kristýna",
                                        LastName = "Lédlová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Blatno 57",
                                            City = "Hlinsko",
                                            ZipCode = ""
                                        },
                                        Phone = "702114351",
                                        Email = "kristyna.ledlova@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 5, 26, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Rebell Rony",
                                                Breed = "SH",
                                                Birthday = new DateTime(2015, 6, 3),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Daniela",
                                        LastName = "Petrů",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Za Školou 112 /19",
                                            City = "Prerov IV-Kozlovice",
                                            ZipCode = "75002"
                                        },
                                        Phone = "776391059",
                                        Email = "da.petru235@gmail.com",
                                        Start = new DateTime(2024, 6, 28, 5, 41, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Pazienza Amore Puffo B. G's Phantasia (Šmoulinka)",
                                                Breed = "Sibiřský husky",
                                                Birthday = new DateTime(2021, 9, 23),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Eliška",
                                        LastName = "Vasilenková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Chotevice 135",
                                            City = "",
                                            ZipCode = "54376"
                                        },
                                        Phone = "731464733",
                                        Email = "elissaen@gmail.com",
                                        Start = new DateTime(2024, 6, 28, 6, 41, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Haku",
                                                Breed = "Holandský ovčák",
                                                Birthday = new DateTime(2019, 1, 1),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Luisa",
                                        LastName = "Wáwrová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Chovatelská 288",
                                            City = "Praha 5 Lipence",
                                            ZipCode = "155 31"
                                        },
                                        Phone = "607750817",
                                        Email = "dobrodruzka@atlas.cz",
                                        Start = new DateTime(2024, 6, 28, 7, 0, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Femina Famosa Canis Mayrau",
                                                Breed = "Beauceron",
                                                Birthday = new DateTime(2019, 5, 11),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("9e62f74b-008f-4799-8538-bbb34a48c637"),
                                Name = "DTW 2",
                                Description = "Ženy nad 35 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Milena",
                                        LastName = "Bauerová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Nádražní 908",
                                            City = "Bystřice nad Pernštejnem",
                                            ZipCode = "593 01"
                                        },
                                        Phone = "731491945",
                                        Email = "mila.bauerova@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 5, 35, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Isla Bonita Jednička",
                                                Breed = "Siberian husky",
                                                Birthday = new DateTime(2022, 3, 10),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Helena",
                                        LastName = "Bayerová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "K Lesnu 193",
                                            City = "Lhota",
                                            ZipCode = "27714"
                                        },
                                        Phone = "604711491",
                                        Email = "bayerovahelena21@gmail.com",
                                        Start = new DateTime(2024, 6, 28, 5, 0, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Darko",
                                                Breed = "Alaskan",
                                                Birthday = new DateTime(2019, 8, 7),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lenka",
                                        LastName = "Čiperová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Korno 41",
                                            City = "",
                                            ZipCode = ""
                                        },
                                        Phone = "606854122",
                                        Email = "lenkaciperova@seznam.cz",
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.NotStarted,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Myška",
                                                Breed = "šiperka",
                                                Birthday = new DateTime(2022, 4, 4),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Zlatka",
                                        LastName = "Hadravová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Přátelství 56",
                                            City = "Praha 22",
                                            ZipCode = ""
                                        },
                                        Phone = "602568001",
                                        Email = "zlatuska.h@gmail.com",
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.NotStarted,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Cira",
                                                Breed = "Black Candy Wookieedog",
                                                Birthday = new DateTime(2018, 12, 16),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kateřina",
                                        LastName = "Knopová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "U Jízdárny 999/14",
                                            City = "Praha-Dolní Chabry",
                                            ZipCode = "184 00"
                                        },
                                        Phone = "737071489",
                                        Email = "knopovak@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 5, 31, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Ponny",
                                                Breed = "Bígl",
                                                Birthday = new DateTime(2017, 8, 30),
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Horalka",
                                                Breed = "Bígl",
                                                Birthday = new DateTime(2017, 10, 14),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Romana",
                                        LastName = "Kratochvílová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Drahlov 358",
                                            City = "Charváty",
                                            ZipCode = "783 75"
                                        },
                                        Phone = "605153777",
                                        Email = "romanakratochvil@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 5, 26, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Babette Vardarianna",
                                                Breed = "Bourbonský ohař krátkosrstý",
                                                Birthday = new DateTime(2021, 7, 18),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Renáta",
                                        LastName = "Libová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Okružní 220/25A",
                                            City = "Krnov",
                                            ZipCode = "79401"
                                        },
                                        Phone = "608865496",
                                        Email = "rlibova@gmail.com",
                                        Start = new DateTime(2024, 6, 28, 5, 25, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "\"Eddie\" Expert Belrott",
                                                Breed = "BOM",
                                                Birthday = new DateTime(2020, 4, 27),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Marie",
                                        LastName = "Payne",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Budečská 39",
                                            City = "Praha 2",
                                            ZipCode = ""
                                        },
                                        Phone = "732182191",
                                        Email = "mariepayne@atlas.cz",
                                        Start = new DateTime(2024, 6, 28, 6, 37, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Frída",
                                                Breed = "ČSV",
                                                Birthday = new DateTime(2017, 1, 4),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jaroslava",
                                        LastName = "Radová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Košátky 11",
                                            City = "Košátky",
                                            ZipCode = "29479"
                                        },
                                        Phone = "605973600",
                                        Email = "barbanekx@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 5, 27, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Baltazar Vločka z Beskyd",
                                                Breed = "Samojed",
                                                Birthday = new DateTime(2021, 12, 9),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("75d84ef9-a9fe-49bf-9d61-f2c2c0bcd4ef"),
                                Name = "DTM 1",
                                Description = "Muži do 40 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Roman",
                                        LastName = "Brabec",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Rabštejnská Lhota 126",
                                            City = "Chrudim",
                                            ZipCode = "53701"
                                        },
                                        Phone = "722938552",
                                        Email = "Brabec.Roman@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 6, 37, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Corin",
                                                Breed = "ČSV",
                                                Birthday = new DateTime(2013, 1, 1),
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Joe",
                                                Breed = "ČSV",
                                                Birthday = new DateTime(2017, 1, 1),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Michal",
                                        LastName = "Durišík",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Okružní 238/31a",
                                            City = "Krnov",
                                            ZipCode = "79401"
                                        },
                                        Phone = "774515321",
                                        Email = "mdurisik@centrum.cz",
                                        Start = new DateTime(2024, 6, 28, 5, 25, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Andromeda od Pstruhové vody (Fany)",
                                                Breed = "Belgický ovčák malinois",
                                                Birthday = new DateTime(2022, 1, 2),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Marek",
                                        LastName = "Fukala",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Stonava 454",
                                            City = "Stonava",
                                            ZipCode = ""
                                        },
                                        Phone = "731975208",
                                        Email = "Mfaurkeakla@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 6, 48, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "MIA",
                                                Breed = "Sibiřský husky",
                                                Birthday = new DateTime(2021, 12, 17),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jiří",
                                        LastName = "Tyl",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Litohlavy 141",
                                            City = "Litohlavy",
                                            ZipCode = ""
                                        },
                                        Phone = "723509553",
                                        Email = "ji.tyl@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 5, 29, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Andy",
                                                Breed = "Chodský pes",
                                                Birthday = new DateTime(2021, 4, 24),
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Bella Chlupatý nesmysl",
                                                Breed = "Chodský pes",
                                                Birthday = new DateTime(2021, 4, 24),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Vojtěch",
                                        LastName = "Rečka",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Lubina 338",
                                            City = "Kopřivnice",
                                            ZipCode = ""
                                        },
                                        Phone = "606822852",
                                        Email = "reckav@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 5, 26, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Heidi Grey Wolf",
                                                Breed = "SH",
                                                Birthday = new DateTime(2022, 1, 6),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lukáš",
                                        LastName = "Vinklárek",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Za Školou 112 /19",
                                            City = "Prerov IV-Kozlovice",
                                            ZipCode = "75002"
                                        },
                                        Phone = "604654504",
                                        Email = "vinkllukas@gmail.com",
                                        Start = new DateTime(2024, 6, 28, 5, 41, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "U Are Jerry B. G's Phantasia",
                                                Breed = "Sibiřský husky",
                                                Birthday = new DateTime(2022, 10, 1),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("20c728ed-3312-46b5-a608-5ef402445005"),
                                Name = "DTM 2",
                                Description = "Muži nad 40 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Vít",
                                        LastName = "Bauer",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Nádražní 908",
                                            City = "Bystřice nad Pernštejnem",
                                            ZipCode = "593 01"
                                        },
                                        Phone = "731491938",
                                        Email = "vitbauer@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 5, 35, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Honey Jednička",
                                                Breed = "Siberian husky",
                                                Birthday = new DateTime(2021, 2, 17),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jaroslav",
                                        LastName = "Dustir",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Maxima Gorkého 866)10",
                                            City = "Vejprty",
                                            ZipCode = null
                                        },
                                        Phone = "724086237",
                                        Email = "jdustir@gmail.com",
                                        Start = new DateTime(2024, 6, 28, 5, 1, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Goa Kronebox",
                                                Breed = "německý boxer",
                                                Birthday = new DateTime(2018, 7, 19),
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Grand Merci Almandinaks",
                                                Breed = "německý boxer",
                                                Birthday = new DateTime(2019, 2, 28),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jiří",
                                        LastName = "Egg",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Hrubčice 149",
                                            City = null,
                                            ZipCode = null
                                        },
                                        Phone = "770158635",
                                        Email = "egg.j@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 5, 42, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Isildur",
                                                Breed = "Bílý švýcarský ovčák",
                                                Birthday = new DateTime(2021, 1, 6),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Roman",
                                        LastName = "Polášek",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Korno 41",
                                            City = null,
                                            ZipCode = null
                                        },
                                        Phone = "732215641",
                                        Email = "romanpolasek75@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 6, 37, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Apu",
                                                Breed = "šiperka",
                                                Birthday = new DateTime(2016, 4, 16),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jan",
                                        LastName = "Šeda",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Kfely 68",
                                            City = "Ostrov",
                                            ZipCode = "36301"
                                        },
                                        Phone = "602582404",
                                        Email = "janseda@mybox.cz",
                                        Start = new DateTime(2024, 6, 28, 6, 5, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Hick Sideric Miks",
                                                Breed = "Hw",
                                                Birthday = new DateTime(2014, 6, 21),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Michal",
                                        LastName = "Vejtasa",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Vysokomýtská 447",
                                            City = "Holice",
                                            ZipCode = "53401"
                                        },
                                        Phone = "602730321",
                                        Email = "michal.vejtasa@seznam.cz",
                                        Start = new DateTime(2024, 6, 28, 5, 27, 0),
                                        State = Entities.Actions.CreateActionInternalStorageRequest.RaceState.Started,
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Delinka",
                                                Breed = "SH",
                                                Birthday = new DateTime(2015, 1, 1),
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Karlička",
                                                Breed = "SH",
                                                Birthday = new DateTime(2019, 1, 1),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Entities.Actions.CreateActionInternalStorageRequest.RaceDto
                    {
                        Id = Guid.Parse("8baddf26-ad2e-46c5-91ea-f4483cc18bcc"),
                        Name = "Dogmid",
                        Distance = 45 ,
                        Incline = 890,
                        Begin = new DateTime(2024, 6, 29, 6, 0, 0),
                        End = new DateTime(2024, 6, 30, 10, 0, 0),
                        Checkpoints = new List<Entities.Actions.CreateActionInternalStorageRequest.CheckpointDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CheckpointDto
                            {
                                Id = Guid.Parse("a066625a-f3d5-4b19-ae56-5579b2e157d6"),
                                Name = "Živá"
                            }
                        },
                        Categories = new List<Entities.Actions.CreateActionInternalStorageRequest.CategoryDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("aeaabd9c-30db-4f11-952f-c2aeebe990ca"),
                                Name = "DMW 1",
                                Description = "Ženy do 35 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Silvie",
                                        LastName = "Beránková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Čapkova 689",
                                            City = "Třinec",
                                            ZipCode = "739 61"
                                        },
                                        Phone = "733477886",
                                        Email = "silvieberankova1993@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Hodor Aussieland",
                                                Breed = "Australský ovčák",
                                                Birthday = new DateTime(2019, 8, 16),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Eva",
                                        LastName = "Čechová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Dráhy 173",
                                            City = "Frenštát pod Radhoštěm",
                                            ZipCode = ""
                                        },
                                        Phone = "724515655",
                                        Email = "evca.cechova@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Cassius Clay Strážce Walhaly",
                                                Breed = "Čsv",
                                                Birthday = new DateTime(2018, 11, 3),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Veronika",
                                        LastName = "Holá",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Ulička 2",
                                            City = "Brno",
                                            ZipCode = "62300"
                                        },
                                        Phone = "776170159",
                                        Email = "veruhol1@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Marvin",
                                                Breed = "Portugalský vodní pes",
                                                Birthday = new DateTime(2021, 1, 23),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Miriam",
                                        LastName = "Hrivňáková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Broskyňová 62",
                                            City = "Malinovo",
                                            ZipCode = "90045"
                                        },
                                        Phone = "0917916844",
                                        Email = "miriam.hrivnakova@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Barbara",
                                                Breed = "APBT",
                                                Birthday = new DateTime(2022, 1, 21),
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Ali",
                                                Breed = "Americký pitbullterrier",
                                                Birthday = new DateTime(2022, 1, 21),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Andrea",
                                        LastName = "Kiculisová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Hostěrádky Rešov 319",
                                            City = "",
                                            ZipCode = "68352"
                                        },
                                        Phone = "721701403",
                                        Email = "andrea.kiculisova@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Teo",
                                                Breed = "Zlatý Retrívr",
                                                Birthday = new DateTime(2021, 3, 8),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Iveta",
                                        LastName = "Landová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Skelná 67",
                                            City = "Jablonec nad Nisou",
                                            ZipCode = ""
                                        },
                                        Phone = "727950997",
                                        Email = "landova.iveta@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Zack",
                                                Breed = "Sibiřský husky",
                                                Birthday = new DateTime(2020, 2, 20),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Tereza",
                                        LastName = "Mokrá",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "",
                                            City = "Spešov",
                                            ZipCode = ""
                                        },
                                        Phone = "728310144",
                                        Email = "alveta@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Hak",
                                                Breed = "parson russell terrier",
                                                Birthday = new DateTime(2017, 8, 6),
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Henry",
                                                Breed = "parson russell terrier",
                                                Birthday = new DateTime(2019, 12, 17),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Anna",
                                        LastName = "Soukupová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Krušinova 140/1",
                                            City = "Brno",
                                            ZipCode = "644 00"
                                        },
                                        Phone = "777433575",
                                        Email = "anna.foralova@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Rufi",
                                                Breed = "Border teriér",
                                                Birthday = new DateTime(2016, 10, 1), // Assuming October as the month
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Collin (Fleret Moravia)",
                                                Breed = "Border teriér",
                                                Birthday = new DateTime(2022, 8, 1), // Assuming August as the month
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },

                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Magdaléna",
                                        LastName = "Wojatschke",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "17.listopadu 79",
                                            City = "Frýdek-Místek",
                                            ZipCode = "73801"
                                        },
                                        Phone = "604701580",
                                        Email = "magda.wojatschke@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Akim",
                                                Breed = "Miniaturní americký ovčák",
                                                Birthday = new DateTime(2021, 1, 1), // Assuming January as the birthday month and day due to lack of specific date
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("20bc0735-ac89-4b18-8601-cac457bdcce2"),
                                Name = "DMW 2",
                                Description = "Ženy nad 35 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kateřina",
                                        LastName = "Adamíková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Dr. Martínka 1419/16",
                                            City = "Ostrava"
                                        },
                                        Phone = "603536793",
                                        Email = "katerina.adamikova@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Izzie",
                                                Breed = "AUO",
                                                Birthday = new DateTime(2022, 7, 2),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Hana",
                                        LastName = "Bartoňková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Opavská 197",
                                            City = "Hradec nad Moravicí",
                                            ZipCode = "74741"
                                        },
                                        Phone = "602837093",
                                        Email = "Barty.1@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Cody",
                                                Breed = "Alaskan",
                                                Birthday = new DateTime(2019, 8, 22),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Marcela",
                                        LastName = "Bezděková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Polská 1184/21",
                                            City = "Děčín"
                                        },
                                        Phone = "731015992",
                                        Email = "marcela.bezdekova@email.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Nyx",
                                                Breed = "německý ohař krátkosrstý",
                                                Birthday = new DateTime(2020, 4, 4),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Marie",
                                        LastName = "Brožová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Čechova 9",
                                            City = "Velké Meziříčí"
                                        },
                                        Phone = "777768058",
                                        Email = "dmajka@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Dacota Ligoretto",
                                                Breed = "Bearded collie",
                                                Birthday = new DateTime(2015, 5, 29),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lenka",
                                        LastName = "Čápová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Železniční 171/12",
                                            City = "Liberec",
                                            ZipCode = "46001"
                                        },
                                        Phone = "724502477",
                                        Email = "lena.cap@centrum.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Devon Di-Le-Grej",
                                                Breed = "český horský pes",
                                                Birthday = new DateTime(2020, 9, 15),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Radka",
                                        LastName = "Černá",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Uhlířov 37",
                                            City = "Melč",
                                            ZipCode = "74784"
                                        },
                                        Phone = "734697350",
                                        Email = "cer02hr@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Shelby Vlčí tlapka",
                                                Breed = "ČSV",
                                                Birthday = new DateTime(2022, 5, 14),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Mirka",
                                        LastName = "Davidová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Jaroslavice 56",
                                            City = "Zlín",
                                            ZipCode = "76001"
                                        },
                                        Phone = "731567248",
                                        Email = "davidova11m@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Torin",
                                                Breed = "ADT",
                                                Birthday = new DateTime(2019, 1, 1),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jiřina",
                                        LastName = "Jelenová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Vrbka 21",
                                            City = "Služovice",
                                            ZipCode = "74728"
                                        },
                                        Phone = "606774107",
                                        Email = "jijelenova@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Kilián",
                                                Breed = "BOM",
                                                Birthday = new DateTime(2021, 4, 25),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Renáta",
                                        LastName = "Macková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Ondrášov 38",
                                            City = "Moravský Beroun"
                                        },
                                        Phone = "776128869",
                                        Email = "hanackymushersclub@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Baldr",
                                                Breed = "SH",
                                                Birthday = new DateTime(2020, 1, 1),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Irena",
                                        LastName = "Málková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Kamínky 14",
                                            City = "Brno",
                                            ZipCode = "63400"
                                        },
                                        Phone = "731526599",
                                        Email = "irena.malkova@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Artuš",
                                                Breed = "border kolie",
                                                Birthday = new DateTime(2019, 2, 24),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Magda",
                                        LastName = "Maralíková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Kunčice p.O. 507",
                                            City = "Kunčice",
                                            ZipCode = "73912"
                                        },
                                        Phone = "732750864",
                                        Email = "maralikova.magda@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Žofie",
                                                Breed = "Všehochuť",
                                                Birthday = new DateTime(2016, 12, 1),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kateřina",
                                        LastName = "Radvanská",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Pěnčín 128",
                                            City = "Laškov",
                                            ZipCode = "79857"
                                        },
                                        Phone = "737767962",
                                        Email = "radvanskakat@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Edith Yabalute",
                                                Breed = "BOM",
                                                Birthday = new DateTime(2019, 9, 9),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Ewa",
                                        LastName = "Skubida",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "ul. KEN 6/19",
                                            City = "Stalowa Wola",
                                            Country = "Poland"
                                        },
                                        Phone = "+48600808474",
                                        Email = "bakti@wp.pl",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Erka",
                                                Breed = "Okratek Australsky",
                                                Birthday = new DateTime(2016, 8, 22),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Ladislava",
                                        LastName = "Smékalová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Antonína Klobouka 672",
                                            City = "Velký Týnec",
                                            ZipCode = "78372"
                                        },
                                        Phone = "777076962",
                                        Email = "l.smekalova@centrum.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Annie",
                                                Breed = "AUO",
                                                Birthday = new DateTime(2021, 3, 19),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Petra",
                                        LastName = "Staňková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Olšovec 82"
                                        },
                                        Phone = "739432551",
                                        Email = "stankovapettra@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Calypso Northern Shadows",
                                                Breed = "Aljašský malamut",
                                                Birthday = new DateTime(2018, 7, 28),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Eva",
                                        LastName = "Šišoláková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            City = "Kunštát"
                                        },
                                        Phone = "773232225",
                                        Email = "eva.sisolakova@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Koda",
                                                Breed = "Ohař X podenco",
                                                Birthday = new DateTime(2020, 7, 9),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Petra",
                                        LastName = "Škrbelová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Handkeho 755/1c",
                                            City = "Olomouc",
                                            ZipCode = "77900"
                                        },
                                        Phone = "728748826",
                                        Email = "petraskrbelova@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Orca Navarrewolf",
                                                Breed = "Československý vlčák",
                                                Birthday = new DateTime(2022, 6, 7),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Markéta",
                                        LastName = "Vítková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Býkovice 84",
                                            ZipCode = "679 71"
                                        },
                                        Phone = "601367251",
                                        Email = "marky.vitkova@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Pazienza Amore Gas B.G’s Phantasia",
                                                Breed = "SH",
                                                Birthday = new DateTime(2021, 9, 23),
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "I’m Idaho B.G’s Phantasia",
                                                Breed = "SH",
                                                Birthday = new DateTime(2019, 3, 27),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kateřina",
                                        LastName = "Votřelová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Obořice 5",
                                            City = "Nasavrky",
                                            ZipCode = "538 25"
                                        },
                                        Phone = "774000553",
                                        Email = "kavot@centrum.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Bonnie",
                                                Breed = "trpasličí pinč",
                                                Birthday = new DateTime(2022, 9, 17),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jana",
                                        LastName = "Wičarová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Lieberzeitova 25a",
                                            City = "Brno"
                                        },
                                        Phone = "604328385",
                                        Email = "janawicarova@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Bárt",
                                                Breed = "BOC",
                                                Birthday = new DateTime(2013, 5, 5),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("57acdf69-a6f7-49b7-a665-3c3b217a8423"),
                                Name = "DMM 1",
                                Description = "Muži do 40 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Gabriel",
                                        LastName = "Bílý",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Oldřichovice 54",
                                            City = "Oldřichovice",
                                            ZipCode = "76361"
                                        },
                                        Phone = "+420603555122",
                                        Email = "gabriel.bily@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Sky",
                                                Breed = "Sibiřský husky",
                                                Birthday = new DateTime(2021, 10, 3),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lukáš",
                                        LastName = "Družba",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Vratimov",
                                            City = "Vratimov",
                                            ZipCode = ""  // Assuming no postal code was provided.
                                        },
                                        Phone = "728824998",
                                        Email = "lukas.druzba@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Aisha Dogcentrum's Guardian",
                                                Breed = "Beauceron",
                                                Birthday = new DateTime(2019, 1, 12),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Petr",
                                        LastName = "Holeksa",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Kosmonautů 33",
                                            City = "Havířov",
                                            ZipCode = ""
                                        },
                                        Phone = "737778343",
                                        Email = "petrholeksa@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Argo Kutnohorský groš",
                                                Breed = "Český horský pes",
                                                Birthday = new DateTime(2019, 6, 7),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jan",
                                        LastName = "Mokrý",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Spešov",
                                            City = "Spešov",
                                            ZipCode = ""  // Assuming no postal code was provided.
                                        },
                                        Phone = "725117615",
                                        Email = "jan.mokry@email.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Fira",
                                                Breed = "Jagdterier",
                                                Birthday = new DateTime(2020, 5, 15),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jakub",
                                        LastName = "Staněk",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Olšovec 82",
                                            City = "Olšovec",
                                            ZipCode = ""
                                        },
                                        Phone = "739432551",
                                        Email = "stankovapettra@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Arny Ledové tlapky naděje",
                                                Breed = "Aljašský malamut",
                                                Birthday = new DateTime(2021, 6, 13),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("089f5dc3-0f02-4ee5-923c-3d238f7cf2a4"),
                                Name = "DMM 2",
                                Description = "Muži nad 40 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jan",
                                        LastName = "Antoš",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Bulhary 12",
                                            City = "",
                                            ZipCode = ""
                                        },
                                        Phone = "607242453",
                                        Email = "j2a@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Arny",
                                                Breed = "Ohař",
                                                Birthday = new DateTime(2016, 7, 21),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jan",
                                        LastName = "Broža",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Čechova 9",
                                            City = "Velké Meziříčí",
                                            ZipCode = ""
                                        },
                                        Phone = "777768058",
                                        Email = "dmajka@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Breath of Highland Tullibeardie",
                                                Breed = "Bearded Collie",
                                                Birthday = new DateTime(2020, 4, 27),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Pavel",
                                        LastName = "Drexler",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Družstevní 325",
                                            City = "Lomnice",
                                            ZipCode = "67923"
                                        },
                                        Phone = "733693715",
                                        Email = "PavelDrexler@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Aggi",
                                                Breed = "MMO",
                                                Birthday = new DateTime(2022, 4, 18),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Martin",
                                        LastName = "Hanslík",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Lejšovka 98",
                                            City = "",
                                            ZipCode = ""
                                        },
                                        Phone = "603289817",
                                        Email = "hrochprdoch@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Tessi z Býchorska",
                                                Breed = "Německý krátkosrstý ohař",
                                                Birthday = new DateTime(2020, 6, 26),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Ondřej",
                                        LastName = "Jareš",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Na Stráni 248",
                                            City = "Týnec nad Labem",
                                            ZipCode = ""
                                        },
                                        Phone = "775207418",
                                        Email = "o.jares@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "India z Majklovy zahrady",
                                                Breed = "český strakatý pes",
                                                Birthday = new DateTime(2014, 6, 6),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Ondřej",
                                        LastName = "Kryl",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Veleslavínova 22",
                                            City = "Ostrava",
                                            ZipCode = ""
                                        },
                                        Phone = "774248748",
                                        Email = "ondrejkryl@email.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Thor",
                                                Breed = "kříženec",
                                                Birthday = new DateTime(2016, 11, 24),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lukáš",
                                        LastName = "Ryba",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Lipůvka 434",
                                            City = "Lipůvka",
                                            ZipCode = "67922"
                                        },
                                        Phone = "724204323",
                                        Email = "ryba.l@post.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Ikaros od Mlázovické tvrze",
                                                Breed = "Anglický setr",
                                                Birthday = new DateTime(2020, 4, 10),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Martin",
                                        LastName = "Svrček",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Majakovského 4485/4",
                                            City = "Martin",
                                            ZipCode = "03601"
                                        },
                                        Phone = "+420918244372",
                                        Email = "marsvrcek@azet.sk",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Olaf",
                                                Breed = "sibírsky husky",
                                                Birthday = new DateTime(2021, 7, 1),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Vladimír",
                                        LastName = "Wičar",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Lieberzeitova 25a",
                                            City = "Brno",
                                            ZipCode = ""
                                        },
                                        Phone = "770114566",
                                        Email = "janawicarova@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Chilli",
                                                Breed = "vestaj",
                                                Birthday = new DateTime(2016, 5, 10),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Entities.Actions.CreateActionInternalStorageRequest.RaceDto
                    {
                        Id = Guid.Parse("12cd4b53-aa18-4adb-be5e-08ac5cc017cc"),
                        Name = "Short",
                        Distance = 21,
                        Begin = new DateTime(2024, 6, 29, 8, 0, 0),
                        End = new DateTime(2024, 6, 30, 10, 0, 0),
                        Categories = new List<Entities.Actions.CreateActionInternalStorageRequest.CategoryDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("061034ce-31ec-4f28-96f6-c816ea930e1e"),
                                Name = "Short",
                                Description = "Všichni bez rozdílu",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Marie",
                                        LastName = "Adamcová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Choťánky 90",
                                            City = "Poděbrady",
                                            ZipCode = "290 01"
                                        },
                                        Phone = "723915734",
                                        Email = "adamcova@saul-is.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Baldur Dog Arabat",
                                                Breed = "Belgický ovčák tervueren",
                                                Birthday = new DateTime(2021, 5, 4),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Zuzana",
                                        LastName = "Adamcová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Choťánky 90",
                                            City = "Poděbrady",
                                            ZipCode = "290 01"
                                        },
                                        Phone = "603822036",
                                        Email = "adamcova@saul-is.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Ares Ritter von Falkenberg",
                                                Breed = "Belgický ovčák laekenois",
                                                Birthday = new DateTime(2020, 11, 13),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Veronika",
                                        LastName = "Urbanová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Reznovice 56",
                                            City = "Ivančice"
                                        },
                                        Phone = "723771779",
                                        Email = "smigurka@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Houba",
                                                Breed = "Kříženec (lab/ridge)",
                                                Birthday = new DateTime(2021, 1, 1), // Placeholder for birthday
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jan",
                                        LastName = "Bayer",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "K Lesnu 193",
                                            City = "Lhot"
                                        },
                                        Phone = "734899656",
                                        Email = "bayerovahelena21@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Aiko",
                                                Breed = "Border kolie",
                                                Birthday = new DateTime(2014, 8, 7),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Gabriela",
                                        LastName = "Čejková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Za Příhonem 768",
                                            City = "Bystřice pod Hostýnem",
                                            ZipCode = "768 61"
                                        },
                                        Phone = "775243513",
                                        Email = "gcejkova@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Cita Cele Brita",
                                                Breed = "DK",
                                                Birthday = new DateTime(2022, 2, 17),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Hana",
                                        LastName = "Fuksová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Tř. Odboje 864",
                                            City = "Unknown City"
                                        },
                                        Phone = "608345870",
                                        Email = "fuksova.h@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Conie",
                                                Breed = "MOK",
                                                Birthday = new DateTime(2015, 4, 29),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jana",
                                        LastName = "Gerychová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Komenského 448",
                                            City = "Fryšták"
                                        },
                                        Phone = "776008108",
                                        Email = "gejane@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Bailey",
                                                Breed = "Maďarský ohař krátkosrstý",
                                                Birthday = new DateTime(2018, 10, 21),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jitka",
                                        LastName = "Grygarová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Horní Jasenka 87",
                                            City = "Unknown City"
                                        },
                                        Phone = "734102970",
                                        Email = "jita.grygarova@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Tyr",
                                                Breed = "MOK",
                                                Birthday = new DateTime(2020, 1, 1),  // Placeholder date
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Julie",
                                        LastName = "Jarolímová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Žitná 1413",
                                            City = "Chotěboř"
                                        },
                                        Phone = "724221990",
                                        Email = "Jarolimovajita@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Merlin",
                                                Breed = "Border Kolie",
                                                Birthday = new DateTime(2022, 1, 9),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Zuzana",
                                        LastName = "Smržová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Březolupy 183",
                                            City = "Unknown City"
                                        },
                                        Phone = "734467848",
                                        Email = "smrzova.zuzana@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Izabella",
                                                Breed = "MOK",
                                                Birthday = new DateTime(2016, 1, 1),  // Placeholder date
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Elizabeth",
                                                Breed = "voříšek",
                                                Birthday = new DateTime(2012, 1, 1),  // Placeholder date
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kateřina",
                                        LastName = "Jedličková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Sídliště 529",
                                            City = "Hrušovany u Brna",
                                            ZipCode = "66462"
                                        },
                                        Phone = "721698791",
                                        Email = "jedlikacka@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Bella Rosa Bohemian Edition",
                                                Breed = "Stafordšírský bulteriér",
                                                Birthday = new DateTime(2021, 3, 9),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jan",
                                        LastName = "Jirsa",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Na Výsluní 1222",
                                            City = "Chotěboř"
                                        },
                                        Phone = "723720817",
                                        Email = "janjirsa09@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Kišan",
                                                Breed = "Shiba-Inu",
                                                Birthday = new DateTime(2021, 3, 30),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Hana",
                                        LastName = "Jurajdová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Ženklava 270",
                                            City = "Unknown City"  // Placeholder as city is not provided
                                        },
                                        Phone = "604409548",
                                        Email = "HanaJurajdova@centrum.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Corry",
                                                Breed = "Dobrman",
                                                Birthday = new DateTime(2018, 2, 1),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Petra",
                                        LastName = "Klimosz",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Luleč 0201",
                                            City = "Unknown City"
                                        },
                                        Phone = "728512665",
                                        Email = "petra.klimosz@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Ford",
                                                Breed = "Flat Coated Retriever",
                                                Birthday = new DateTime(2016, 6, 21),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kamila",
                                        LastName = "Knoppová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Mlýnská 802",
                                            City = "Zlín - Malenovice"
                                        },
                                        Phone = "605786243",
                                        Email = "knoppovakamila@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Aura",
                                                Breed = "Švýcarský salašnický pes",
                                                Birthday = new DateTime(2022, 8, 22),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Tereza",
                                        LastName = "Kotasová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Řeka 162",
                                            City = "Unknown City"
                                        },
                                        Phone = "736127932",
                                        Email = "kotasovat@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Ave Aura Black",
                                                Breed = "Border kolie",
                                                Birthday = new DateTime(2020, 7, 3),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lucie",
                                        LastName = "Kratochvílová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Školní 1729",
                                            City = "Vsetín",
                                            ZipCode = "75501"
                                        },
                                        Phone = "732869051",
                                        Email = "kratochvilova.lucie2@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Enny",
                                                Breed = "Kříženec NO",
                                                Birthday = new DateTime(2013, 4, 4),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Veronika",
                                        LastName = "Macečková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Zubří Bořkova 1155",
                                            City = "Zubří",
                                            ZipCode = "75654"
                                        },
                                        Phone = "75654", // Note: Phone number seems incorrect, possibly a postal code duplicate
                                        Email = "veronikamaceckova@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Max",
                                                Breed = "kříženec",
                                                Birthday = new DateTime(2018, 1, 1), // Placeholder date
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lenka",
                                        LastName = "Mikulcová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Polní 1988",
                                            City = "Šenov",
                                            ZipCode = "73934"
                                        },
                                        Phone = "737516917",
                                        Email = "lenkapadisakova@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Akira",
                                                Breed = "Sibiřský husky",
                                                Birthday = new DateTime(2021, 5, 7),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jana",
                                        LastName = "Mlýnková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Dr. Beneše 859",
                                            City = "Napajedla"
                                        },
                                        Phone = "725778694",
                                        Email = "jana-mlynkova@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Sky",
                                                Breed = "Border Collie",
                                                Birthday = new DateTime(2022, 1, 1), // Placeholder for actual birth date
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Martina",
                                        LastName = "Mücková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "K Sosni 149",
                                            City = "Unknown City"
                                        },
                                        Phone = "604339955",
                                        Email = "kiska@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Gery",
                                                Breed = "Kříženec",
                                                Birthday = new DateTime(2021, 1, 1), // Placeholder for actual birth date
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Marta",
                                        LastName = "Vojkůvková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Dolní Bečva 663",
                                            City = "Dolní Bečva"
                                        },
                                        Phone = "739652982",
                                        Email = "vojkuvkova.vet@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Jackie",
                                                Breed = "Slovenský čuvač",
                                                Birthday = new DateTime(2021, 11, 20),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Ľubica",
                                        LastName = "Oczková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Veleslavínova 22",
                                            City = "Unknown City"  // City not specified in the provided data
                                        },
                                        Phone = "607548986",
                                        Email = "oczkova.l@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Biri",
                                                Breed = "kříženec",
                                                Birthday = new DateTime(2018, 6, 28),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Iveta",
                                        LastName = "Pfeilerová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Býchory",  // No specific street provided
                                            City = "Unknown City"
                                        },
                                        Phone = "603915894",
                                        Email = "ivetapfeilerova@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Griff - Gin Fizz Griffella",
                                                Breed = "Flat coated retriever",
                                                Birthday = new DateTime(2021, 8, 22),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "David",
                                        LastName = "Pilař",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "U Dvora 1207",
                                            City = "Brušperk",
                                            ZipCode = "739 44"
                                        },
                                        Phone = "+420 608 000 952",
                                        Email = "david@czpilar.net",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Cristine Deluca Moravia",
                                                Breed = "Saluki",
                                                Birthday = new DateTime(2018, 8, 14),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Veronika",
                                        LastName = "Plachá",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Anenská 689",
                                            City = "Frýdek-Místek",
                                            ZipCode = "73801"
                                        },
                                        Phone = "603822655",
                                        Email = "plachaverca@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Argo",
                                                Breed = "Pudl trpasličí",
                                                Birthday = new DateTime(2018, 7, 19),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Matej",
                                        LastName = "Plieštik",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Gašparovo 230",
                                            City = "Beňuš",
                                            ZipCode = "976 64"
                                        },
                                        Phone = "+421915493007",
                                        Email = "matejpliestik11@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Aspen Lupus Aurea",
                                                Breed = "Československý vlčiak",
                                                Birthday = new DateTime(2019, 5, 24),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Martina",
                                        LastName = "Polášková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Sídliště Svobody 3",
                                            City = "Prostějov",
                                            ZipCode = "79601"
                                        },
                                        Phone = "601389297",
                                        Email = "martinapolaskowa@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Heartbreaker Snowflake of Angel",
                                                Breed = "Aljašský malamut",
                                                Birthday = new DateTime(2019, 4, 9),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Radka",
                                        LastName = "Polášková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Mitrovická 1170/293",
                                            City = "Unknown City"  // City not specified
                                        },
                                        Phone = "602753910",
                                        Email = "radkapolaskova78@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Roxy",
                                                Breed = "Královský pudl",
                                                Birthday = new DateTime(2023, 2, 8),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Pavel",
                                        LastName = "Prokop",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Luh 1805",
                                            City = "Vsetín",
                                            ZipCode = "75501"
                                        },
                                        Phone = "+420737269974",
                                        Email = "p.prokop66@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Chelsea",
                                                Breed = "Entlebušský salašnický pes",
                                                Birthday = new DateTime(2021, 7, 10),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lukáš",
                                        LastName = "Sebera",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Dolní Lutyně, U nové cesty 790",
                                            City = "Dolní Lutyně",
                                            ZipCode = "735 53"
                                        },
                                        Phone = "776778388",
                                        Email = "seberal@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Dasty",
                                                Breed = "Australský ovčák",
                                                Birthday = new DateTime(2021, 9, 1),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Michal",
                                        LastName = "Sedláček",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Šelešovice 30",
                                            City = "Šelešovice",
                                            ZipCode = "76701"
                                        },
                                        Phone = "720376583",
                                        Email = "michal.sedlacek029@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Chinedu Badi Wandelmere",
                                                Breed = "Rhodéský Ridgeback",
                                                Birthday = new DateTime(2016, 2, 19),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Klára",
                                        LastName = "Sukupová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Velký Ořechov 48",
                                            City = "Velký Ořechov",
                                            ZipCode = "76307"
                                        },
                                        Phone = "+420730177441",
                                        Email = "klaraksc@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Tommi",
                                                Breed = "Australský ovčák",
                                                Birthday = new DateTime(2023, 3, 25),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Daniel",
                                        LastName = "Surý",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "michálkovická 870",
                                            City = "Rychvald",
                                            ZipCode = "735 32"
                                        },
                                        Phone = "604511282",
                                        Email = "dany154@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Loki",
                                                Breed = "Sibiřský husky",
                                                Birthday = new DateTime(2022, 3, 11),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Markéta",
                                        LastName = "Tomáš",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Návsí 1114",
                                            City = "Návsí",
                                            ZipCode = "Unknown"
                                        },
                                        Phone = "732544757",
                                        Email = "vrbova.marketa89@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Danae z Vančáku",
                                                Breed = "Švycký honič",
                                                Birthday = new DateTime(2018, 11, 8),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Martina",
                                        LastName = "Trajteľová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Gašparovo 230",
                                            City = "Beňuš",
                                            ZipCode = "976 64"
                                        },
                                        Phone = "+421915615881",
                                        Email = "trajtelovamartina@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Marlon Čierny ónyx",
                                                Breed = "Československý vlčiak",
                                                Birthday = new DateTime(2022, 1, 10),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Veronika",
                                        LastName = "Urbanová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Reznovice 56",
                                            City = "Ivančice",
                                            ZipCode = "664 91"
                                        },
                                        Phone = "723771779",
                                        Email = "smigurka@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Houba",
                                                Breed = "Kříženec (labrador/ridgeback)",
                                                Birthday = new DateTime(1981, 3, 9),  // This seems like a data error, placeholder date
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Ivana",
                                        LastName = "Válková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Kostelec u Holešova 297",
                                            City = "Kostelec u Holešova",
                                            ZipCode = "768 43"
                                        },
                                        Phone = "732381024",
                                        Email = "isustalova@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Bella - Blair To Be Sunny Amaranthe",
                                                Breed = "Dlouhosrstá kolie",
                                                Birthday = new DateTime(2021, 2, 24),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Marcela",
                                        LastName = "Vlčková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Střelniční 661",
                                            City = "Frenštát pod Radhoštěm"
                                        },
                                        Phone = "604862463",
                                        Email = "vlcice199@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "I'Khalessi Vlčí tlapka",
                                                Breed = "Čsv",
                                                Birthday = new DateTime(2019, 10, 28),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Dita",
                                        LastName = "Vondráková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Skautská 2665",
                                            City = "Unknown City"
                                        },
                                        Phone = "731737767",
                                        Email = "dvondrakova@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Kira",
                                                Breed = "Irský setr",
                                                Birthday = new DateTime(2018, 12, 14),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Entities.Actions.CreateActionInternalStorageRequest.RaceDto
                    {
                        Id = Guid.Parse("d9431a85-5894-4e6d-8534-49e10b2a9546"),
                        Name = "Dětská / štěněcí",
                        Distance = 3,
                        Begin = new DateTime(2024, 6, 29, 8, 0, 0),
                        End = new DateTime(2024, 6, 30, 10, 0, 0),
                        Categories = new List<Entities.Actions.CreateActionInternalStorageRequest.CategoryDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("446be227-1059-4311-9f9a-521195476835"),
                                Name = "Dětská / štěněcí",
                                Description = "Všichni bez rozdílu",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Richard",
                                        LastName = "Gajdošík",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Ludvika Podeste 1857/34",
                                            City = "Ostrava",
                                        },
                                        Phone = "776017010",
                                        Email = "ricibikes@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Loki",
                                                Breed = "Borderkolie",
                                                Birthday = new DateTime(2023, 8, 29),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Elen",
                                        LastName = "Hroteková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Čechova 15",
                                            City = "Opava",  // Extracted from the full address
                                        },
                                        Phone = "721640874",
                                        Email = "hrotekova.g@seznam.cz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Daiquiri z Faustovy zahrádky",
                                                Breed = "Sheltie",
                                                Birthday = new DateTime(2020, 5, 1),
                                                PetType = Constants.PetType.Dog  // Assuming constant is correctly assigned
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jana",
                                        LastName = "Hubálková",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Kastelána Heřmana 836/16",
                                            City = "Ostrava",
                                        },
                                        Phone = "724913338",
                                        Email = "jana.hubalkova@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Sam",
                                                Breed = "Border kolie",
                                                Birthday = new DateTime(2023, 7, 9),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Iveta",
                                        LastName = "Landová",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "Skelna 67",
                                            City = "Jablonec nad Nisou",
                                        },
                                        Phone = "727950997",
                                        Email = "landova.iveta@gmail.com",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Balú",
                                                Breed = "Sibiřský husky",
                                                Birthday = new DateTime(2023, 11, 22),
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kasia",
                                        LastName = "Podstavka",
                                        Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                                        {
                                            Street = "{Street}",
                                            City = "{City}",
                                        },
                                        Phone = "{Phone}",
                                        Email = "{Email}",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "{PetName}",
                                                Breed = "{PetBreed}",
                                                Birthday = new DateTime(2020, 1, 1), // Placeholder for actual date
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    },
                }

            }, CancellationToken.None))

            .AddDownAction(() => ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
